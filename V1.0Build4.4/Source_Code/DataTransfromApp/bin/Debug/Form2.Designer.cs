namespace eCommerceInterfaceApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFourcetoExisting = new System.Windows.Forms.Button();
            this.btnLoadDiscnt = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbOrdersOf = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGrayCustomer = new System.Windows.Forms.Button();
            this.btnCheckCustomer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnProduct = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadOrders = new System.Windows.Forms.Button();
            this.Openxls = new System.Windows.Forms.Button();
            this.btnSelectOrders = new System.Windows.Forms.Button();
            this.btnSelectCust = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSheetName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btbGetCust = new System.Windows.Forms.Button();
            this.btnGetOrder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnShowProd = new System.Windows.Forms.Button();
            this.btn_Discount = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShowNewCustbyChn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClearbyChn = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "Load replace master customer ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnFourcetoExisting);
            this.groupBox2.Controls.Add(this.btnLoadDiscnt);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbOrdersOf);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnGrayCustomer);
            this.groupBox2.Controls.Add(this.btnCheckCustomer);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnProduct);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnLoadOrders);
            this.groupBox2.Location = new System.Drawing.Point(10, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 358);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process Transfrom Data  to BPlus ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 227);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "4.1";
            // 
            // btnFourcetoExisting
            // 
            this.btnFourcetoExisting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFourcetoExisting.ForeColor = System.Drawing.Color.Red;
            this.btnFourcetoExisting.Location = new System.Drawing.Point(49, 225);
            this.btnFourcetoExisting.Name = "btnFourcetoExisting";
            this.btnFourcetoExisting.Size = new System.Drawing.Size(169, 23);
            this.btnFourcetoExisting.TabIndex = 35;
            this.btnFourcetoExisting.Text = "Set All Gray area to be Existing ";
            this.btnFourcetoExisting.UseVisualStyleBackColor = false;
            this.btnFourcetoExisting.Click += new System.EventHandler(this.btnFourcetoExisting_Click);
            // 
            // btnLoadDiscnt
            // 
            this.btnLoadDiscnt.Location = new System.Drawing.Point(22, 253);
            this.btnLoadDiscnt.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadDiscnt.Name = "btnLoadDiscnt";
            this.btnLoadDiscnt.Size = new System.Drawing.Size(197, 31);
            this.btnLoadDiscnt.TabIndex = 34;
            this.btnLoadDiscnt.Text = "Load  discount for Lazada";
            this.btnLoadDiscnt.UseVisualStyleBackColor = true;
            this.btnLoadDiscnt.Click += new System.EventHandler(this.btnLoadDiscnt_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 296);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "6";
            // 
            // cmbOrdersOf
            // 
            this.cmbOrdersOf.FormattingEnabled = true;
            this.cmbOrdersOf.Items.AddRange(new object[] {
            "Lazada",
            "Shopee",
            "eCommerce"});
            this.cmbOrdersOf.Location = new System.Drawing.Point(20, 124);
            this.cmbOrdersOf.Name = "cmbOrdersOf";
            this.cmbOrdersOf.Size = new System.Drawing.Size(199, 21);
            this.cmbOrdersOf.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(20, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Channel of Orders :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "5";
            // 
            // btnGrayCustomer
            // 
            this.btnGrayCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGrayCustomer.ForeColor = System.Drawing.Color.Red;
            this.btnGrayCustomer.Location = new System.Drawing.Point(20, 188);
            this.btnGrayCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnGrayCustomer.Name = "btnGrayCustomer";
            this.btnGrayCustomer.Size = new System.Drawing.Size(198, 28);
            this.btnGrayCustomer.TabIndex = 30;
            this.btnGrayCustomer.Text = "Manual adjust gray area customers";
            this.btnGrayCustomer.UseVisualStyleBackColor = false;
            this.btnGrayCustomer.Click += new System.EventHandler(this.btnGrayCustomer_Click);
            // 
            // btnCheckCustomer
            // 
            this.btnCheckCustomer.Location = new System.Drawing.Point(20, 149);
            this.btnCheckCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckCustomer.Name = "btnCheckCustomer";
            this.btnCheckCustomer.Size = new System.Drawing.Size(199, 30);
            this.btnCheckCustomer.TabIndex = 22;
            this.btnCheckCustomer.Text = "Load orders and check customers";
            this.btnCheckCustomer.UseVisualStyleBackColor = true;
            this.btnCheckCustomer.Click += new System.EventHandler(this.btnCheckCustomer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "4";
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(20, 29);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(198, 30);
            this.btnProduct.TabIndex = 20;
            this.btnProduct.Text = "Load replace  product items";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "1";
            // 
            // btnLoadOrders
            // 
            this.btnLoadOrders.Location = new System.Drawing.Point(22, 289);
            this.btnLoadOrders.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadOrders.Name = "btnLoadOrders";
            this.btnLoadOrders.Size = new System.Drawing.Size(197, 30);
            this.btnLoadOrders.TabIndex = 16;
            this.btnLoadOrders.Text = "Transfrom oders file to BPlus";
            this.btnLoadOrders.UseVisualStyleBackColor = true;
            this.btnLoadOrders.Click += new System.EventHandler(this.btnLoadOrders_Click);
            // 
            // Openxls
            // 
            this.Openxls.Location = new System.Drawing.Point(543, 13);
            this.Openxls.Margin = new System.Windows.Forms.Padding(2);
            this.Openxls.Name = "Openxls";
            this.Openxls.Size = new System.Drawing.Size(131, 25);
            this.Openxls.TabIndex = 13;
            this.Openxls.Text = "Test Open Excel";
            this.Openxls.UseVisualStyleBackColor = true;
            this.Openxls.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnSelectOrders
            // 
            this.btnSelectOrders.BackColor = System.Drawing.Color.Blue;
            this.btnSelectOrders.ForeColor = System.Drawing.Color.White;
            this.btnSelectOrders.Location = new System.Drawing.Point(258, 336);
            this.btnSelectOrders.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectOrders.Name = "btnSelectOrders";
            this.btnSelectOrders.Size = new System.Drawing.Size(149, 30);
            this.btnSelectOrders.TabIndex = 14;
            this.btnSelectOrders.Text = "Export Orders To BPlus";
            this.btnSelectOrders.UseVisualStyleBackColor = false;
            this.btnSelectOrders.Click += new System.EventHandler(this.btnSelectOrders_Click);
            // 
            // btnSelectCust
            // 
            this.btnSelectCust.BackColor = System.Drawing.Color.Blue;
            this.btnSelectCust.ForeColor = System.Drawing.Color.White;
            this.btnSelectCust.Location = new System.Drawing.Point(258, 298);
            this.btnSelectCust.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectCust.Name = "btnSelectCust";
            this.btnSelectCust.Size = new System.Drawing.Size(148, 32);
            this.btnSelectCust.TabIndex = 13;
            this.btnSelectCust.Text = "Export New  Cust to BPlus";
            this.btnSelectCust.UseVisualStyleBackColor = false;
            this.btnSelectCust.Click += new System.EventHandler(this.btnSelectCust_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(74, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "Customer Information";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(15, 68);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(659, 597);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txtSheetName
            // 
            this.txtSheetName.Location = new System.Drawing.Point(509, 44);
            this.txtSheetName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSheetName.Name = "txtSheetName";
            this.txtSheetName.Size = new System.Drawing.Size(166, 20);
            this.txtSheetName.TabIndex = 20;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(437, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Sheet Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 46);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Info. Of:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(15, 374);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(377, 404);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Working Folder";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(8, 37);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 19);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.Text = "Refesh Files";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(68, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Click at the file to open  Folder  location";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(189, 61);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(186, 264);
            this.richTextBox1.TabIndex = 26;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.WordWrap = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 60);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(182, 265);
            this.treeView1.TabIndex = 25;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.Color.Blue;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(12, 393);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 34);
            this.button4.TabIndex = 29;
            this.button4.Text = "Report Summary Oders";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(12, 106);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 34);
            this.button2.TabIndex = 24;
            this.button2.Text = "Show master customer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btbGetCust
            // 
            this.btbGetCust.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btbGetCust.BackColor = System.Drawing.Color.Blue;
            this.btbGetCust.ForeColor = System.Drawing.Color.White;
            this.btbGetCust.Location = new System.Drawing.Point(12, 319);
            this.btbGetCust.Margin = new System.Windows.Forms.Padding(2);
            this.btbGetCust.Name = "btbGetCust";
            this.btbGetCust.Size = new System.Drawing.Size(157, 33);
            this.btbGetCust.TabIndex = 26;
            this.btbGetCust.Text = "Show All New  Cust to BPlus";
            this.btbGetCust.UseVisualStyleBackColor = false;
            this.btbGetCust.Click += new System.EventHandler(this.btbGetCust_Click);
            // 
            // btnGetOrder
            // 
            this.btnGetOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGetOrder.BackColor = System.Drawing.Color.Blue;
            this.btnGetOrder.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnGetOrder.ForeColor = System.Drawing.Color.White;
            this.btnGetOrder.Location = new System.Drawing.Point(12, 356);
            this.btnGetOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetOrder.Name = "btnGetOrder";
            this.btnGetOrder.Size = new System.Drawing.Size(157, 34);
            this.btnGetOrder.TabIndex = 27;
            this.btnGetOrder.Text = "Show All Orders to Bplus";
            this.btnGetOrder.UseVisualStyleBackColor = false;
            this.btnGetOrder.Click += new System.EventHandler(this.btnGetOrder_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.Openxls);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtSheetName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(608, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 688);
            this.panel1.TabIndex = 28;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(74, 13);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Maximum = 200;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(382, 19);
            this.progressBar1.TabIndex = 23;
            this.progressBar1.Visible = false;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(12, 189);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(157, 34);
            this.button5.TabIndex = 30;
            this.button5.Text = "Show Cust gray area to adjust";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(12, 150);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 29);
            this.button3.TabIndex = 29;
            this.button3.Text = "Show existing Cust in Orders";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btnShowProd
            // 
            this.btnShowProd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowProd.Location = new System.Drawing.Point(12, 67);
            this.btnShowProd.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowProd.Name = "btnShowProd";
            this.btnShowProd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnShowProd.Size = new System.Drawing.Size(157, 33);
            this.btnShowProd.TabIndex = 28;
            this.btnShowProd.Text = "Show master products item";
            this.btnShowProd.UseVisualStyleBackColor = true;
            this.btnShowProd.Click += new System.EventHandler(this.btnShowProd_Click);
            // 
            // btn_Discount
            // 
            this.btn_Discount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Discount.Location = new System.Drawing.Point(12, 265);
            this.btn_Discount.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.Size = new System.Drawing.Size(157, 29);
            this.btn_Discount.TabIndex = 31;
            this.btn_Discount.Text = "Show Discount for LAZADA ";
            this.btn_Discount.UseVisualStyleBackColor = true;
            this.btn_Discount.Click += new System.EventHandler(this.btn_Discount_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnShowNewCustbyChn);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.btn_Discount);
            this.groupBox3.Controls.Add(this.btnGetOrder);
            this.groupBox3.Controls.Add(this.btbGetCust);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.btnShowProd);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Location = new System.Drawing.Point(409, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(187, 445);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Show Data in Database";
            // 
            // btnShowNewCustbyChn
            // 
            this.btnShowNewCustbyChn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowNewCustbyChn.Location = new System.Drawing.Point(12, 228);
            this.btnShowNewCustbyChn.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowNewCustbyChn.Name = "btnShowNewCustbyChn";
            this.btnShowNewCustbyChn.Size = new System.Drawing.Size(157, 32);
            this.btnShowNewCustbyChn.TabIndex = 32;
            this.btnShowNewCustbyChn.Text = "Show New Customer in order";
            this.btnShowNewCustbyChn.UseVisualStyleBackColor = true;
            this.btnShowNewCustbyChn.Click += new System.EventHandler(this.btnShowNewCustbyChn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnClearbyChn
            // 
            this.btnClearbyChn.ForeColor = System.Drawing.Color.Red;
            this.btnClearbyChn.Location = new System.Drawing.Point(261, 132);
            this.btnClearbyChn.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearbyChn.Name = "btnClearbyChn";
            this.btnClearbyChn.Size = new System.Drawing.Size(142, 28);
            this.btnClearbyChn.TabIndex = 33;
            this.btnClearbyChn.Text = "Clear Order by channel";
            this.btnClearbyChn.UseVisualStyleBackColor = true;
            this.btnClearbyChn.Click += new System.EventHandler(this.btnClearbyChn_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.ForeColor = System.Drawing.Color.Red;
            this.btnClearAll.Location = new System.Drawing.Point(262, 172);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(141, 27);
            this.btnClearAll.TabIndex = 34;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnClearbyChn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSelectCust);
            this.Controls.Add(this.btnSelectOrders);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form2";
            this.Text = "e-Commerce Interface Program V1.0 (Build 4.2)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelectOrders;
        private System.Windows.Forms.Button btnSelectCust;
        private System.Windows.Forms.Button Openxls;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSheetName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnLoadOrders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btbGetCust;
        private System.Windows.Forms.Button btnGetOrder;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnShowProd;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnCheckCustomer;
        private System.Windows.Forms.Button btnGrayCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbOrdersOf;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnLoadDiscnt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_Discount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        protected System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnShowNewCustbyChn;
        private System.Windows.Forms.Button btnClearbyChn;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnFourcetoExisting;
    }
}