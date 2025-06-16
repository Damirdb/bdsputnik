using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace bdsputniki
{
    public partial class tarif_package : Form
    {
        string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        NpgsqlConnection connection;
        NpgsqlCommandBuilder commandBuilder;
        DataSet dataSet;
        private int _tarifId;
        private string _tarifName;

        public tarif_package(int tarifId, string tarifName)
        {
            InitializeComponent();
            _tarifId = tarifId;
            _tarifName = tarifName;
            connection = new NpgsqlConnection(connectionString);
            LoadTarifComboBox();
            this.Load += tarif_package_Load;
            this.buttonadd.Click += buttonadd_Click;
            this.buttonchg.Click += buttonchg_Click;
            this.buttondel.Click += buttondel_Click;
            this.button1.Click += button1_Click;

            // Настройка DataGridView
            dataGridViewTarifPackage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTarifPackage.MultiSelect = false;
            dataGridViewTarifPackage.ReadOnly = true;
        }

        private void tarif_package_Load(object sender, EventArgs e)
        {
            connection.Open();

            LoadTarifsAndPackages();
            LoadTarifPackageData();

            // Добавляем обработчик выбора строки
            dataGridViewTarifPackage.SelectionChanged += Datatarif_SelectionChanged;
        }

        private void Datatarif_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTarifPackage.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewTarifPackage.SelectedRows[0];
                comboBoxtarif.SelectedValue = row.Cells["id_тарифа"].Value;
                comboBoxPackage.SelectedValue = row.Cells["id_пакета"].Value;
            }
        }

        private void LoadTarifPackageData()
        {
            try
            {
                string query = @"SELECT tp.""id_связи"", tp.""id_тарифа"", t.""Название_тарифа"", tp.""id_пакета"" FROM ""Тариф_Пакет"" tp JOIN ""Тариф"" t ON tp.""id_тарифа"" = t.""id_тарифа"" ORDER BY tp.""id_связи""";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridViewTarifPackage.DataSource = table;
                dataGridViewTarifPackage.Columns["id_связи"].HeaderText = "ID";
                dataGridViewTarifPackage.Columns["id_тарифа"].HeaderText = "ID тарифа";
                dataGridViewTarifPackage.Columns["Название_тарифа"].HeaderText = "Тариф";
                dataGridViewTarifPackage.Columns["id_пакета"].HeaderText = "ID пакета";
                dataGridViewTarifPackage.Columns["id_связи"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке: " + ex.Message);
            }
        }

        private void LoadTarifsAndPackages()
        {
            try
            {
                // Загрузка тарифов
                string tarifQuery = "SELECT \"id_тарифа\", \"Название_тарифа\" FROM \"Тариф\" ORDER BY \"Название_тарифа\"";
                NpgsqlDataAdapter tarifAdapter = new NpgsqlDataAdapter(tarifQuery, connection);
                DataTable tarifTable = new DataTable();
                tarifAdapter.Fill(tarifTable);
                comboBoxtarif.DataSource = tarifTable;
                comboBoxtarif.DisplayMember = "Название_тарифа";
                comboBoxtarif.ValueMember = "id_тарифа";
                comboBoxtarif.SelectedIndex = -1;

                // Загрузка пакетов
                string query = "SELECT \"id_пакета\", \"Название\" FROM \"Пакет\" ORDER BY \"Название\"";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                comboBoxPackage.DataSource = table;
                comboBoxPackage.DisplayMember = "Название";
                comboBoxPackage.ValueMember = "id_пакета";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке справочников: " + ex.Message);
            }
        }
        private bool ExistsTarifPackage(object idTarif, object idPackage)
        {
            string checkQuery = @"
        SELECT COUNT(*) FROM ""Тариф_Пакет""
        WHERE ""id_тарифа"" = @id_tarif AND ""id_пакета"" = @id_package";

            using (var cmd = new NpgsqlCommand(checkQuery, connection))
            {
                cmd.Parameters.AddWithValue("id_tarif", idTarif);
                cmd.Parameters.AddWithValue("id_package", idPackage);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            var idTarif = comboBoxtarif.SelectedValue;
            var idPackage = comboBoxPackage.SelectedValue;

            try
            {
                if (ExistsTarifPackage(idTarif, idPackage))
                {
                    MessageBox.Show("Такая запись уже существует.");
                    return;
                }

                int count = 0;
                decimal cost = 0;

                connection.Open();

                // Считаем количество пакетов
                using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM \"Тариф_Пакет\" WHERE \"id_тарифа\" = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", idTarif);
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Суммируем стоимость всех пакетов, подключённых к тарифу
                string sql = @"
                    SELECT COALESCE(SUM(p.""Стоимость""), 0)
                    FROM ""Тариф_Пакет"" tp
                    JOIN ""Пакет"" p ON tp.""id_пакета"" = p.""id_пакета""
                    WHERE tp.""id_тарифа"" = @id";
                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", idTarif);
                    cost = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                connection.Close();

                string query = @"INSERT INTO ""Тарифы_с_расчетом"" 
                               (""id_тарифа"", ""Количество_пакетов"", ""Стоимость"")
                               VALUES (@idTarif, @count, @cost)";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idTarif", idTarif);
                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@cost", cost);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Расчет тарифа добавлен");
                LoadTarifPackageData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }


        private void buttonchg_Click(object sender, EventArgs e)
        {
            if (dataGridViewTarifPackage.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewTarifPackage.SelectedRows[0].Cells["id_связи"].Value);

                try
                {
                    string query = "UPDATE \"Тариф_Пакет\" SET \"id_тарифа\" = @idTarif, \"id_пакета\" = @idPackage WHERE \"id_связи\" = @id";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idTarif", comboBoxtarif.SelectedValue);
                        cmd.Parameters.AddWithValue("@idPackage", comboBoxPackage.SelectedValue);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    LoadTarifPackageData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении: " + ex.Message);
                }
            }
        }

        private void buttondel_Click(object sender, EventArgs e)
        {
            if (dataGridViewTarifPackage.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewTarifPackage.SelectedRows[0].Cells["id_связи"].Value);

                try
                {
                    string query = "DELETE FROM \"Тариф_Пакет\" WHERE \"id_связи\" = @id";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    LoadTarifPackageData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
            this.Hide();
        }

        private void comboBoxtarif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxtarif.SelectedIndex == -1)
                return;

            // Проверяем, что SelectedValue — это не DataRowView
            if (comboBoxtarif.SelectedValue is DataRowView drv)
            {
                int idTarif = Convert.ToInt32(drv["id_тарифа"]);
                string tarifName = drv["Название_тарифа"].ToString();
                // Используй idTarif и tarifName
            }
            else
            {
                int idTarif = Convert.ToInt32(comboBoxtarif.SelectedValue);
                string tarifName = comboBoxtarif.Text;
                // Используй idTarif и tarifName
            }
        }

        private void LoadTarifComboBox()
        {
            try
            {
                connection.Open();
                string query = "SELECT \"id_тарифа\", \"Название_тарифа\" FROM \"Тариф\" ORDER BY \"Название_тарифа\"";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                comboBoxtarif.DataSource = table;
                comboBoxtarif.DisplayMember = "Название_тарифа";
                comboBoxtarif.ValueMember = "id_тарифа";
                comboBoxtarif.SelectedIndex = -1; // чтобы не было выбранного по умолчанию
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки тарифов: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}