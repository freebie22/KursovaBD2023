namespace Pid_Kursach
{
    partial class CarModels
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.carnamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.myFirstCarDataSet = new Pid_Kursach.MyFirstCarDataSet();
            this.car_namesTableAdapter = new Pid_Kursach.MyFirstCarDataSetTableAdapters.car_namesTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.cartypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.car_typesTableAdapter = new Pid_Kursach.MyFirstCarDataSetTableAdapters.car_typesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carnamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myFirstCarDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 155);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(325, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Довідник моделей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(310, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Керування моделями";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(57, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ідентифікатор";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(57, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Назва моделі";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Назва відповідної марки";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(227, 306);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 31);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(227, 347);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(162, 31);
            this.textBox2.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.carnamesBindingSource;
            this.comboBox1.DisplayMember = "NName";
            this.comboBox1.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(276, 391);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 34);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.ValueMember = "NKod";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // carnamesBindingSource
            // 
            this.carnamesBindingSource.DataMember = "car_names";
            this.carnamesBindingSource.DataSource = this.bindingSource1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.myFirstCarDataSet;
            this.bindingSource1.Position = 0;
            // 
            // myFirstCarDataSet
            // 
            this.myFirstCarDataSet.DataSetName = "MyFirstCarDataSet";
            this.myFirstCarDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // car_namesTableAdapter
            // 
            this.car_namesTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(559, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 56);
            this.button1.TabIndex = 9;
            this.button1.Text = "Створити";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(559, 361);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 56);
            this.button2.TabIndex = 10;
            this.button2.Text = "Редагувати";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(559, 434);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 56);
            this.button3.TabIndex = 11;
            this.button3.Text = "Видалити";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(62, 451);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 56);
            this.button4.TabIndex = 12;
            this.button4.Text = "Очистити";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(435, 312);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(255, 451);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(214, 56);
            this.button5.TabIndex = 14;
            this.button5.Text = "Оновити таблицю";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cartypesBindingSource
            // 
            this.cartypesBindingSource.DataMember = "car_types";
            this.cartypesBindingSource.DataSource = this.myFirstCarDataSet;
            // 
            // car_typesTableAdapter
            // 
            this.car_typesTableAdapter.ClearBeforeFill = true;
            // 
            // CarModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 571);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CarModels";
            this.Text = "Моделі авто";
            this.Load += new System.EventHandler(this.CarModels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carnamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myFirstCarDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private MyFirstCarDataSet myFirstCarDataSet;
        private System.Windows.Forms.BindingSource carnamesBindingSource;
        private MyFirstCarDataSetTableAdapters.car_namesTableAdapter car_namesTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.BindingSource cartypesBindingSource;
        private MyFirstCarDataSetTableAdapters.car_typesTableAdapter car_typesTableAdapter;
    }
}