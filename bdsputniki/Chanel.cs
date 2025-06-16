using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // или Npgsql для PostgreSQL

namespace bdsputniki
{
    public partial class Chanel : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        private NpgsqlConnection connection;
        private DataSet dataSet;
        private NpgsqlDataAdapter dataAdapter;
        private NpgsqlCommandBuilder commandBuilder;
        public Chanel()
        {
            InitializeComponent();
        }

        private void datapackage_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Chanel_Load(object sender, EventArgs e)
        {
            LoadData();
            datachannels.CellClick += datapackage_CellContentClick;
        }
        private void LoadData()
        {
            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                dataAdapter = new NpgsqlDataAdapter("SELECT * FROM Телеканал", connection);
                commandBuilder = new NpgsqlCommandBuilder(dataAdapter);

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Телеканал");

                datachannels.DataSource = dataSet.Tables["Телеканал"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        

        private void datapackage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && datachannels.Rows[e.RowIndex].Cells["Номер_канала"].Value != null)
            {
                DataGridViewRow row = datachannels.Rows[e.RowIndex];

                textBoxnbr.Text = row.Cells["Номер_канала"].Value.ToString();
                textBoxtype.Text = row.Cells["Тип_контента"].Value.ToString();
                textBoxname.Text = row.Cells["Название"].Value.ToString();

               
            }
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO \"Телеканал\" (\"Номер_канала\", \"Тип_контента\", \"Название\") " +
                               "VALUES (@number, @type_content, @name)";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    // Convert text to integer for channel number
                    if (!int.TryParse(textBoxnbr.Text, out int channelNumber))
                    {
                        MessageBox.Show("Пожалуйста, введите числовое значение для номера канала");
                        return;
                    }

                    cmd.Parameters.AddWithValue("number", channelNumber);
                    cmd.Parameters.AddWithValue("type_content", textBoxtype.Text);
                    cmd.Parameters.AddWithValue("name", textBoxname.Text);

                    cmd.ExecuteNonQuery();
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }

        private void buttonchg_Click(object sender, EventArgs e)
        {
            if (datachannels.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(datachannels.SelectedRows[0].Cells["id_канала"].Value);

                try
                {
                    string query = "UPDATE \"Телеканал\" SET " +
                                  "\"Номер_канала\" = @number, " +
                                  "\"Тип_контента\" = @type_content, " +
                                  "\"Название\" = @name " +
                                  "WHERE \"id_канала\" = @id";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        if (!int.TryParse(textBoxnbr.Text, out int channelNumber))
                        {
                            MessageBox.Show("Пожалуйста, введите числовое значение для номера канала");
                            return;
                        }

                        cmd.Parameters.AddWithValue("number", channelNumber);
                        cmd.Parameters.AddWithValue("type_content", textBoxtype.Text);
                        cmd.Parameters.AddWithValue("name", textBoxname.Text);
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
            if (datachannels.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(datachannels.SelectedRows[0].Cells["id_канала"].Value);

                try
                {
                    string query = "DELETE FROM \"Телеканал\" WHERE \"id_канала\" = @id";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }

                    LoadData();
                    MessageBox.Show("Запись успешно удалена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления");
            }
        }

        private void buttonManagePackages_Click(object sender, EventArgs e)
        {
            if (datachannels.SelectedRows.Count > 0)
            {
                package_chanel form = new package_chanel();
                form.ShowDialog();
                // После закрытия формы обновляем данные
               
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите канал для управления пакетами");
            }
        }

        private void textBoxnbr_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadPackageChannelData()
        {
            // Замените строку подключения на свою!
            string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputniki";
            string query = "SELECT * FROM Пакет_Канал";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                datachannels.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
        }
    }
}
