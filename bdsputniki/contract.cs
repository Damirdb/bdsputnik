using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;

namespace bdsputniki
{
    public partial class contract : Form
    {
        private NpgsqlConnection connection;
        private DataTable dtRelations;
        private string currentFilter = "";
        private Button buttonFilters;
        private string lastFilterSql = "";

        public contract()
        {
            InitializeComponent();

            // Замените строку подключения на вашу!
            string connString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
            connection = new NpgsqlConnection(connString);

            LoadContracts();
            LoadComboBoxes();

            buttonadd.Click += buttonadd_Click;
            buttondel.Click += buttondel_Click;
            buttonchg.Click += buttonchg_Click_1;
            dataclient.SelectionChanged += dataclient_SelectionChanged;
            buttonall.Click += buttonall_Click;
            buttoncurrent.Click += buttoncurrent_Click;
            buttondisactive.Click += buttondisactive_Click;

            comboBoxnameprovaider.SelectedIndexChanged += comboBoxnameprovaider_SelectedIndexChanged;
            comboBoxnametarif.SelectedIndexChanged += comboBoxnametarif_SelectedIndexChanged;
        }

        // Загрузка всех договоров в таблицу
        private void LoadContracts()
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        ""Номер_договора"",
                        ""Дата_заключения"",
                        ""Срок_заключения"",
                        ""Тип_оборудования"",
                        ""ФИО_клиента"",
                        ""Наименование_провайдера"",
                        ""Название_тарифа""
                    FROM ""Договор""
                    WHERE
                        (CAST(""Номер_договора"" AS TEXT) ILIKE @q OR
                        ""ФИО_клиента"" ILIKE @q OR
                        ""Наименование_провайдера"" ILIKE @q OR
                        ""Название_тарифа"" ILIKE @q OR
                        ""Тип_оборудования"" ILIKE @q OR
                        TO_CHAR(""Дата_заключения"", 'DD.MM.YYYY') ILIKE @q)
                        " + currentFilter + @"
                    ORDER BY ""Дата_заключения"" DESC";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@q", "%" + textBoxsearch.Text.Trim() + "%");
                dtRelations = new DataTable();
                adapter.Fill(dtRelations);
                dataclient.DataSource = dtRelations;
            }
        }

        // Заполнение комбобоксов
        private void LoadComboBoxes()
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();

                // Клиенты
                NpgsqlDataAdapter adapterClient = new NpgsqlDataAdapter("SELECT \"id_клиента\", \"ФИО\" FROM \"Клиент\"", conn);
                DataTable dtClient = new DataTable();
                adapterClient.Fill(dtClient);
                
                // Добавляем пустую строку
                DataRow emptyRowClient = dtClient.NewRow();
                emptyRowClient["id_клиента"] = DBNull.Value;
                emptyRowClient["ФИО"] = "Все клиенты";
                dtClient.Rows.InsertAt(emptyRowClient, 0);
                
                comboBoxnameclient.DataSource = dtClient;
                comboBoxnameclient.DisplayMember = "ФИО";
                comboBoxnameclient.ValueMember = "id_клиента";

                // Провайдеры
                NpgsqlDataAdapter adapterProv = new NpgsqlDataAdapter(@"SELECT ""id_провайдера"", ""Наименование"" FROM ""Провайдер""", conn);
                DataTable dtProv = new DataTable();
                adapterProv.Fill(dtProv);
                
                // Добавляем пустую строку
                DataRow emptyRow = dtProv.NewRow();
                emptyRow["id_провайдера"] = DBNull.Value;
                emptyRow["Наименование"] = "Все провайдеры";
                dtProv.Rows.InsertAt(emptyRow, 0);
                
                comboBoxnameprovaider.DataSource = dtProv;
                comboBoxnameprovaider.DisplayMember = "Наименование";
                comboBoxnameprovaider.ValueMember = "id_провайдера";

                // Тарифы
                NpgsqlDataAdapter adapterTariff = new NpgsqlDataAdapter(@"SELECT ""id_тарифа"", ""Название_тарифа"" FROM ""Тариф""", conn);
                DataTable dtTariff = new DataTable();
                adapterTariff.Fill(dtTariff);
                
                // Добавляем пустую строку
                DataRow emptyRowTariff = dtTariff.NewRow();
                emptyRowTariff["id_тарифа"] = DBNull.Value;
                emptyRowTariff["Название_тарифа"] = "Все тарифы";
                dtTariff.Rows.InsertAt(emptyRowTariff, 0);
                
                comboBoxnametarif.DataSource = dtTariff;
                comboBoxnametarif.DisplayMember = "Название_тарифа";
                comboBoxnametarif.ValueMember = "id_тарифа";

                
                // Тип оборудования из Спутниковая_станция
                NpgsqlDataAdapter adapterStation = new NpgsqlDataAdapter("SELECT \"id_станции\", \"Тип_оборудования\" FROM \"Спутниковая_станция\"", conn);
                DataTable dtStation = new DataTable();
                adapterStation.Fill(dtStation);
                
                // Добавляем пустую строку
                DataRow emptyRowStation = dtStation.NewRow();
                emptyRowStation["id_станции"] = DBNull.Value;
                emptyRowStation["Тип_оборудования"] = "Все типы";
                dtStation.Rows.InsertAt(emptyRowStation, 0);
                
                comboBoxtype.DataSource = dtStation;
                comboBoxtype.DisplayMember = "Тип_оборудования";
                comboBoxtype.ValueMember = "id_станции";
            }
        }

        // Добавление договора
        private void buttonadd_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO ""Договор"" 
                        (""Дата_заключения"", ""Срок_заключения"", ""Тип_оборудования"", ""ФИО_клиента"", ""Наименование_провайдера"", ""Название_тарифа"", ""id_станции"", ""id_клиента"", ""id_провайдера"", ""id_тарифа"")
                    VALUES (@date, @term, @type, @fio, @prov, @tariff, @station, @client, @provider, @tariffid)
                ";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", dateTimePickerdateofconclusion.Value);
                    TimeSpan interval = dateTimePickertermofimprisonment.Value - dateTimePickerdateofconclusion.Value;
                    cmd.Parameters.Add("@term", NpgsqlDbType.Interval).Value = interval;
                    cmd.Parameters.AddWithValue("@type", comboBoxtype.Text);
                    cmd.Parameters.AddWithValue("@fio", comboBoxnameclient.Text);
                    cmd.Parameters.AddWithValue("@prov", comboBoxnameprovaider.Text);
                    cmd.Parameters.AddWithValue("@tariff", comboBoxnametarif.Text);
                    cmd.Parameters.AddWithValue("@station", comboBoxtype.SelectedValue);
                    cmd.Parameters.AddWithValue("@client", comboBoxnameclient.SelectedValue);
                    cmd.Parameters.AddWithValue("@provider", comboBoxnameprovaider.SelectedValue);
                    cmd.Parameters.AddWithValue("@tariffid", comboBoxnametarif.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadContracts();
        }

        // Удаление договора
        private void buttondel_Click(object sender, EventArgs e)
        {
            if (dataclient.CurrentRow == null) return;
            int contractId = Convert.ToInt32(dataclient.CurrentRow.Cells["Номер_договора"].Value);

            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"DELETE FROM ""Договор"" WHERE ""Номер_договора"" = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", contractId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadContracts();
        }

        // При выборе строки в таблице — заполнить поля для редактирования
        private void dataclient_SelectionChanged(object sender, EventArgs e)
        {
            if (dataclient.CurrentRow == null) return;

            object dateValue = dataclient.CurrentRow.Cells["Дата_заключения"].Value;
            object termValue = dataclient.CurrentRow.Cells["Срок_заключения"].Value;

            if (dateValue != DBNull.Value && termValue != DBNull.Value)
            {
                DateTime startDate = Convert.ToDateTime(dateValue);
                TimeSpan interval = (TimeSpan)termValue;
                dateTimePickerdateofconclusion.Value = startDate;
                dateTimePickertermofimprisonment.Value = startDate.Add(interval);
            }
            else
            {
                dateTimePickerdateofconclusion.Value = DateTime.Now;
                dateTimePickertermofimprisonment.Value = DateTime.Now;
            }

            comboBoxtype.Text = dataclient.CurrentRow.Cells["Тип_оборудования"].Value?.ToString() ?? "";
            comboBoxnameclient.Text = dataclient.CurrentRow.Cells["ФИО_клиента"].Value?.ToString() ?? "";
            comboBoxnameprovaider.Text = dataclient.CurrentRow.Cells["Наименование_провайдера"].Value?.ToString() ?? "";
        }

        // Обработчик выбора провайдера
        private void comboBoxnameprovaider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxnameprovaider.SelectedItem is DataRowView row)
            {
                string providerName = row["Наименование"].ToString();
                int idProvider = Convert.ToInt32(row["id_провайдера"]);
                // Здесь можно использовать providerName и idProvider по вашему сценарию
            }
        }

        // Обработчик выбора тарифа
        private void comboBoxnametarif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxnametarif.SelectedItem is DataRowView row)
            {
                string tariffName = row["Название_тарифа"].ToString();
                int idTariff = Convert.ToInt32(row["id_тарифа"]);
                // Здесь можно использовать tariffName и idTariff по вашему сценарию
            }
        }

        private void dateTimePickertermofimprisonment_ValueChanged(object sender, EventArgs e)
        {
            // Здесь можно реализовать нужную вам логику при изменении значения срока заключения
        }

        private void buttonchg_Click_1(object sender, EventArgs e)
        {
            if (dataclient.CurrentRow == null) return;
            int contractId = Convert.ToInt32(dataclient.CurrentRow.Cells["Номер_договора"].Value);

            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"
                    UPDATE ""Договор"" SET 
                        ""Дата_заключения"" = @date, 
                        ""Срок_заключения"" = @term, 
                        ""Тип_оборудования"" = @type, 
                        ""ФИО_клиента"" = @fio,
                        ""Наименование_провайдера"" = @prov,
                        ""Название_тарифа"" = @tariff,
                        ""id_станции"" = @station,
                        ""id_клиента"" = @idClient, 
                        ""id_провайдера"" = @idProv,
                        ""id_тарифа"" = @idTariff
                    WHERE ""Номер_договора"" = @id
                ";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", dateTimePickerdateofconclusion.Value);
                    TimeSpan interval = dateTimePickertermofimprisonment.Value - dateTimePickerdateofconclusion.Value;
                    cmd.Parameters.Add("@term", NpgsqlDbType.Interval).Value = interval;
                    cmd.Parameters.AddWithValue("@type", comboBoxtype.Text);
                    cmd.Parameters.AddWithValue("@fio", comboBoxnameclient.Text);
                    cmd.Parameters.AddWithValue("@prov", comboBoxnameprovaider.Text);
                    cmd.Parameters.AddWithValue("@tariff", comboBoxnametarif.Text);
                    cmd.Parameters.AddWithValue("@station", comboBoxtype.SelectedValue);
                    cmd.Parameters.AddWithValue("@idClient", comboBoxnameclient.SelectedValue);
                    cmd.Parameters.AddWithValue("@idProv", comboBoxnameprovaider.SelectedValue);
                    cmd.Parameters.AddWithValue("@idTariff", comboBoxnametarif.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", contractId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadContracts();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            menu newForm = new menu();
            newForm.Show();
        }

        private void textBoxsearch_TextChanged(object sender, EventArgs e)
        {
            LoadContracts();
        }

        private void buttonall_Click(object sender, EventArgs e)
        {
            currentFilter = "";
            LoadContracts();
        }

        private void buttoncurrent_Click(object sender, EventArgs e)
        {
            currentFilter = @" AND ""Дата_заключения"" <= CURRENT_DATE 
                             AND (""Дата_заключения"" + ""Срок_заключения"") >= CURRENT_DATE";
            LoadContracts();
        }

        private void buttondisactive_Click(object sender, EventArgs e)
        {
            currentFilter = @" AND (""Дата_заключения"" + ""Срок_заключения"") < CURRENT_DATE";
            LoadContracts();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            FiltersDialog dlg = new FiltersDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filterSql = dlg.GetFilterSql();
                LoadContractsWithCustomFilter(filterSql);
            }
        }

        private void buttonFilters_Click(object sender, EventArgs e)
        {
            FiltersDialog dlg = new FiltersDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lastFilterSql = dlg.GetFilterSql();
                LoadContractsWithCustomFilter(lastFilterSql);
            }
        }

        private void LoadContractsWithCustomFilter(string filterSql)
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        ""Номер_договора"",
                        ""Дата_заключения"",
                        ""Срок_заключения"",
                        ""Тип_оборудования"",
                        ""ФИО_клиента"",
                        ""Наименование_провайдера"",
                        ""Название_тарифа""
                    FROM ""Договор""
                    WHERE
                        (CAST(""Номер_договора"" AS TEXT) ILIKE @q OR
                        ""ФИО_клиента"" ILIKE @q OR
                        ""Наименование_провайдера"" ILIKE @q OR
                        ""Название_тарифа"" ILIKE @q OR
                        ""Тип_оборудования"" ILIKE @q OR
                        TO_CHAR(""Дата_заключения"", 'DD.MM.YYYY') ILIKE @q)
                        " + filterSql + @"
                    ORDER BY ""Дата_заключения"" DESC";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@q", "%" + textBoxsearch.Text.Trim() + "%");
                dtRelations = new DataTable();
                adapter.Fill(dtRelations);
                dataclient.DataSource = dtRelations;
            }
        }

        private void buttonFilter_Click_1(object sender, EventArgs e)
        {
            FiltersDialog dlg = new FiltersDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lastFilterSql = dlg.GetFilterSql();
                LoadContractsWithCustomFilter(lastFilterSql);
            }
        }
    }

    // Форма расширенного поиска
    public class AdvancedSearchForm : Form
    {
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbProvider;
        private ComboBox cmbTariff;
        private ComboBox cmbClient;
        private ComboBox cmbEquipment;
        private CheckBox chkActiveOnly;
        private CheckBox chkExpiredOnly;
        private Button btnSearch;
        private Button btnCancel;
        private Button btnReset;
        private DataGridView dgvResults;
        private NpgsqlConnection connection;

        public AdvancedSearchForm()
        {
            InitializeComponents();
            LoadComboBoxes();
            LoadFilteredResults(); // Загружаем все договоры при открытии
        }

        private void InitializeComponents()
        {
            this.Text = "Фильтр договоров";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            // Строка подключения
            string connString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
            connection = new NpgsqlConnection(connString);

            // Панель фильтров
            Panel filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;

            dgvResults = new DataGridView();
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.ReadOnly = true;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(dgvResults);
            this.Controls.Add(filterPanel);

            // Дата начала
            Label lblStartDate = new Label();
            lblStartDate.Text = "Дата начала периода:";
            lblStartDate.Location = new System.Drawing.Point(20, 20);
            lblStartDate.Size = new System.Drawing.Size(150, 20);

            dtpStartDate = new DateTimePicker();
            dtpStartDate.Location = new System.Drawing.Point(180, 20);
            dtpStartDate.Size = new System.Drawing.Size(180, 20);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.CustomFormat = " ";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.ValueChanged += DtpStartDate_ValueChanged;
            dtpStartDate.Value = DateTime.Now;

            // Дата окончания
            Label lblEndDate = new Label();
            lblEndDate.Text = "Дата окончания периода:";
            lblEndDate.Location = new System.Drawing.Point(20, 50);
            lblEndDate.Size = new System.Drawing.Size(150, 20);

            dtpEndDate = new DateTimePicker();
            dtpEndDate.Location = new System.Drawing.Point(180, 50);
            dtpEndDate.Size = new System.Drawing.Size(180, 20);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.CustomFormat = " ";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.ValueChanged += DtpEndDate_ValueChanged;
            dtpEndDate.Value = DateTime.Now;

            // Провайдер
            Label lblProvider = new Label();
            lblProvider.Text = "Провайдер:";
            lblProvider.Location = new System.Drawing.Point(20, 80);
            lblProvider.Size = new System.Drawing.Size(150, 20);

            cmbProvider = new ComboBox();
            cmbProvider.Location = new System.Drawing.Point(180, 80);
            cmbProvider.Size = new System.Drawing.Size(180, 20);
            cmbProvider.DropDownStyle = ComboBoxStyle.DropDownList;

            // Тариф
            Label lblTariff = new Label();
            lblTariff.Text = "Тариф:";
            lblTariff.Location = new System.Drawing.Point(20, 110);
            lblTariff.Size = new System.Drawing.Size(150, 20);

            cmbTariff = new ComboBox();
            cmbTariff.Location = new System.Drawing.Point(180, 110);
            cmbTariff.Size = new System.Drawing.Size(180, 20);
            cmbTariff.DropDownStyle = ComboBoxStyle.DropDownList;

            // Клиент
            Label lblClient = new Label();
            lblClient.Text = "Клиент:";
            lblClient.Location = new System.Drawing.Point(20, 140);
            lblClient.Size = new System.Drawing.Size(150, 20);

            cmbClient = new ComboBox();
            cmbClient.Location = new System.Drawing.Point(180, 140);
            cmbClient.Size = new System.Drawing.Size(180, 20);
            cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;

            // Оборудование
            Label lblEquipment = new Label();
            lblEquipment.Text = "Тип оборудования:";
            lblEquipment.Location = new System.Drawing.Point(20, 170);
            lblEquipment.Size = new System.Drawing.Size(150, 20);

            cmbEquipment = new ComboBox();
            cmbEquipment.Location = new System.Drawing.Point(180, 170);
            cmbEquipment.Size = new System.Drawing.Size(180, 20);
            cmbEquipment.DropDownStyle = ComboBoxStyle.DropDownList;

            // Чекбоксы
            chkActiveOnly = new CheckBox();
            chkActiveOnly.Text = "Только действующие";
            chkActiveOnly.Location = new System.Drawing.Point(20, 200);
            chkActiveOnly.Size = new System.Drawing.Size(150, 20);

            chkExpiredOnly = new CheckBox();
            chkExpiredOnly.Text = "Только просроченные";
            chkExpiredOnly.Location = new System.Drawing.Point(180, 200);
            chkExpiredOnly.Size = new System.Drawing.Size(150, 20);

            // Кнопки
            btnSearch = new Button();
            btnSearch.Text = "Поиск";
            btnSearch.Location = new System.Drawing.Point(180, 240);
            btnSearch.Size = new System.Drawing.Size(80, 30);
            btnSearch.Click += BtnSearch_Click;

            btnCancel = new Button();
            btnCancel.Text = "Закрыть";
            btnCancel.Location = new System.Drawing.Point(280, 240);
            btnCancel.Size = new System.Drawing.Size(80, 30);
            btnCancel.Click += BtnCancel_Click;

            btnReset = new Button();
            btnReset.Text = "Сбросить";
            btnReset.Location = new System.Drawing.Point(20, 240);
            btnReset.Size = new System.Drawing.Size(80, 30);
            btnReset.Click += BtnReset_Click;

            // Добавление элементов на панель фильтров
            filterPanel.Controls.AddRange(new Control[] {
                lblStartDate, dtpStartDate,
                lblEndDate, dtpEndDate,
                lblProvider, cmbProvider,
                lblTariff, cmbTariff,
                lblClient, cmbClient,
                lblEquipment, cmbEquipment,
                chkActiveOnly, chkExpiredOnly,
                btnSearch, btnCancel, btnReset
            });
        }

        private void LoadComboBoxes()
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();

                // Провайдеры
                NpgsqlDataAdapter adapterProv = new NpgsqlDataAdapter(@"SELECT ""id_провайдера"", ""Наименование"" FROM ""Провайдер""", conn);
                DataTable dtProv = new DataTable();
                adapterProv.Fill(dtProv);
                
                // Добавляем пустую строку
                DataRow emptyRow = dtProv.NewRow();
                emptyRow["id_провайдера"] = DBNull.Value;
                emptyRow["Наименование"] = "Все провайдеры";
                dtProv.Rows.InsertAt(emptyRow, 0);
                
                cmbProvider.DataSource = dtProv;
                cmbProvider.DisplayMember = "Наименование";
                cmbProvider.ValueMember = "id_провайдера";

                // Тарифы
                NpgsqlDataAdapter adapterTariff = new NpgsqlDataAdapter(@"SELECT ""id_тарифа"", ""Название_тарифа"" FROM ""Тариф""", conn);
                DataTable dtTariff = new DataTable();
                adapterTariff.Fill(dtTariff);
                
                // Добавляем пустую строку
                DataRow emptyRowTariff = dtTariff.NewRow();
                emptyRowTariff["id_тарифа"] = DBNull.Value;
                emptyRowTariff["Название_тарифа"] = "Все тарифы";
                dtTariff.Rows.InsertAt(emptyRowTariff, 0);
                
                cmbTariff.DataSource = dtTariff;
                cmbTariff.DisplayMember = "Название_тарифа";
                cmbTariff.ValueMember = "id_тарифа";

                // Клиенты
                NpgsqlDataAdapter adapterClient = new NpgsqlDataAdapter("SELECT \"id_клиента\", \"ФИО\" FROM \"Клиент\"", conn);
                DataTable dtClient = new DataTable();
                adapterClient.Fill(dtClient);
                
                // Добавляем пустую строку
                DataRow emptyRowClient = dtClient.NewRow();
                emptyRowClient["id_клиента"] = DBNull.Value;
                emptyRowClient["ФИО"] = "Все клиенты";
                dtClient.Rows.InsertAt(emptyRowClient, 0);
                
                cmbClient.DataSource = dtClient;
                cmbClient.DisplayMember = "ФИО";
                cmbClient.ValueMember = "id_клиента";

                // Оборудование
                NpgsqlDataAdapter adapterStation = new NpgsqlDataAdapter("SELECT \"id_станции\", \"Тип_оборудования\" FROM \"Спутниковая_станция\"", conn);
                DataTable dtStation = new DataTable();
                adapterStation.Fill(dtStation);
                
                // Добавляем пустую строку
                DataRow emptyRowStation = dtStation.NewRow();
                emptyRowStation["id_станции"] = DBNull.Value;
                emptyRowStation["Тип_оборудования"] = "Все типы";
                dtStation.Rows.InsertAt(emptyRowStation, 0);
                
                cmbEquipment.DataSource = dtStation;
                cmbEquipment.DisplayMember = "Тип_оборудования";
                cmbEquipment.ValueMember = "id_станции";
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadFilteredResults();
        }

        private void LoadFilteredResults()
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string filter = GetFilter();
                
                string query = @"
                    SELECT 
                        ""Номер_договора"",
                        ""Дата_заключения"",
                        ""Срок_заключения"",
                        ""Тип_оборудования"",
                        ""ФИО_клиента"",
                        ""Наименование_провайдера"",
                        ""Название_тарифа""
                    FROM ""Договор""
                    WHERE 1=1 " + filter + @"
                    ORDER BY ""Дата_заключения"" DESC";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvResults.DataSource = dt;

                // Показываем количество найденных записей
                this.Text = $"Фильтр договоров - Найдено: {dt.Rows.Count} записей";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Сброс всех фильтров
            dtpStartDate.CustomFormat = " ";
            dtpEndDate.CustomFormat = " ";
            cmbProvider.SelectedIndex = 0;
            cmbTariff.SelectedIndex = 0;
            cmbClient.SelectedIndex = 0;
            cmbEquipment.SelectedIndex = 0;
            chkActiveOnly.Checked = false;
            chkExpiredOnly.Checked = false;
            
            // Загружаем все договоры после сброса
            LoadFilteredResults();
        }

        public string GetFilter()
        {
            List<string> conditions = new List<string>();

            // Фильтр по периоду - проверяем, что дата была изменена пользователем
            if (dtpStartDate.CustomFormat != " ")
            {
                conditions.Add($@"""Дата_заключения"" >= '{dtpStartDate.Value:yyyy-MM-dd}'");
            }
            if (dtpEndDate.CustomFormat != " ")
            {
                conditions.Add($@"""Дата_заключения"" <= '{dtpEndDate.Value:yyyy-MM-dd}'");
            }

            // Фильтр по провайдеру
            if (cmbProvider.SelectedValue != null && cmbProvider.SelectedValue != DBNull.Value)
            {
                conditions.Add($@"""id_провайдера"" = {cmbProvider.SelectedValue}");
            }

            // Фильтр по тарифу
            if (cmbTariff.SelectedValue != null && cmbTariff.SelectedValue != DBNull.Value)
            {
                conditions.Add($@"""id_тарифа"" = {cmbTariff.SelectedValue}");
            }

            // Фильтр по клиенту
            if (cmbClient.SelectedValue != null && cmbClient.SelectedValue != DBNull.Value)
            {
                conditions.Add($@"""id_клиента"" = {cmbClient.SelectedValue}");
            }

            // Фильтр по оборудованию
            if (cmbEquipment.SelectedValue != null && cmbEquipment.SelectedValue != DBNull.Value)
            {
                conditions.Add($@"""id_станции"" = {cmbEquipment.SelectedValue}");
            }

            // Фильтр по статусу
            if (chkActiveOnly.Checked)
            {
                conditions.Add(@"""Дата_заключения"" <= CURRENT_DATE AND (""Дата_заключения"" + ""Срок_заключения"") >= CURRENT_DATE");
            }
            else if (chkExpiredOnly.Checked)
            {
                conditions.Add(@"""Дата_заключения"" + ""Срок_заключения"" < CURRENT_DATE");
            }

            string result = "";
            if (conditions.Count > 0)
            {
                result = " AND " + string.Join(" AND ", conditions);
            }

            return result;
        }

        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpStartDate.CustomFormat = "dd.MM.yyyy";
        }

        private void DtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.CustomFormat = "dd.MM.yyyy";
        }
    }

    // Добавляю простую форму фильтров
    public class FiltersDialog : Form
    {
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private ComboBox cmbProvider;
        private ComboBox cmbTariff;
        private ComboBox cmbClient;
        private ComboBox cmbEquipment;
        private CheckBox chkActive;
        private CheckBox chkExpired;
        private Button btnSearch;
        private Button btnCancel;
        private string filterSql = "";
        private NpgsqlConnection connection;

        public FiltersDialog()
        {
            this.Text = "Фильтры";
            this.Size = new System.Drawing.Size(400, 320);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            string connString = "Host=localhost;Username=postgres;Password=rootroot;Database=sputnik";
            connection = new NpgsqlConnection(connString);

            Label lblStart = new Label { Text = "Дата с:", Left = 10, Top = 20, Width = 60 };
            dtpStart = new DateTimePicker { Left = 80, Top = 15, Width = 120, Format = DateTimePickerFormat.Custom, CustomFormat = " " };
            dtpStart.ValueChanged += (s, e) => dtpStart.CustomFormat = "dd.MM.yyyy";

            Label lblEnd = new Label { Text = "по:", Left = 210, Top = 20, Width = 30 };
            dtpEnd = new DateTimePicker { Left = 250, Top = 15, Width = 120, Format = DateTimePickerFormat.Custom, CustomFormat = " " };
            dtpEnd.ValueChanged += (s, e) => dtpEnd.CustomFormat = "dd.MM.yyyy";

            Label lblProvider = new Label { Text = "Провайдер:", Left = 10, Top = 60, Width = 80 };
            cmbProvider = new ComboBox { Left = 100, Top = 55, Width = 270, DropDownStyle = ComboBoxStyle.DropDownList };
            Label lblTariff = new Label { Text = "Тариф:", Left = 10, Top = 95, Width = 80 };
            cmbTariff = new ComboBox { Left = 100, Top = 90, Width = 270, DropDownStyle = ComboBoxStyle.DropDownList };
            Label lblClient = new Label { Text = "Клиент:", Left = 10, Top = 130, Width = 80 };
            cmbClient = new ComboBox { Left = 100, Top = 125, Width = 270, DropDownStyle = ComboBoxStyle.DropDownList };
            Label lblEquipment = new Label { Text = "Оборудование:", Left = 10, Top = 165, Width = 80 };
            cmbEquipment = new ComboBox { Left = 100, Top = 160, Width = 270, DropDownStyle = ComboBoxStyle.DropDownList };
            chkActive = new CheckBox { Text = "Только действующие", Left = 10, Top = 200, Width = 150 };
            chkExpired = new CheckBox { Text = "Только просроченные", Left = 170, Top = 200, Width = 150 };
            btnSearch = new Button { Text = "Поиск", Left = 100, Top = 240, Width = 80 };
            btnCancel = new Button { Text = "Отмена", Left = 200, Top = 240, Width = 80 };
            btnSearch.Click += BtnSearch_Click;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] {
                lblStart, dtpStart, lblEnd, dtpEnd,
                lblProvider, cmbProvider,
                lblTariff, cmbTariff,
                lblClient, cmbClient,
                lblEquipment, cmbEquipment,
                chkActive, chkExpired,
                btnSearch, btnCancel
            });
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            using (var conn = new NpgsqlConnection(connection.ConnectionString))
            {
                conn.Open();
                // Провайдеры
                var dtProv = new DataTable();
                new NpgsqlDataAdapter("SELECT \"id_провайдера\", \"Наименование\" FROM \"Провайдер\"", conn).Fill(dtProv);
                var emptyProv = dtProv.NewRow(); emptyProv["id_провайдера"] = DBNull.Value; emptyProv["Наименование"] = "Все провайдеры"; dtProv.Rows.InsertAt(emptyProv, 0);
                cmbProvider.DataSource = dtProv; cmbProvider.DisplayMember = "Наименование"; cmbProvider.ValueMember = "id_провайдера";
                // Тарифы
                var dtTariff = new DataTable();
                new NpgsqlDataAdapter("SELECT \"id_тарифа\", \"Название_тарифа\" FROM \"Тариф\"", conn).Fill(dtTariff);
                var emptyTariff = dtTariff.NewRow(); emptyTariff["id_тарифа"] = DBNull.Value; emptyTariff["Название_тарифа"] = "Все тарифы"; dtTariff.Rows.InsertAt(emptyTariff, 0);
                cmbTariff.DataSource = dtTariff; cmbTariff.DisplayMember = "Название_тарифа"; cmbTariff.ValueMember = "id_тарифа";
                // Клиенты
                var dtClient = new DataTable();
                new NpgsqlDataAdapter("SELECT \"id_клиента\", \"ФИО\" FROM \"Клиент\"", conn).Fill(dtClient);
                var emptyClient = dtClient.NewRow(); emptyClient["id_клиента"] = DBNull.Value; emptyClient["ФИО"] = "Все клиенты"; dtClient.Rows.InsertAt(emptyClient, 0);
                cmbClient.DataSource = dtClient; cmbClient.DisplayMember = "ФИО"; cmbClient.ValueMember = "id_клиента";
                // Оборудование
                var dtStation = new DataTable();
                new NpgsqlDataAdapter("SELECT \"id_станции\", \"Тип_оборудования\" FROM \"Спутниковая_станция\"", conn).Fill(dtStation);
                var emptyStation = dtStation.NewRow(); emptyStation["id_станции"] = DBNull.Value; emptyStation["Тип_оборудования"] = "Все типы"; dtStation.Rows.InsertAt(emptyStation, 0);
                cmbEquipment.DataSource = dtStation; cmbEquipment.DisplayMember = "Тип_оборудования"; cmbEquipment.ValueMember = "id_станции";
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var filters = new List<string>();
            if (dtpStart.CustomFormat != " ")
                filters.Add($@"""Дата_заключения"" >= '{dtpStart.Value:yyyy-MM-dd}'");
            if (dtpEnd.CustomFormat != " ")
                filters.Add($@"""Дата_заключения"" <= '{dtpEnd.Value:yyyy-MM-dd}'");
            if (cmbProvider.SelectedValue != null && cmbProvider.SelectedValue != DBNull.Value)
                filters.Add($@"""id_провайдера"" = {cmbProvider.SelectedValue}");
            if (cmbTariff.SelectedValue != null && cmbTariff.SelectedValue != DBNull.Value)
                filters.Add($@"""id_тарифа"" = {cmbTariff.SelectedValue}");
            if (cmbClient.SelectedValue != null && cmbClient.SelectedValue != DBNull.Value)
                filters.Add($@"""id_клиента"" = {cmbClient.SelectedValue}");
            if (cmbEquipment.SelectedValue != null && cmbEquipment.SelectedValue != DBNull.Value)
                filters.Add($@"""id_станции"" = {cmbEquipment.SelectedValue}");
            if (chkActive.Checked)
                filters.Add(@"""Дата_заключения"" <= CURRENT_DATE AND (""Дата_заключения"" + ""Срок_заключения"") >= CURRENT_DATE");
            if (chkExpired.Checked)
                filters.Add(@"""Дата_заключения"" + ""Срок_заключения"" < CURRENT_DATE");
            filterSql = filters.Count > 0 ? " AND " + string.Join(" AND ", filters) : "";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public string GetFilterSql() => filterSql;
    }
}
