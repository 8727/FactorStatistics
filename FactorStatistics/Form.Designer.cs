namespace FactorStatistics
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.load = new System.Windows.Forms.Button();
            this.ip = new System.Windows.Forms.TextBox();
            this.dateStop = new System.Windows.Forms.TextBox();
            this.select = new System.Windows.Forms.ComboBox();
            this.save = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.request = new System.Windows.Forms.Button();
            this.dateStart = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.load);
            this.groupBox1.Controls.Add(this.ip);
            this.groupBox1.Controls.Add(this.dateStop);
            this.groupBox1.Controls.Add(this.select);
            this.groupBox1.Controls.Add(this.save);
            this.groupBox1.Controls.Add(this.clear);
            this.groupBox1.Controls.Add(this.request);
            this.groupBox1.Controls.Add(this.dateStart);
            this.groupBox1.Location = new System.Drawing.Point(7, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1453, 59);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // load
            // 
            this.load.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.load.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.load.Location = new System.Drawing.Point(985, 15);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(150, 34);
            this.load.TabIndex = 9;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // ip
            // 
            this.ip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ip.Location = new System.Drawing.Point(11, 17);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(180, 31);
            this.ip.TabIndex = 8;
            this.ip.Text = "10.5.127.x";
            this.ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ip_KeyDown);
            // 
            // dateStop
            // 
            this.dateStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateStop.Location = new System.Drawing.Point(370, 17);
            this.dateStop.Name = "dateStop";
            this.dateStop.Size = new System.Drawing.Size(165, 31);
            this.dateStop.TabIndex = 7;
            this.dateStop.Text = "31.12.2024";
            this.dateStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateStop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.date_KeyDown);
            // 
            // select
            // 
            this.select.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.select.FormattingEnabled = true;
            this.select.Location = new System.Drawing.Point(542, 16);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(280, 33);
            this.select.TabIndex = 6;
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save.Location = new System.Drawing.Point(1295, 15);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(150, 34);
            this.save.TabIndex = 5;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear.Location = new System.Drawing.Point(1140, 15);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(150, 34);
            this.clear.TabIndex = 4;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // request
            // 
            this.request.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.request.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.request.Location = new System.Drawing.Point(828, 15);
            this.request.Name = "request";
            this.request.Size = new System.Drawing.Size(150, 34);
            this.request.TabIndex = 3;
            this.request.Text = "Request";
            this.request.UseVisualStyleBackColor = true;
            this.request.Click += new System.EventHandler(this.request_Click);
            // 
            // dateStart
            // 
            this.dateStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateStart.Location = new System.Drawing.Point(201, 17);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(165, 31);
            this.dateStart.TabIndex = 2;
            this.dateStart.Text = "31.12.2024";
            this.dateStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.date_KeyDown);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(7, 67);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(1453, 444);
            this.dataGridView.TabIndex = 4;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 517);
            this.progressBar.Maximum = 24;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1453, 34);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 5;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 558);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "Factor Statistics";
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ip_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox select;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button request;
        private System.Windows.Forms.TextBox dateStart;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox dateStop;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Button load;
    }
}

