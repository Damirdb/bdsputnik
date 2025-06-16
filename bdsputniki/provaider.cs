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
    public partial class provaider : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        private NpgsqlConnection connection;
        private DataSet dataSet;
        private NpgsqlDataAdapter dataAdapter;
        private NpgsqlCommandBuilder commandBuilder;
        public provaider()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void provaider_Load(object sender, EventArgs e)
        {
            LoadData();
            dataprovaider.CellClick += dataprovaider_CellClick;
        }
        private void LoadData()
        {
            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                dataAdapter = new NpgsqlDataAdapter("SELECT * FROM Провайдер", connection);
                commandBuilder = new NpgsqlCommandBuilder(dataAdapter);

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Провайдер");

                dataprovaider.DataSource = dataSet.Tables["Провайдер"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }
        private void dataprovaider_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataprovaider.Rows[e.RowIndex].Cells["Телефон"].Value != null)
            {
                DataGridViewRow row = dataprovaider.Rows[e.RowIndex];

                textBoxphn.Text = row.Cells["Телефон"].Value.ToString();
                textBoxmail.Text = row.Cells["Почта"].Value.ToString();
                textBoxcountry.Text = row.Cells["Страна"].Value.ToString();
                textBoxkpp.Text = row.Cells["КПП"].Value.ToString();
                textBoxinn.Text = row.Cells["ИНН"].Value.ToString();
                textBoxogrn.Text = row.Cells["ОГРН"].Value.ToString();
                textBoxbik.Text = row.Cells["БИК"].Value.ToString();
                textBoxname.Text = row.Cells["Наименование"].Value.ToString();



            }
        }

        private void dataprovaider_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO \"Провайдер\" (\"Телефон\", \"Почта\", \"Страна\", \"КПП\", \"ИНН\", \"ОГРН\", \"БИК\", \"Наименование\") " +
               "VALUES (@phone, @mail, @country, @kpp, @inn, @ogrn, @bik, @name)";


                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("phone", textBoxphn.Text);
                    cmd.Parameters.AddWithValue("mail", textBoxmail.Text);
                    cmd.Parameters.AddWithValue("country", textBoxcountry.Text);
                    cmd.Parameters.AddWithValue("kpp", textBoxkpp.Text);
                    cmd.Parameters.AddWithValue("inn", textBoxinn.Text);
                    cmd.Parameters.AddWithValue("ogrn", textBoxogrn.Text);
                    cmd.Parameters.AddWithValue("bik", textBoxbik.Text);
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

        private void buttonchn_Click(object sender, EventArgs e)
        {
            if (dataprovaider.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataprovaider.SelectedRows[0].Cells["id_провайдера"].Value);

                try
                {
                    string query = "UPDATE \"Провайдер\" SET \"Телефон\" = @phone, \"Почта\" = @mail, \"Страна\" = @country, \"КПП\" = @kpp, " +
               "\"ИНН\" = @inn, \"ОГРН\" = @ogrn, \"БИК\" = @bik, \"Наименование\" =@name WHERE \"id_провайдера\" = @id";


                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("phone", textBoxphn.Text);
                        cmd.Parameters.AddWithValue("mail", textBoxmail.Text);
                        cmd.Parameters.AddWithValue("country", textBoxcountry.Text);
                        cmd.Parameters.AddWithValue("kpp", textBoxkpp.Text);
                        cmd.Parameters.AddWithValue("inn", textBoxinn.Text);
                        cmd.Parameters.AddWithValue("ogrn", textBoxogrn.Text);
                        cmd.Parameters.AddWithValue("bik", textBoxbik.Text);
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
            if (dataprovaider.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataprovaider.SelectedRows[0].Cells["id_провайдера"].Value);

                try
                {
                    string query = "DELETE FROM \"Провайдер\" WHERE \"id_провайдера\" = @id";


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

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
        }
    }
}
