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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;



namespace bdsputniki
{
    public partial class Client : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        private NpgsqlConnection connection;
        private DataSet dataSet;
        private NpgsqlDataAdapter dataAdapter;
        private NpgsqlCommandBuilder commandBuilder;
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            LoadData();
            dataclient.CellClick += dataclient_CellClick;

        }

        private void LoadData()
        {
            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                dataAdapter = new NpgsqlDataAdapter("SELECT * FROM Клиент", connection);
                commandBuilder = new NpgsqlCommandBuilder(dataAdapter);

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Клиент");

                dataclient.DataSource = dataSet.Tables["Клиент"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void dataclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxfio_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxaddrs_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxphn_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxsrlpasp_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxnmbrpasp_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataclient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataclient.Rows[e.RowIndex].Cells["ФИО"].Value != null)
            {
                DataGridViewRow row = dataclient.Rows[e.RowIndex];

                textBoxfio.Text = row.Cells["ФИО"].Value.ToString();
                textBoxaddrs.Text = row.Cells["Адрес"].Value.ToString();
                textBoxphn.Text = row.Cells["Телефон"].Value.ToString();
                textBoxmail.Text = row.Cells["Почта"].Value.ToString();
                textBoxsrlpasp.Text = row.Cells["Серия_паспорта"].Value.ToString();
                textBoxnmbrpasp.Text = row.Cells["Номер_паспорта"].Value.ToString();

            }
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO \"Клиент\" (\"ФИО\", \"Адрес\", \"Телефон\", \"Почта\", \"Серия_паспорта\", \"Номер_паспорта\", \"Дата_регистрации\") " +
               "VALUES (@fio, @address, @phone, @email, @passport_series, @passport_number, @reg_date)";


                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("fio", textBoxfio.Text);
                    cmd.Parameters.AddWithValue("address", textBoxaddrs.Text);
                    cmd.Parameters.AddWithValue("phone", textBoxphn.Text);
                    cmd.Parameters.AddWithValue("email", textBoxmail.Text);
                    cmd.Parameters.AddWithValue("passport_series", textBoxsrlpasp.Text);
                    cmd.Parameters.AddWithValue("passport_number", textBoxnmbrpasp.Text);
                    cmd.Parameters.AddWithValue("reg_date", DateTime.Now);

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
            if (dataclient.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataclient.SelectedRows[0].Cells["id_клиента"].Value);

                try
                {
                    string query = "UPDATE \"Клиент\" SET \"ФИО\" = @fio, \"Адрес\" = @address, \"Телефон\" = @phone, \"Почта\" = @email, " +
               "\"Серия_паспорта\" = @passport_series, \"Номер_паспорта\" = @passport_number WHERE \"id_клиента\" = @id";


                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("fio", textBoxfio.Text);
                        cmd.Parameters.AddWithValue("address", textBoxaddrs.Text);
                        cmd.Parameters.AddWithValue("phone", textBoxphn.Text);
                        cmd.Parameters.AddWithValue("email", textBoxmail.Text);
                        cmd.Parameters.AddWithValue("passport_series", textBoxsrlpasp.Text);
                        cmd.Parameters.AddWithValue("passport_number", textBoxnmbrpasp.Text);
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
            if (dataclient.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataclient.SelectedRows[0].Cells["id_клиента"].Value);

                try
                {
                    string query = "DELETE FROM \"Клиент\" WHERE \"id_клиента\" = @id";


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

        private void buttonrep_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Получаем выбранную дату
                    DateTime selectedDate = dateTimePicker1.Value.Date;
                    string displayDate = selectedDate.ToString("dd.MM.yyyy");

                    // 1. Запрос для клиентов, зарегистрированных на выбранную дату
                    int selectedDateCount = 0;
                    string selectedDateQuery = @"SELECT COUNT(*) FROM ""Клиент"" 
                        WHERE ""дата_регистрации""::date = @selectedDate";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(selectedDateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@selectedDate", selectedDate);
                        selectedDateCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Запрос для общего количества клиентов
                    int totalCount = 0;
                    string totalQuery = @"SELECT COUNT(*) FROM ""Клиент""";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(totalQuery, connection))
                    {
                        totalCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 3. Создание PDF документа
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string filePath = Path.Combine(desktopPath, $"Отчет_по_клиентам_{selectedDate:yyyyMMdd}.pdf");

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    using (iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30))
                    {
                        iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, fs);
                        pdfDoc.Open();

                        // Настройка шрифтов с поддержкой кириллицы
                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                        var baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, "Identity-H", iTextSharp.text.pdf.BaseFont.EMBEDDED);

                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 12);

                        // Заголовок отчета
                        iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(
                            $"ОТЧЕТ ПО КЛИЕНТАМ\nна {displayDate}",
                            titleFont)
                        {
                            Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                            SpacingAfter = 20
                        };
                        pdfDoc.Add(title);

                        // Таблица с данными
                        iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(2)
                        {
                            WidthPercentage = 90,
                            HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        };

                        // Добавляем заголовки таблицы
                        table.AddCell(new iTextSharp.text.Phrase("Показатель", headerFont));
                        table.AddCell(new iTextSharp.text.Phrase("Значение", headerFont));

                        // Добавляем данные
                        table.AddCell(new iTextSharp.text.Phrase($"Зарегистрировано на {displayDate}:", normalFont));
                        table.AddCell(new iTextSharp.text.Phrase(selectedDateCount.ToString(), normalFont));

                        table.AddCell(new iTextSharp.text.Phrase("Общее количество клиентов:", normalFont));
                        table.AddCell(new iTextSharp.text.Phrase(totalCount.ToString(), normalFont));

                        pdfDoc.Add(table);

                        // Добавляем дату формирования отчета
                        pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));
                        pdfDoc.Add(new iTextSharp.text.Paragraph(
                            $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}",
                            normalFont)
                        {
                            Alignment = iTextSharp.text.Element.ALIGN_RIGHT
                        });

                        pdfDoc.Close();
                    }

                    // Показываем сообщение об успехе
                    MessageBox.Show($"Отчет успешно сформирован и сохранен:\n{filePath}",
                                  "Отчет готов",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка базы данных:\n{ex.Message}",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка работы с файлом:\n{ex.Message}",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка:\n{ex.Message}",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
        }
    }
}
