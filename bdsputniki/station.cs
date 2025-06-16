using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace bdsputniki
{
    public partial class station : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        private NpgsqlConnection connection;
        private DataSet dataSet;
        private NpgsqlDataAdapter dataAdapter;
        private NpgsqlCommandBuilder commandBuilder;

        public station()
        {
            InitializeComponent();
        }

        private void station_Load(object sender, EventArgs e)
        {
            // Инициализация ComboBox статусами
            comboBoxstatus.Items.AddRange(new string[] { "Активна", "Неактивна", "На обслуживании", "Ремонт" });

            // Инициализация ComboBox типами оборудования
            comboBoxtype.Items.AddRange(new string[] { 
                "PE65A AZ/EL",
                "PL65A AZ/EL",
                "LANS-65",
                "LANS-80",
                "LANS-97"
            });

            // Настройка DateTimePicker
            dateTimePickerInstall.Format = DateTimePickerFormat.Short;
            dateTimePickerInstall.Value = DateTime.Today;

            LoadData();
            datapackage.CellClick += Datapackage_CellClick;
        }

        private void LoadData()
        {
            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                dataAdapter = new NpgsqlDataAdapter("SELECT * FROM \"Спутниковая_станция\"", connection);
                commandBuilder = new NpgsqlCommandBuilder(dataAdapter);

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Спутниковая_станция");

                datapackage.DataSource = dataSet.Tables["Спутниковая_станция"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void Datapackage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && datapackage.Rows[e.RowIndex].Cells["id_станции"].Value != null)
            {
                DataGridViewRow row = datapackage.Rows[e.RowIndex];

                // Обработка всех полей с учетом DBNull
                textBoxcoordinat.Text = GetSafeString(row.Cells["Географические_данные"].Value);
                dateTimePickerInstall.Value = GetSafeDateTime(row.Cells["Дата_установки"].Value);
                comboBoxtype.Text = GetSafeString(row.Cells["Тип_оборудования"].Value);
                comboBoxstatus.Text = GetSafeString(row.Cells["Статус"].Value);
                textBoxtimescl.Text = GetSafeString(row.Cells["Часовой_пояс"].Value);
            }
        }

        // Вспомогательные методы для безопасного преобразования
        private string GetSafeString(object value)
        {
            return value == DBNull.Value ? string.Empty : value.ToString();
        }

        private DateTime GetSafeDateTime(object value)
        {
            return value == DBNull.Value ? DateTime.Today : Convert.ToDateTime(value);
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"INSERT INTO ""Спутниковая_станция"" 
                                (""Географические_данные"", ""Дата_установки"", ""Тип_оборудования"", ""Статус"", ""Часовой_пояс"") 
                                VALUES (@geo, @date, @type, @status, @timezone)";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("geo", GetDbValue(textBoxcoordinat.Text));
                    cmd.Parameters.AddWithValue("date", dateTimePickerInstall.Value);
                    cmd.Parameters.AddWithValue("type", GetDbValue(comboBoxtype.Text));
                    cmd.Parameters.AddWithValue("status", GetDbValue(comboBoxstatus.Text));
                    cmd.Parameters.AddWithValue("timezone", GetDbValue(textBoxtimescl.Text));

                    cmd.ExecuteNonQuery();
                }

                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }

        private void buttonchg_Click(object sender, EventArgs e)
        {
            if (datapackage.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(datapackage.SelectedRows[0].Cells["id_станции"].Value);

                try
                {
                    string query = @"UPDATE ""Спутниковая_станция"" SET 
                                    ""Географические_данные"" = @geo, 
                                    ""Дата_установки"" = @date, 
                                    ""Тип_оборудования"" = @type, 
                                    ""Статус"" = @status, 
                                    ""Часовой_пояс"" = @timezone 
                                    WHERE ""id_станции"" = @id";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("geo", GetDbValue(textBoxcoordinat.Text));
                        cmd.Parameters.AddWithValue("date", dateTimePickerInstall.Value);
                        cmd.Parameters.AddWithValue("type", GetDbValue(comboBoxtype.Text));
                        cmd.Parameters.AddWithValue("status", GetDbValue(comboBoxstatus.Text));
                        cmd.Parameters.AddWithValue("timezone", GetDbValue(textBoxtimescl.Text));
                        cmd.Parameters.AddWithValue("id", id);

                        cmd.ExecuteNonQuery();
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при изменении: " + ex.Message);
                }
            }
        }

        private void buttondel_Click(object sender, EventArgs e)
        {
            if (datapackage.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(datapackage.SelectedRows[0].Cells["id_станции"].Value);

                try
                {
                    string query = "DELETE FROM \"Спутниковая_станция\" WHERE \"id_станции\" = @id";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }

                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
        }

        private object GetDbValue(string value)
        {
            return string.IsNullOrEmpty(value) ? (object)DBNull.Value : value;
        }

        private void ClearFields()
        {
            textBoxcoordinat.Text = "";
            dateTimePickerInstall.Value = DateTime.Today;
            comboBoxtype.SelectedIndex = -1;
            comboBoxstatus.SelectedIndex = -1;
            textBoxtimescl.Text = "";
        }

        private void textBoxcoordinat_TextChanged(object sender, EventArgs e)
        {
            // Дополнительная обработка при необходимости
        }

        private void comboBoxstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Дополнительная обработка при необходимости
        }

        private void textBoxtimescl_TextChanged(object sender, EventArgs e)
        {
            // Дополнительная обработка при необходимости
        }

        private void comboBoxtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработка изменения выбранного типа оборудования
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
        }
    }
}