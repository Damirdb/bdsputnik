using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace bdsputniki
{
    public partial class zapros : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        private NpgsqlConnection connection;

        public zapros()
        {
            InitializeComponent();
            connection = new NpgsqlConnection(connectionString);
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Настройка DataGridView
            dataGridViewResults.AutoGenerateColumns = true;
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.MultiSelect = false;

            // Настройка кнопок
            buttonExecute.Click += ButtonExecute_Click;
            buttonClear.Click += ButtonClear_Click;
            buttonSave.Click += ButtonSave_Click;
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxQuery.Text))
                {
                    MessageBox.Show("Введите SQL-запрос", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var adapter = new NpgsqlDataAdapter(textBoxQuery.Text, connection))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewResults.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxQuery.Clear();
            dataGridViewResults.DataSource = null;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.DataSource == null)
            {
                MessageBox.Show("Нет данных для сохранения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var dataTable = (DataTable)dataGridViewResults.DataSource;
                        var csv = new StringBuilder();

                        // Добавляем заголовки
                        var headers = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                        csv.AppendLine(string.Join(",", headers));

                        // Добавляем данные
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var fields = row.ItemArray.Select(field => field.ToString());
                            csv.AppendLine(string.Join(",", fields));
                        }

                        System.IO.File.WriteAllText(saveDialog.FileName, csv.ToString());
                        MessageBox.Show("Данные успешно сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            connection?.Dispose();
        }
    }
}
