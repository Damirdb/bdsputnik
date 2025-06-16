using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace bdsputniki
{
    public partial class contract : Form
    {
        private NpgsqlConnection connection;
        private DataTable dtRelations;

        public contract()
        {
            InitializeComponent();

            // Замените строку подключения на вашу!
            string connString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
            connection = new NpgsqlConnection(connString);

            LoadContracts();
            LoadComboBoxes();

            buttonadd.Click += buttonadd_Click;
            buttondel.Click += buttondel_Click;
            buttonchg.Click += buttonchg_Click_1;
            dataclient.SelectionChanged += dataclient_SelectionChanged;

            comboBoxnameprovaider.SelectedIndexChanged += comboBoxnameprovaider_SelectedIndexChanged;
            comboBoxnametarif.SelectedIndexChanged += comboBoxnametarif_SelectedIndexChanged;
        }

        // Загрузка всех договоров в таблицу
        private void LoadContracts()
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        ""Номер_договора"",
                        ""Дата_заключения"",
                        ""Срок_заключения"",
                        ""Тип_оборудования"",
                        ""ФИО_клиента"",
                        ""Наименование_провайдера"",
                        ""Название_тарифа""
                    FROM ""Договор""
                    WHERE
                        CAST(""Номер_договора"" AS TEXT) ILIKE @q OR
                        ""ФИО_клиента"" ILIKE @q OR
                        ""Наименование_провайдера"" ILIKE @q OR
                        ""Название_тарифа"" ILIKE @q OR
                        ""Тип_оборудования"" ILIKE @q
                ";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@q", "%" + textBoxsearch.Text.Trim() + "%");
                dtRelations = new DataTable();
                adapter.Fill(dtRelations);
                dataclient.DataSource = dtRelations;
            }
        }

        // Заполнение комбобоксов
        private void LoadComboBoxes()
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();

                // Клиенты
                NpgsqlDataAdapter adapterClient = new NpgsqlDataAdapter(@"SELECT ""id_клиента"", ""ФИО"" FROM ""Клиент""", conn);
                DataTable dtClient = new DataTable();
                adapterClient.Fill(dtClient);
                comboBoxnameclient.DataSource = dtClient;
                comboBoxnameclient.DisplayMember = "ФИО";
                comboBoxnameclient.ValueMember = "id_клиента";

                // Провайдеры
                NpgsqlDataAdapter adapterProv = new NpgsqlDataAdapter(@"SELECT ""id_провайдера"", ""Наименование"" FROM ""Провайдер""", conn);
                DataTable dtProv = new DataTable();
                adapterProv.Fill(dtProv);
                comboBoxnameprovaider.DataSource = dtProv;
                comboBoxnameprovaider.DisplayMember = "Наименование";
                comboBoxnameprovaider.ValueMember = "id_провайдера";

                // Тарифы
                NpgsqlDataAdapter adapterTariff = new NpgsqlDataAdapter(@"SELECT ""id_тарифа"", ""Название_тарифа"" FROM ""Тариф""", conn);
                DataTable dtTariff = new DataTable();
                adapterTariff.Fill(dtTariff);
                comboBoxnametarif.DataSource = dtTariff;
                comboBoxnametarif.DisplayMember = "Название_тарифа";
                comboBoxnametarif.ValueMember = "id_тарифа";

                
                // Тип оборудования из Спутниковая_станция
                NpgsqlDataAdapter adapterStation = new NpgsqlDataAdapter(@"SELECT ""id_станции"", ""Тип_оборудования"" FROM ""Спутниковая_станция""", conn);
                DataTable dtStation = new DataTable();
                adapterStation.Fill(dtStation);
                comboBoxtype.DataSource = dtStation;
                comboBoxtype.DisplayMember = "Тип_оборудования";
                comboBoxtype.ValueMember = "id_станции";
            }
        }

        // Добавление договора
        private void buttonadd_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO ""Договор"" 
                        (""Дата_заключения"", ""Срок_заключения"", ""Тип_оборудования"", ""ФИО_клиента"", ""Наименование_провайдера"", ""Название_тарифа"", ""id_станции"", ""id_клиента"", ""id_провайдера"", ""id_тарифа"")
                    VALUES (@date, @term, @type, @fio, @prov, @tariff, @station, @client, @provider, @tariffid)
                ";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", dateTimePickerdateofconclusion.Value);
                    TimeSpan interval = dateTimePickertermofimprisonment.Value - dateTimePickerdateofconclusion.Value;
                    cmd.Parameters.Add("@term", NpgsqlDbType.Interval).Value = interval;
                    cmd.Parameters.AddWithValue("@type", comboBoxtype.Text);
                    cmd.Parameters.AddWithValue("@fio", comboBoxnameclient.Text);
                    cmd.Parameters.AddWithValue("@prov", comboBoxnameprovaider.Text);
                    cmd.Parameters.AddWithValue("@tariff", comboBoxnametarif.Text);
                    cmd.Parameters.AddWithValue("@station", comboBoxtype.SelectedValue);
                    cmd.Parameters.AddWithValue("@client", comboBoxnameclient.SelectedValue);
                    cmd.Parameters.AddWithValue("@provider", comboBoxnameprovaider.SelectedValue);
                    cmd.Parameters.AddWithValue("@tariffid", comboBoxnametarif.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadContracts();
        }

        // Удаление договора
        private void buttondel_Click(object sender, EventArgs e)
        {
            if (dataclient.CurrentRow == null) return;
            int contractId = Convert.ToInt32(dataclient.CurrentRow.Cells["Номер_договора"].Value);

            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"DELETE FROM ""Договор"" WHERE ""Номер_договора"" = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", contractId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadContracts();
        }

        // Изменение договора
        

        // При выборе строки в таблице — заполнить поля для редактирования
        private void dataclient_SelectionChanged(object sender, EventArgs e)
        {
            if (dataclient.CurrentRow == null) return;

            object dateValue = dataclient.CurrentRow.Cells["Дата_заключения"].Value;
            object termValue = dataclient.CurrentRow.Cells["Срок_заключения"].Value;

            if (dateValue != DBNull.Value && termValue != DBNull.Value)
            {
                DateTime startDate = Convert.ToDateTime(dateValue);
                TimeSpan interval = (TimeSpan)termValue;
                dateTimePickerdateofconclusion.Value = startDate;
                dateTimePickertermofimprisonment.Value = startDate.Add(interval);
            }
            else
            {
                dateTimePickerdateofconclusion.Value = DateTime.Now;
                dateTimePickertermofimprisonment.Value = DateTime.Now;
            }

            comboBoxtype.Text = dataclient.CurrentRow.Cells["Тип_оборудования"].Value?.ToString() ?? "";
            comboBoxnameclient.Text = dataclient.CurrentRow.Cells["ФИО_клиента"].Value?.ToString() ?? "";
            comboBoxnameprovaider.Text = dataclient.CurrentRow.Cells["Наименование_провайдера"].Value?.ToString() ?? "";
        }

        // Обработчик выбора провайдера
        private void comboBoxnameprovaider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxnameprovaider.SelectedItem is DataRowView row)
            {
                string providerName = row["Наименование"].ToString();
                int idProvider = Convert.ToInt32(row["id_провайдера"]);
                // Здесь можно использовать providerName и idProvider по вашему сценарию
            }
        }

        // Обработчик выбора тарифа
        private void comboBoxnametarif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxnametarif.SelectedItem is DataRowView row)
            {
                string tariffName = row["Название_тарифа"].ToString();
                int idTariff = Convert.ToInt32(row["id_тарифа"]);
                // Здесь можно использовать tariffName и idTariff по вашему сценарию
            }
        }

        private void dateTimePickertermofimprisonment_ValueChanged(object sender, EventArgs e)
        {
            // Здесь можно реализовать нужную вам логику при изменении значения срока заключения
        }

        private void buttonchg_Click_1(object sender, EventArgs e)
        {
            if (dataclient.CurrentRow == null) return;
            int contractId = Convert.ToInt32(dataclient.CurrentRow.Cells["Номер_договора"].Value);

            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"
                    UPDATE ""Договор"" SET 
                        ""Дата_заключения"" = @date, 
                        ""Срок_заключения"" = @term, 
                        ""Тип_оборудования"" = @type, 
                        ""ФИО_клиента"" = @fio,
                        ""Наименование_провайдера"" = @prov,
                        ""Название_тарифа"" = @tariff,
                        ""id_станции"" = @station,
                        ""id_клиента"" = @idClient, 
                        ""id_провайдера"" = @idProv,
                        ""id_тарифа"" = @idTariff
                    WHERE ""Номер_договора"" = @id
                ";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", dateTimePickerdateofconclusion.Value);
                    TimeSpan interval = dateTimePickertermofimprisonment.Value - dateTimePickerdateofconclusion.Value;
                    cmd.Parameters.Add("@term", NpgsqlDbType.Interval).Value = interval;
                    cmd.Parameters.AddWithValue("@type", comboBoxtype.Text);
                    cmd.Parameters.AddWithValue("@fio", comboBoxnameclient.Text);
                    cmd.Parameters.AddWithValue("@prov", comboBoxnameprovaider.Text);
                    cmd.Parameters.AddWithValue("@tariff", comboBoxnametarif.Text);
                    cmd.Parameters.AddWithValue("@station", comboBoxtype.SelectedValue);
                    cmd.Parameters.AddWithValue("@idClient", comboBoxnameclient.SelectedValue);
                    cmd.Parameters.AddWithValue("@idProv", comboBoxnameprovaider.SelectedValue);
                    cmd.Parameters.AddWithValue("@idTariff", comboBoxnametarif.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", contractId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadContracts();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
        }

        private void textBoxsearch_TextChanged(object sender, EventArgs e)
        {
            LoadContracts();
        }
    }
}
