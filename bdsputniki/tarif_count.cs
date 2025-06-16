using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace bdsputniki
{
    public partial class tarif_count : Form
    {
        private NpgsqlConnection connection;
        private int currentCalculationId = -1;

        public tarif_count()
        {
            InitializeComponent();
            string connString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
            connection = new NpgsqlConnection(connString);

            InitializeComponents();
            LoadData();
        }

        private void InitializeComponents()
        {
            // Настройка DataGridView
            datatarifcount.AutoGenerateColumns = false;
            datatarifcount.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datatarifcount.MultiSelect = false;
            datatarifcount.AllowUserToAddRows = true;

            // Настройка колонок
            datatarifcount.Columns.Clear();

            datatarifcount.Columns.Add("id_расчета", "ID");
            datatarifcount.Columns.Add("Название_тарифа", "Тариф");
            datatarifcount.Columns.Add("Количество_пакетов", "Кол-во пакетов");
            datatarifcount.Columns.Add("Стоимость", "Стоимость");

            datatarifcount.Columns["id_расчета"].Visible = false;

            // Настройка ComboBox
            comboBoxtarif.DropDownStyle = ComboBoxStyle.DropDownList;

            // Настройка кнопок
            buttonadd.Click += ButtonAdd_Click;
            buttonchg.Click += ButtonChange_Click;
            buttondel.Click += ButtonDelete_Click;
            buttonaddpck.Click += ButtonManagePackages_Click;

            // Обработчики событий
            datatarifcount.SelectionChanged += DataGridView_SelectionChanged;
            this.FormClosing += (s, e) => connection?.Dispose();
        }

        private void LoadData()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Загрузка тарифов в ComboBox
                using (var cmd = new NpgsqlCommand(
                    "SELECT \"id_тарифа\", \"Название_тарифа\" FROM \"Тариф\" ORDER BY \"Название_тарифа\"",
                    connection))
                {
                    var adapter = new NpgsqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    comboBoxtarif.DataSource = table;
                    comboBoxtarif.DisplayMember = "Название_тарифа";
                    comboBoxtarif.ValueMember = "id_тарифа";
                }

                // Загрузка расчетов в DataGridView
                LoadCalculations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadCalculations()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (var cmd = new NpgsqlCommand(
                    @"SELECT tr.""id_расчета"", t.""Название_тарифа"", 
                    tr.""Количество_пакетов"", tr.""Стоимость""
                    FROM ""Тарифы_с_расчетом"" tr
                    JOIN ""Тариф"" t ON tr.""id_тарифа"" = t.""id_тарифа""
                    ORDER BY t.""Название_тарифа""",
                    connection))
                {
                    var adapter = new NpgsqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    datatarifcount.Rows.Clear();

                    foreach (DataRow row in table.Rows)
                    {
                        datatarifcount.Rows.Add(
                            row["id_расчета"],
                            row["Название_тарифа"],
                            row["Количество_пакетов"],
                            row["Стоимость"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки расчетов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (datatarifcount.SelectedRows.Count > 0)
            {
                var row = datatarifcount.SelectedRows[0];
                currentCalculationId = Convert.ToInt32(row.Cells["id_расчета"].Value);
                comboBoxtarif.SelectedValue = GetTarifIdForCalculation(currentCalculationId);
            }
        }

        private int GetTarifIdForCalculation(int calculationId)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (var cmd = new NpgsqlCommand(
                    "SELECT \"id_тарифа\" FROM \"Тарифы_с_расчетом\" WHERE \"id_расчета\" = @id",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@id", calculationId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxtarif.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тариф", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tarifId = Convert.ToInt32(comboBoxtarif.SelectedValue);

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Получаем количество пакетов и стоимость
                int packageCount = GetPackageCount(tarifId);
                decimal totalCost = GetTotalCost(tarifId);

                // Добавляем новый расчет
                using (var cmd = new NpgsqlCommand(
                    @"INSERT INTO ""Тарифы_с_расчетом"" 
                    (""id_тарифа"", ""Количество_пакетов"", ""Стоимость"")
                    VALUES (@idTarif, @count, @cost)",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@idTarif", tarifId);
                    cmd.Parameters.AddWithValue("@count", packageCount);
                    cmd.Parameters.AddWithValue("@cost", totalCost);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Расчет успешно добавлен", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCalculations();
                ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении расчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private int GetPackageCount(int tarifId)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT COUNT(*) FROM \"Тариф_Пакет\" WHERE \"id_тарифа\" = @id",
                connection))
            {
                cmd.Parameters.AddWithValue("@id", tarifId);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private decimal GetTotalCost(int tarifId)
        {
            int count = GetPackageCount(tarifId);
            return count * 200m; // 200 — начальная стоимость одного пакета
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (datatarifcount.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите расчет для изменения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxtarif.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тариф", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int calculationId = currentCalculationId;
            int newTarifId = Convert.ToInt32(comboBoxtarif.SelectedValue);

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Получаем количество пакетов и стоимость для нового тарифа
                int packageCount = GetPackageCount(newTarifId);
                decimal totalCost = GetTotalCost(newTarifId);

                // Обновляем расчет
                using (var cmd = new NpgsqlCommand(
                    @"UPDATE ""Тарифы_с_расчетом"" 
                    SET ""id_тарифа"" = @idTarif, 
                        ""Количество_пакетов"" = @count, 
                        ""Стоимость"" = @cost
                    WHERE ""id_расчета"" = @id",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@idTarif", newTarifId);
                    cmd.Parameters.AddWithValue("@count", packageCount);
                    cmd.Parameters.AddWithValue("@cost", totalCost);
                    cmd.Parameters.AddWithValue("@id", calculationId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Расчет успешно обновлен", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCalculations();
                ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении расчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (datatarifcount.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите расчет для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Вы действительно хотите удалить выбранный расчет?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int calculationId = currentCalculationId;

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (var cmd = new NpgsqlCommand(
                    "DELETE FROM \"Тарифы_с_расчетом\" WHERE \"id_расчета\" = @id",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@id", calculationId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Расчет успешно удален", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCalculations();
                ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении расчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ButtonManagePackages_Click(object sender, EventArgs e)
        {
            if (datatarifcount.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите расчет для управления пакетами", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tarifId = GetTarifIdForCalculation(currentCalculationId);
            string tarifName = comboBoxtarif.Text;

            tarif_package newForm = new tarif_package(tarifId, tarifName);
            newForm.Show();

            // После закрытия формы обновляем данные
            LoadCalculations();
        }

        private void ClearSelection()
        {
            datatarifcount.ClearSelection();
            comboBoxtarif.SelectedIndex = -1;
            currentCalculationId = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
        }

        

        private void buttonaddpck_Click(object sender, EventArgs e)
        {
            if (comboBoxtarif.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите тариф!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int tarifId = Convert.ToInt32(comboBoxtarif.SelectedValue);
            string tarifName = comboBoxtarif.Text;
            var packageForm = new tarif_package(tarifId, tarifName);
            packageForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tarif newForm = new tarif();
            newForm.Show();
        }
    }
}