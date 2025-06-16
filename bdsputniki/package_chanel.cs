using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace bdsputniki
{
    public partial class package_chanel : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        private NpgsqlConnection connection;
        private DataTable dtRelations;

        public package_chanel()
        {
            InitializeComponent();
            this.Load += Package_chanel_Load;
        }

        private void Package_chanel_Load(object sender, EventArgs e)
        {
            LoadPackageData();
            LoadChannelData();
            LoadPackageChannelRelations();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Настройка внешнего вида DataGridView
            datapackagechannel.AutoGenerateColumns = false;
            datapackagechannel.AllowUserToAddRows = true;  // Разрешаем добавление новых строк
            datapackagechannel.AllowUserToDeleteRows = false;
            datapackagechannel.ReadOnly = false;  // Разрешаем редактирование
            datapackagechannel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datapackagechannel.MultiSelect = false;

            // Очистка существующих колонок
            datapackagechannel.Columns.Clear();

            // Добавление колонок
            datapackagechannel.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_связи",
                DataPropertyName = "id_связи",
                HeaderText = "ID",
                Visible = false // Скрываем ID
            });

            datapackagechannel.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Пакет",
                DataPropertyName = "Пакет",
                HeaderText = "Пакет",
                Width = 200,
                ReadOnly = true  // Делаем колонку только для чтения
            });

            datapackagechannel.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Канал",
                DataPropertyName = "Канал",
                HeaderText = "Канал",
                Width = 200,
                ReadOnly = true  // Делаем колонку только для чтения
            });

            // Скрытые колонки для ID
            datapackagechannel.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_пакета",
                DataPropertyName = "id_пакета",
                Visible = false
            });

            datapackagechannel.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_канала",
                DataPropertyName = "id_канала",
                Visible = false
            });
        }

        private void LoadPackageData()
        {
            try
            {
                using (connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_пакета, \"Название\" FROM \"Пакет\" ORDER BY \"Название\"";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxPackage.DisplayMember = "Название";
                    comboBoxPackage.ValueMember = "id_пакета";
                    comboBoxPackage.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке пакетов: " + ex.Message);
            }
        }

        private void LoadChannelData()
        {
            try
            {
                using (connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_канала, \"Название\" FROM \"Телеканал\" ORDER BY \"Название\"";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxChannel.DisplayMember = "Название";
                    comboBoxChannel.ValueMember = "id_канала";
                    comboBoxChannel.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке каналов: " + ex.Message);
            }
        }

        private void LoadPackageChannelRelations()
        {
            try
            {
                using (connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT pc.id_связи, p.""Название"" AS Пакет, c.""Название"" AS Канал, 
                                    pc.id_пакета, pc.id_канала
                                    FROM ""Пакет_Канал"" pc
                                    JOIN ""Пакет"" p ON pc.id_пакета = p.id_пакета
                                    JOIN ""Телеканал"" c ON pc.id_канала = c.id_канала
                                    ORDER BY p.""Название"", c.""Название""";

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
                    dtRelations = new DataTable();
                    da.Fill(dtRelations);

                    datapackagechannel.DataSource = dtRelations;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке связей: " + ex.Message);
            }
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            if (comboBoxPackage.SelectedValue == null || comboBoxChannel.SelectedValue == null)
            {
                MessageBox.Show("Выберите пакет и канал");
                return;
            }

            try
            {
                using (connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO ""Пакет_Канал"" (id_пакета, id_канала) 
                                     VALUES (@packageId, @channelId)";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@packageId", comboBoxPackage.SelectedValue);
                    cmd.Parameters.AddWithValue("@channelId", comboBoxChannel.SelectedValue);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Связь успешно добавлена");
                        LoadPackageChannelRelations();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }

        private void buttondel_Click(object sender, EventArgs e)
        {
            if (datapackagechannel.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите связь для удаления");
                return;
            }

            DataGridViewRow selectedRow = datapackagechannel.SelectedRows[0];
            int relationId = Convert.ToInt32(selectedRow.Cells["id_связи"].Value);

            try
            {
                using (connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM \"Пакет_Канал\" WHERE id_связи = @relationId";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@relationId", relationId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Связь успешно удалена");
                        LoadPackageChannelRelations();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении связи: " + ex.Message);
            }
        }

        private void buttonchg_Click_1(object sender, EventArgs e)
        {
            if (datapackagechannel.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите связь для изменения");
                return;
            }

            if (comboBoxPackage.SelectedValue == null || comboBoxChannel.SelectedValue == null)
            {
                MessageBox.Show("Выберите новый пакет и канал");
                return;
            }

            DataGridViewRow selectedRow = datapackagechannel.SelectedRows[0];
            int relationId = Convert.ToInt32(selectedRow.Cells["id_связи"].Value);
            int newPackageId = Convert.ToInt32(comboBoxPackage.SelectedValue);
            int newChannelId = Convert.ToInt32(comboBoxChannel.SelectedValue);

            try
            {
                using (connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверка на существующую связь
                    string checkQuery = "SELECT COUNT(*) FROM \"Пакет_Канал\" WHERE id_пакета = @packageId AND id_канала = @channelId AND id_связи != @relationId";
                    NpgsqlCommand checkCmd = new NpgsqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@packageId", newPackageId);
                    checkCmd.Parameters.AddWithValue("@channelId", newChannelId);
                    checkCmd.Parameters.AddWithValue("@relationId", relationId);

                    long count = (long)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Эта связь уже существует");
                        return;
                    }

                    // Обновление связи
                    string updateQuery = "UPDATE \"Пакет_Канал\" SET id_пакета = @packageId, id_канала = @channelId WHERE id_связи = @relationId";
                    NpgsqlCommand updateCmd = new NpgsqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@packageId", newPackageId);
                    updateCmd.Parameters.AddWithValue("@channelId", newChannelId);
                    updateCmd.Parameters.AddWithValue("@relationId", relationId);

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Связь успешно изменена");
                        LoadPackageChannelRelations();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении связи: " + ex.Message);
            }
        }

        private void datapackagechannel_SelectionChanged(object sender, EventArgs e)
        {
            if (datapackagechannel.SelectedRows.Count > 0)
            {
                DataGridViewRow row = datapackagechannel.SelectedRows[0];
                comboBoxPackage.SelectedValue = row.Cells["id_пакета"].Value;
                comboBoxChannel.SelectedValue = row.Cells["id_канала"].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Package newForm = new Package();
            newForm.Show();
        }
    }
}