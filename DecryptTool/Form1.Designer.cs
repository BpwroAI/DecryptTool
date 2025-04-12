namespace DecryptTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label1 = new Label();
            tabPage2 = new TabPage();
            label5 = new Label();
            button1 = new Button();
            textBox4 = new TextBox();
            label7 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            label2 = new Label();
            radioButton1 = new RadioButton();
            tabPage3 = new TabPage();
            button2 = new Button();
            label12 = new Label();
            textBox8 = new TextBox();
            label11 = new Label();
            label10 = new Label();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            label9 = new Label();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            label8 = new Label();
            textBox5 = new TextBox();
            tabPage4 = new TabPage();
            button3 = new Button();
            textBox12 = new TextBox();
            label17 = new Label();
            textBox11 = new TextBox();
            label16 = new Label();
            radioButton7 = new RadioButton();
            textBox10 = new TextBox();
            label15 = new Label();
            label14 = new Label();
            textBox9 = new TextBox();
            label13 = new Label();
            radioButton6 = new RadioButton();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.AllowDrop = true;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(820, 537);
            tabControl1.TabIndex = 0;
            tabControl1.DragDrop += Form1_DragDrop;
            tabControl1.DragEnter += Form1_DragEnter;
            // 
            // tabPage1
            // 
            tabPage1.AllowDrop = true;
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(812, 509);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "ファイル読み込み";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.DragDrop += Form1_DragDrop;
            tabPage1.DragEnter += Form1_DragEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F);
            label1.Location = new Point(6, 16);
            label1.Name = "label1";
            label1.Size = new Size(389, 21);
            label1.TabIndex = 0;
            label1.Text = "デコードしたいファイルをここにドラッグアンドドロップしてください。";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(radioButton3);
            tabPage2.Controls.Add(radioButton2);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(radioButton1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(812, 509);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "XOR";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F);
            label5.Location = new Point(274, 80);
            label5.Name = "label5";
            label5.Size = new Size(99, 21);
            label5.TabIndex = 15;
            label5.Text = "0x付きで指定";
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 12F);
            button1.Location = new Point(679, 422);
            button1.Name = "button1";
            button1.Size = new Size(79, 43);
            button1.TabIndex = 14;
            button1.Text = "RUN";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Yu Gothic UI", 12F);
            textBox4.Location = new Point(420, 372);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(173, 29);
            textBox4.TabIndex = 13;
            textBox4.Text = "0xFF";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 12F);
            label7.Location = new Point(315, 372);
            label7.Name = "label7";
            label7.Size = new Size(88, 63);
            label7.TabIndex = 12;
            label7.Text = "終端アドレス\r\n\r\n(0xで指定)";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Yu Gothic UI", 12F);
            textBox3.Location = new Point(420, 250);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(173, 29);
            textBox3.TabIndex = 7;
            textBox3.Text = "0xFF";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 12F);
            label6.Location = new Point(315, 252);
            label6.Name = "label6";
            label6.Size = new Size(278, 63);
            label6.TabIndex = 9;
            label6.Text = "範囲\r\n\r\n(10進数、16進数(0xで指定)どちらでも可)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Yu Gothic UI", 12F);
            label4.Location = new Point(12, 80);
            label4.Name = "label4";
            label4.Size = new Size(50, 21);
            label4.TabIndex = 8;
            label4.Text = "offset";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Yu Gothic UI", 12F);
            textBox2.Location = new Point(68, 77);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(173, 29);
            textBox2.TabIndex = 6;
            textBox2.Text = "0x00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F);
            label3.Location = new Point(274, 30);
            label3.Name = "label3";
            label3.Size = new Size(235, 21);
            label3.TabIndex = 5;
            label3.Text = "0x付きで16進数。文字列使用可。";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Yu Gothic UI", 12F);
            textBox1.Location = new Point(68, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(173, 29);
            textBox1.TabIndex = 4;
            textBox1.Text = "0xFF";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Font = new Font("Yu Gothic UI", 12F);
            radioButton3.Location = new Point(12, 370);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(273, 25);
            radioButton3.TabIndex = 3;
            radioButton3.TabStop = true;
            radioButton3.Text = "offsetとアドレスを指定してXORをかける";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Font = new Font("Yu Gothic UI", 12F);
            radioButton2.Location = new Point(12, 250);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(259, 25);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "offsetと範囲を指定してXORをかける\r\n";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F);
            label2.Location = new Point(30, 30);
            label2.Name = "label2";
            label2.Size = new Size(32, 21);
            label2.TabIndex = 1;
            label2.Text = "キー";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Font = new Font("Yu Gothic UI", 12F);
            radioButton1.Location = new Point(12, 180);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(198, 25);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "ファイル全体にXORをかける";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(textBox8);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(textBox7);
            tabPage3.Controls.Add(textBox6);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(radioButton5);
            tabPage3.Controls.Add(radioButton4);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(textBox5);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(812, 509);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "バイナリ置換え";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic UI", 12F);
            button2.Location = new Point(700, 393);
            button2.Name = "button2";
            button2.Size = new Size(79, 43);
            button2.TabIndex = 20;
            button2.Text = "RUN";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.FlatStyle = FlatStyle.Flat;
            label12.Font = new Font("Yu Gothic UI", 12F);
            label12.Location = new Point(6, 290);
            label12.Name = "label12";
            label12.Size = new Size(421, 21);
            label12.TabIndex = 19;
            label12.Text = "置換えるバイナリ（0x無し16進数。スペースの有無どちらも対応）";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(6, 314);
            textBox8.Multiline = true;
            textBox8.Name = "textBox8";
            textBox8.ScrollBars = ScrollBars.Vertical;
            textBox8.Size = new Size(654, 189);
            textBox8.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.FlatStyle = FlatStyle.Flat;
            label11.Font = new Font("Yu Gothic UI", 12F);
            label11.Location = new Point(392, 242);
            label11.Name = "label11";
            label11.Size = new Size(159, 21);
            label11.TabIndex = 17;
            label11.Text = "16進数(0x付き)で指定";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.FlatStyle = FlatStyle.Flat;
            label10.Font = new Font("Yu Gothic UI", 12F);
            label10.Location = new Point(392, 174);
            label10.Name = "label10";
            label10.Size = new Size(268, 21);
            label10.TabIndex = 16;
            label10.Text = "10進数、16進数(0xで指定)どちらでも可";
            // 
            // textBox7
            // 
            textBox7.Font = new Font("Yu Gothic UI", 12F);
            textBox7.Location = new Point(175, 239);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(173, 29);
            textBox7.TabIndex = 15;
            textBox7.Text = "0xFF";
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Yu Gothic UI", 12F);
            textBox6.Location = new Point(175, 170);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(173, 29);
            textBox6.TabIndex = 14;
            textBox6.Text = "0xFF";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.FlatStyle = FlatStyle.Flat;
            label9.Font = new Font("Yu Gothic UI", 12F);
            label9.Location = new Point(30, 100);
            label9.Name = "label9";
            label9.Size = new Size(50, 21);
            label9.TabIndex = 13;
            label9.Text = "offset";
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Font = new Font("Yu Gothic UI", 12F);
            radioButton5.Location = new Point(30, 240);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(106, 25);
            radioButton5.TabIndex = 12;
            radioButton5.TabStop = true;
            radioButton5.Text = "アドレス指定";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Yu Gothic UI", 12F);
            radioButton4.Location = new Point(30, 170);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(92, 25);
            radioButton4.TabIndex = 11;
            radioButton4.TabStop = true;
            radioButton4.Text = "範囲指定";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Yu Gothic UI", 12F);
            label8.Location = new Point(30, 30);
            label8.Name = "label8";
            label8.Size = new Size(318, 21);
            label8.TabIndex = 10;
            label8.Text = "指定した範囲を指定したバイナリに置き換えます。";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Yu Gothic UI", 12F);
            textBox5.Location = new Point(86, 97);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(173, 29);
            textBox5.TabIndex = 9;
            textBox5.Text = "0x00";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(button3);
            tabPage4.Controls.Add(textBox12);
            tabPage4.Controls.Add(label17);
            tabPage4.Controls.Add(textBox11);
            tabPage4.Controls.Add(label16);
            tabPage4.Controls.Add(radioButton7);
            tabPage4.Controls.Add(textBox10);
            tabPage4.Controls.Add(label15);
            tabPage4.Controls.Add(label14);
            tabPage4.Controls.Add(textBox9);
            tabPage4.Controls.Add(label13);
            tabPage4.Controls.Add(radioButton6);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(812, 509);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "バイナリカット";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Yu Gothic UI", 12F);
            button3.Location = new Point(692, 439);
            button3.Name = "button3";
            button3.Size = new Size(79, 43);
            button3.TabIndex = 28;
            button3.Text = "RUN";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox12
            // 
            textBox12.Font = new Font("Yu Gothic UI", 12F);
            textBox12.Location = new Point(134, 427);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(103, 29);
            textBox12.TabIndex = 27;
            textBox12.Text = "0";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.FlatStyle = FlatStyle.Flat;
            label17.Font = new Font("Yu Gothic UI", 12F);
            label17.Location = new Point(30, 430);
            label17.Name = "label17";
            label17.Size = new Size(362, 63);
            label17.TabIndex = 26;
            label17.Text = "スキップ回数\r\n\r\n指定した分だけ検索をスキップします（10進数で入力）";
            // 
            // textBox11
            // 
            textBox11.Font = new Font("Yu Gothic UI", 12F);
            textBox11.Location = new Point(93, 317);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(650, 29);
            textBox11.TabIndex = 25;
            textBox11.Text = "0A 0B";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.FlatStyle = FlatStyle.Flat;
            label16.Font = new Font("Yu Gothic UI", 12F);
            label16.Location = new Point(30, 320);
            label16.Name = "label16";
            label16.Size = new Size(647, 63);
            label16.TabIndex = 24;
            label16.Text = "バイナリ\r\n\r\n16進バイナリ、文字列か自動認識します。16進バイナリは0xAA BB、AABB形式どちらでも認識します。\r\n";
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Font = new Font("Yu Gothic UI", 12F);
            radioButton7.Location = new Point(30, 270);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(423, 25);
            radioButton7.TabIndex = 23;
            radioButton7.Text = "バイナリ指定（指定したバイナリの前までバイナリを削除します）";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // textBox10
            // 
            textBox10.Font = new Font("Yu Gothic UI", 12F);
            textBox10.Location = new Point(435, 147);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(173, 29);
            textBox10.TabIndex = 21;
            textBox10.Text = "0xFF";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.FlatStyle = FlatStyle.Flat;
            label15.Font = new Font("Yu Gothic UI", 12F);
            label15.Location = new Point(345, 150);
            label15.Name = "label15";
            label15.Size = new Size(268, 63);
            label15.TabIndex = 22;
            label15.Text = "範囲\r\n\r\n10進数、16進数(0xで指定)どちらでも可";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.FlatStyle = FlatStyle.Flat;
            label14.Font = new Font("Yu Gothic UI", 12F);
            label14.Location = new Point(30, 150);
            label14.Name = "label14";
            label14.Size = new Size(50, 21);
            label14.TabIndex = 20;
            label14.Text = "offset";
            // 
            // textBox9
            // 
            textBox9.Font = new Font("Yu Gothic UI", 12F);
            textBox9.Location = new Point(86, 147);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(173, 29);
            textBox9.TabIndex = 19;
            textBox9.Text = "0x00";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.FlatStyle = FlatStyle.Flat;
            label13.Font = new Font("Yu Gothic UI", 12F);
            label13.Location = new Point(30, 30);
            label13.Name = "label13";
            label13.Size = new Size(346, 21);
            label13.TabIndex = 18;
            label13.Text = "指定した範囲、或いは指定した条件でバイナリをカット";
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Checked = true;
            radioButton6.Font = new Font("Yu Gothic UI", 12F);
            radioButton6.Location = new Point(30, 100);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(92, 25);
            radioButton6.TabIndex = 12;
            radioButton6.TabStop = true;
            radioButton6.Text = "範囲指定";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 561);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "DecryptTool";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label6;
        private Label label7;
        private Button button1;
        private TextBox textBox4;
        private TabPage tabPage3;
        private Label label5;
        private Label label9;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private Label label8;
        private TextBox textBox5;
        private TextBox textBox7;
        private TextBox textBox6;
        private Label label10;
        private Label label11;
        private TextBox textBox8;
        private Button button2;
        private Label label12;
        private TabPage tabPage4;
        private Label label13;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private TextBox textBox10;
        private Label label15;
        private Label label14;
        private TextBox textBox9;
        private TextBox textBox12;
        private Label label17;
        private TextBox textBox11;
        private Label label16;
        private Button button3;
    }
}
