namespace Game_Launcher_Example
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            totalProgressBar = new ProgressBar();
            button1 = new Button();
            barProgressFile = new ProgressBar();
            labelProgressFile = new Label();
            labelFilename = new Label();
            labelProgressTotal = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // totalProgressBar
            // 
            totalProgressBar.BackColor = SystemColors.Control;
            totalProgressBar.Location = new Point(17, 643);
            totalProgressBar.Margin = new Padding(4, 5, 4, 5);
            totalProgressBar.Name = "totalProgressBar";
            totalProgressBar.Size = new Size(776, 38);
            totalProgressBar.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Enabled = false;
            button1.ImageAlign = ContentAlignment.TopLeft;
            button1.Location = new Point(917, 643);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(213, 100);
            button1.TabIndex = 1;
            button1.Text = "Play";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // barProgressFile
            // 
            barProgressFile.Location = new Point(17, 692);
            barProgressFile.Margin = new Padding(4, 5, 4, 5);
            barProgressFile.Name = "barProgressFile";
            barProgressFile.Size = new Size(776, 38);
            barProgressFile.TabIndex = 2;
            // 
            // labelProgressFile
            // 
            labelProgressFile.BackColor = Color.Transparent;
            labelProgressFile.ForeColor = Color.Black;
            labelProgressFile.Location = new Point(801, 692);
            labelProgressFile.Margin = new Padding(4, 0, 4, 0);
            labelProgressFile.Name = "labelProgressFile";
            labelProgressFile.Size = new Size(113, 38);
            labelProgressFile.TabIndex = 3;
            labelProgressFile.Text = "0%";
            labelProgressFile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelFilename
            // 
            labelFilename.BackColor = Color.Transparent;
            labelFilename.ForeColor = Color.Black;
            labelFilename.Location = new Point(17, 600);
            labelFilename.Margin = new Padding(4, 0, 4, 0);
            labelFilename.Name = "labelFilename";
            labelFilename.Size = new Size(776, 38);
            labelFilename.TabIndex = 4;
            labelFilename.Text = "n/a";
            labelFilename.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelProgressTotal
            // 
            labelProgressTotal.BackColor = Color.Transparent;
            labelProgressTotal.ForeColor = Color.Black;
            labelProgressTotal.Location = new Point(801, 643);
            labelProgressTotal.Margin = new Padding(4, 0, 4, 0);
            labelProgressTotal.Name = "labelProgressTotal";
            labelProgressTotal.Size = new Size(113, 38);
            labelProgressTotal.TabIndex = 5;
            labelProgressTotal.Text = "n/a";
            labelProgressTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1141, 641);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1143, 750);
            Controls.Add(pictureBox1);
            Controls.Add(labelProgressTotal);
            Controls.Add(labelFilename);
            Controls.Add(labelProgressFile);
            Controls.Add(barProgressFile);
            Controls.Add(button1);
            Controls.Add(totalProgressBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Game Launcher";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar totalProgressBar;
        private Button button1;
        private ProgressBar barProgressFile;
        private Label labelProgressFile;
        private Label labelFilename;
        private Label labelProgressTotal;
        private PictureBox pictureBox1;
    }
}
