namespace WinSnake
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DataGridSnake = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btUP = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.btRight = new System.Windows.Forms.Button();
            this.btDowm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSnake)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridSnake
            // 
            this.DataGridSnake.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridSnake.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridSnake.Location = new System.Drawing.Point(13, 13);
            this.DataGridSnake.Name = "DataGridSnake";
            this.DataGridSnake.Size = new System.Drawing.Size(784, 387);
            this.DataGridSnake.TabIndex = 0;
            this.DataGridSnake.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.DataGridSnake.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataGridSnake_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btUP
            // 
            this.btUP.Location = new System.Drawing.Point(841, 12);
            this.btUP.Name = "btUP";
            this.btUP.Size = new System.Drawing.Size(72, 33);
            this.btUP.TabIndex = 1;
            this.btUP.Text = "UP";
            this.btUP.UseVisualStyleBackColor = true;
            this.btUP.Click += new System.EventHandler(this.btUP_Click);
            this.btUP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btUP_MouseMove);
            // 
            // btLeft
            // 
            this.btLeft.Location = new System.Drawing.Point(803, 57);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(62, 41);
            this.btLeft.TabIndex = 2;
            this.btLeft.Text = "Left";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // btRight
            // 
            this.btRight.Location = new System.Drawing.Point(884, 57);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(58, 41);
            this.btRight.TabIndex = 3;
            this.btRight.Text = "Right";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btDowm
            // 
            this.btDowm.Location = new System.Drawing.Point(841, 104);
            this.btDowm.Name = "btDowm";
            this.btDowm.Size = new System.Drawing.Size(72, 38);
            this.btDowm.TabIndex = 4;
            this.btDowm.Text = "Down";
            this.btDowm.UseVisualStyleBackColor = true;
            this.btDowm.Click += new System.EventHandler(this.btDowm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 412);
            this.Controls.Add(this.btDowm);
            this.Controls.Add(this.btRight);
            this.Controls.Add(this.btLeft);
            this.Controls.Add(this.btUP);
            this.Controls.Add(this.DataGridSnake);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataGridSnake_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSnake)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridSnake;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btUP;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btDowm;
    }
}

