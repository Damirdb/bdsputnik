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

namespace bdsputniki
{
    public partial class Package : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        private NpgsqlConnection connection;
        private DataSet dataSet;
        private NpgsqlDataAdapter dataAdapter;
        private NpgsqlCommandBuilder commandBuilder;
        public Package()
        {
            InitializeComponent();
        }

        private void Package_Load(object sender, EventArgs e)
        {
            LoadData();
            datapackage.CellClick += datapackage_CellContentClick;
        }
        private void LoadData()
        {
            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                dataAdapter = new NpgsqlDataAdapter("SELECT * FROM Пакет", connection);
                commandBuilder = new NpgsqlCommandBuilder(dataAdapter);

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Пакет");

                datapackage.DataSource = dataSet.Tables["Пакет"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void datapackage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && datapackage.Rows[e.RowIndex].Cells["Название"].Value != null)
            {
                DataGridViewRow row = datapackage.Rows[e.RowIndex];

                textBoxname.Text = row.Cells["Название"].Value.ToString();



            }
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO \"Пакет\" (\"Название\") " +
               "VALUES (@name)";


                using (var cmd = new NpgsqlCommand(query, connection))
                {
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
            if (datapackage.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(datapackage.SelectedRows[0].Cells["id_пакета"].Value);

                try
                {
                    string query = "UPDATE \"Пакет\" SET \"Название\" =@name WHERE \"id_пакета\" = @id";


                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
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
            if (datapackage.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(datapackage.SelectedRows[0].Cells["id_пакета"].Value);

                try
                {
                    string query = "DELETE FROM \"Пакет\" WHERE \"id_пакета\" = @id";


                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
        }

        private void textBoxname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
        }

        private void buttonaddchn_Click(object sender, EventArgs e)
        {
            package_chanel newForm = new package_chanel();
            newForm.Show();
        }
    }
}
