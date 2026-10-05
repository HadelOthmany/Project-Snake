namespace Snake
{
    partial class MainForm
    {
       
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            ScoreDisplay = new Label();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Gold;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 84);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(174, 48);
            button1.TabIndex = 0;
            button1.Text = "1 Player";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.MediumVioletRed;
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(12, 148);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(174, 47);
            button2.TabIndex = 1;
            button2.Text = "2 Players";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(648, 334);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(122, 44);
            button3.TabIndex = 2;
            button3.Text = "Exit Game";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.HotTrack;
            textBox1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(137, 7);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(491, 50);
            textBox1.TabIndex = 3;
            textBox1.Text = "Snake Game";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Enabled = false;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-4, 1);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(806, 404);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // ScoreDisplay
            // 
            ScoreDisplay.AutoSize = true;
            ScoreDisplay.BackColor = Color.Transparent;
            ScoreDisplay.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            ScoreDisplay.Location = new Point(9, 7);
            ScoreDisplay.Name = "ScoreDisplay";
            ScoreDisplay.Size = new Size(59, 75);
            ScoreDisplay.TabIndex = 5;
            ScoreDisplay.Text = "label1\r\ntext\r\ntext";
            ScoreDisplay.Visible = false;
            // 
            // button4
            // 
            button4.BackColor = Color.AliceBlue;
            button4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(12, 213);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(174, 47);
            button4.TabIndex = 6;
            button4.Text = "3 Players";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(ScoreDisplay);
            Name = "MainForm";
            Text = "Project Snake";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        public Label ScoreDisplay;
        private Button button4;
    }
}