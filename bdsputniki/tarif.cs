using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace bdsputniki
{
    public partial class tarif : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        private NpgsqlConnection connection;

        public tarif()
        {
            InitializeComponent();
            connection = new NpgsqlConnection(connectionString);
            InitializeDataGridView();
            SetupEventHandlers();
        }

        private void InitializeDataGridView()
        {
            datatarif.AutoGenerateColumns = false;
            datatarif.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datatarif.MultiSelect = false;
            datatarif.AllowUserToAddRows = true;

            // Настройка колонок
            datatarif.Columns.Clear();

            var idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "id_тарифа";
            idColumn.HeaderText = "ID";
            idColumn.DataPropertyName = "id_тарифа";
            idColumn.Visible = false;
            datatarif.Columns.Add(idColumn);

            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Название_тарифа";
            nameColumn.HeaderText = "Название тарифа";
            nameColumn.DataPropertyName = "Название_тарифа";
            nameColumn.Width = 200;
            datatarif.Columns.Add(nameColumn);

            var descColumn = new DataGridViewTextBoxColumn();
            descColumn.Name = "Описание";
            descColumn.HeaderText = "Описание";
            descColumn.DataPropertyName = "Описание";
            descColumn.Width = 300;
            datatarif.Columns.Add(descColumn);
        }

        private void SetupEventHandlers()
        {
            this.Load += (s, e) => LoadTarifs();
            this.FormClosing += (s, e) => connection?.Dispose();

            buttonadd.Click += ButtonAdd_Click;
            buttonchg.Click += ButtonChange_Click;
            buttondel.Click += ButtonDelete_Click;
            datatarif.SelectionChanged += DataGridView_SelectionChanged;
        }

        private void LoadTarifs()
        {
            try
            {
                using (var adapter = new NpgsqlDataAdapter(
                    "SELECT \"id_тарифа\", \"Название_тарифа\", \"Описание\" FROM \"Тариф\" ORDER BY \"Название_тарифа\"",
                    connection))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    datatarif.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки тарифов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (datatarif.SelectedRows.Count > 0)
            {
                var row = datatarif.SelectedRows[0];
                textBoxname.Text = row.Cells["Название_тарифа"].Value?.ToString() ?? "";
                textBoxdesc.Text = row.Cells["Описание"].Value?.ToString() ?? "";
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxname.Text))
            {
                MessageBox.Show("Введите название тарифа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection.Open();

                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO \"Тариф\" (\"Название_тарифа\", \"Описание\") VALUES (@name, @desc) RETURNING \"id_тарифа\"",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@name", textBoxname.Text.Trim());
                    cmd.Parameters.AddWithValue("@desc", textBoxdesc.Text.Trim());
                    var newId = cmd.ExecuteScalar();

                    // Добавляем запись в Тарифы_с_расчетом
                    using (var calcCmd = new NpgsqlCommand(
                        "INSERT INTO \"Тарифы_с_расчетом\" (\"id_тарифа\", \"Название_тарифа\") VALUES (@id, @name)",
                        connection))
                    {
                        calcCmd.Parameters.AddWithValue("@id", newId);
                        calcCmd.Parameters.AddWithValue("@name", textBoxname.Text.Trim());
                        calcCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Тариф успешно добавлен", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                LoadTarifs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении тарифа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (datatarif.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тариф для изменения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxname.Text))
            {
                MessageBox.Show("Введите название тарифа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var id = Convert.ToInt32(datatarif.SelectedRows[0].Cells["id_тарифа"].Value);

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Обновляем основную таблицу
                        using (var cmd = new NpgsqlCommand(
                            "UPDATE \"Тариф\" SET \"Название_тарифа\" = @name, \"Описание\" = @desc WHERE \"id_тарифа\" = @id",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@name", textBoxname.Text.Trim());
                            cmd.Parameters.AddWithValue("@desc", textBoxdesc.Text.Trim());
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // Обновляем расчетную таблицу
                        using (var calcCmd = new NpgsqlCommand(
                            "UPDATE \"Тарифы_с_расчетом\" SET \"Название_тарифа\" = @name WHERE \"id_тарифа\" = @id",
                            connection, transaction))
                        {
                            calcCmd.Parameters.AddWithValue("@name", textBoxname.Text.Trim());
                            calcCmd.Parameters.AddWithValue("@id", id);
                            calcCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("Тариф успешно изменен", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadTarifs();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении тарифа: {ex.Message}", "Ошибка",
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
            if (datatarif.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тариф для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Вы действительно хотите удалить выбранный тариф?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var id = Convert.ToInt32(datatarif.SelectedRows[0].Cells["id_тарифа"].Value);

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Удаляем связи с пакетами
                        using (var linkCmd = new NpgsqlCommand(
                            "DELETE FROM \"Тариф_Пакет\" WHERE \"id_тарифа\" = @id",
                            connection, transaction))
                        {
                            linkCmd.Parameters.AddWithValue("@id", id);
                            linkCmd.ExecuteNonQuery();
                        }

                        // 2. Удаляем из расчетной таблицы
                        using (var calcCmd = new NpgsqlCommand(
                            "DELETE FROM \"Тарифы_с_расчетом\" WHERE \"id_тарифа\" = @id",
                            connection, transaction))
                        {
                            calcCmd.Parameters.AddWithValue("@id", id);
                            calcCmd.ExecuteNonQuery();
                        }

                        // 3. Удаляем сам тариф
                        using (var cmd = new NpgsqlCommand(
                            "DELETE FROM \"Тариф\" WHERE \"id_тарифа\" = @id",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("Тариф успешно удален", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields();
                        LoadTarifs();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении тарифа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        

        private void ClearFields()
        {
            textBoxname.Clear();
            textBoxdesc.Clear();
        }

        
    }
}