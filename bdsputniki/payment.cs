using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace bdsputniki
{
    public partial class payment : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
        private DataTable dtPayments;

        public payment()
        {
            InitializeComponent();

            // Инициализация комбобокса статусов
            comboBox2.Items.AddRange(new string[] { "Оплачено", "Ожидание", "Отменено" });
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = 0;

            // Назначаем обработчики событий
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            buttonrep.Click += buttonrep_Click;
            dateTimePicker2.ValueChanged += dateTimePickerReport_ValueChanged;

            LoadPayments();
            LoadContracts();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Настраиваем колонки DataGridView
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_оплаты",
                DataPropertyName = "id_оплаты",
                HeaderText = "ID",
                Visible = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Номер_договора",
                DataPropertyName = "Номер_договора",
                HeaderText = "Номер договора"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Дата_оплаты",
                DataPropertyName = "Дата_оплаты",
                HeaderText = "Дата оплаты"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Сумма",
                DataPropertyName = "Сумма",
                HeaderText = "Сумма"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Статус_оплаты",
                DataPropertyName = "Статус_оплаты",
                HeaderText = "Статус"
            });
        }

        private void LoadPayments()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM ""Оплата"" ORDER BY ""Дата_оплаты"" DESC";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
                dtPayments = new DataTable();
                da.Fill(dtPayments);
                dataGridView1.DataSource = dtPayments;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки оплат: " + ex.Message);
            }
        }

        private void LoadContracts()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                    string query = @"
                        SELECT 
                                d.""Номер_договора"", 
                                d.""ФИО_клиента"", 
                            t.""Название_тарифа"" AS ""Тариф"",
                            tr.""Стоимость""
                            FROM ""Договор"" d
                            JOIN ""Тариф"" t ON d.""id_тарифа"" = t.""id_тарифа""
                        JOIN ""Тарифы_с_расчетом"" tr ON d.""id_тарифа"" = tr.""id_тарифа""
                        WHERE tr.""id_расчета"" = (
                            SELECT MAX(tr2.""id_расчета"") FROM ""Тарифы_с_расчетом"" tr2 WHERE tr2.""id_тарифа"" = d.""id_тарифа""
                        )
                            ORDER BY d.""Номер_договора""";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
                DataTable dtContracts = new DataTable();
                da.Fill(dtContracts);

                comboBox1.DisplayMember = "Номер_договора";
                comboBox1.ValueMember = "Номер_договора";
                comboBox1.DataSource = dtContracts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки договоров: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DataRowView row = (DataRowView)comboBox1.SelectedItem;
                comboBox3.Text = row["Стоимость"].ToString();
            }
        }

        private void buttonadd_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите договор");
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO ""Оплата"" 
                        (""Номер_договора"", ""Дата_оплаты"", ""Сумма"", ""Статус_оплаты"")
                    VALUES (@contractNumber, @paymentDate, @amount, @status)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@contractNumber", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@paymentDate", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@amount", decimal.Parse(comboBox3.Text));
                    cmd.Parameters.AddWithValue("@status", comboBox2.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Оплата успешно добавлена");
                        LoadPayments();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления оплаты: " + ex.Message);
            }
        }

        private void buttondel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int paymentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_оплаты"].Value);

            if (MessageBox.Show("Удалить выбранную оплату?", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM \"Оплата\" WHERE \"id_оплаты\" = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", paymentId);
                        cmd.ExecuteNonQuery();
                    }
                    LoadPayments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
        }

        private void buttonchg_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите оплату для изменения");
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        UPDATE ""Оплата"" 
                        SET ""Статус_оплаты"" = @status
                        WHERE ""id_оплаты"" = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@status", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@id",
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_оплаты"].Value));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Статус оплаты успешно изменен");
                            LoadPayments();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка изменения статуса оплаты: " + ex.Message);
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
                    DateTime selectedDate = dateTimePicker2.Value.Date;
                    string displayDate = selectedDate.ToString("dd.MM.yyyy");

                    // Запрос для выборки оплат на выбранную дату
                    string query = @"
                        SELECT 
                            o.""id_оплаты"" AS ""ID"",
                            o.""Номер_договора"" AS ""Номер договора"",
                            o.""Дата_оплаты"" AS ""Дата оплаты"",
                            o.""Сумма"" AS ""Сумма"",
                            o.""Статус_оплаты"" AS ""Статус"",
                            d.""ФИО_клиента"" AS ""Клиент""
                        FROM ""Оплата"" o
                        LEFT JOIN ""Договор"" d ON o.""Номер_договора"" = d.""Номер_договора""
                        WHERE o.""Дата_оплаты""::date = @selectedDate
                        ORDER BY o.""Дата_оплаты"" DESC
                    ";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@selectedDate", selectedDate);
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Подготовка PDF
                            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            string filePath = System.IO.Path.Combine(desktopPath, $"Отчет_по_оплатам_{selectedDate:yyyyMMdd}.pdf");

                            using (FileStream fs = new FileStream(filePath, FileMode.Create))
                            using (iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30))
                            {
                                iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, fs);
                                pdfDoc.Open();

                                // Шрифт с поддержкой кириллицы
                                string fontPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                                var baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
                                var titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                                var headerFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                                var normalFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                                // Заголовок
                                var title = new iTextSharp.text.Paragraph($"ОТЧЕТ ПО ОПЛАТАМ\nна {displayDate}", titleFont)
                                {
                                    Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                                    SpacingAfter = 20
                                };
                                pdfDoc.Add(title);

                                pdfDoc.Add(new iTextSharp.text.Paragraph($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}", normalFont));
                                pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                                // Таблица
                                var table = new iTextSharp.text.pdf.PdfPTable(6)
                                {
                                    WidthPercentage = 100
                                };
                                table.SetWidths(new float[] { 1f, 2f, 2f, 2f, 2f, 2f });

                                // Заголовки
                                string[] headers = { "ID", "Номер договора", "Дата оплаты", "Сумма", "Статус", "Клиент" };
                                foreach (var h in headers)
                                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(h, headerFont)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });

                                // Данные
                                decimal totalSum = 0;
                                int count = 0;
                                while (reader.Read())
                                {
                                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(reader["ID"].ToString(), normalFont)));
                                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(reader["Номер договора"].ToString(), normalFont)));
                                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(Convert.ToDateTime(reader["Дата оплаты"]).ToString("dd.MM.yyyy"), normalFont)));
                                    string sumStr = reader["Сумма"]?.ToString() ?? "0";
                                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sumStr, normalFont)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(reader["Статус"]?.ToString() ?? "", normalFont)));
                                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(reader["Клиент"]?.ToString() ?? "", normalFont)));

                                    decimal sum = 0;
                                    decimal.TryParse(sumStr, out sum);
                                    totalSum += sum;
                                    count++;
                                }

                                pdfDoc.Add(table);

                                // Итоги
                                pdfDoc.Add(new iTextSharp.text.Paragraph($"\nВсего оплат на {displayDate}: {count}", normalFont));
                                pdfDoc.Add(new iTextSharp.text.Paragraph($"Сумма: {totalSum:N2} руб.", headerFont) { Alignment = iTextSharp.text.Element.ALIGN_RIGHT });

                                pdfDoc.Close();
                            }

                            MessageBox.Show($"Отчет успешно сформирован и сохранен:\n{filePath}",
                                          "Отчет готов",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при формировании отчета: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePickerReport_ValueChanged(object sender, EventArgs e)
        {
            buttonrep_Click(sender, e); // Просто вызываем тот же метод
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
        }
    }
}