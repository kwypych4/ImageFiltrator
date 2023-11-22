namespace ImageFiltrator
{
    partial class MainForm
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
            statusStrip1 = new StatusStrip();
            progressBar = new ToolStripProgressBar();
            executionTimeLabel = new ToolStripStatusLabel();
            imageNameLabel = new ToolStripStatusLabel();
            imageSizeLabel = new ToolStripStatusLabel();
            imageResolutionLabel = new ToolStripStatusLabel();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            oAplikacjiToolStripMenuItem = new ToolStripMenuItem();
            optionsGroupBox = new GroupBox();
            startStopButton = new Button();
            filterSelectLabel = new Label();
            filterSelectCombobox = new ComboBox();
            threadsNumberLabel = new Label();
            threadsNumbersInput = new NumericUpDown();
            threadsTrackBar = new TrackBar();
            concurrentProcessingCheckbox = new CheckBox();
            loadImageButton = new Button();
            panel = new Panel();
            imageContainer = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            statusStrip1.SuspendLayout();
            optionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)threadsNumbersInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)threadsTrackBar).BeginInit();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageContainer).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { progressBar, executionTimeLabel, imageNameLabel, imageSizeLabel, imageResolutionLabel, toolStripDropDownButton1 });
            statusStrip1.Location = new Point(0, 490);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(882, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            progressBar.Enabled = false;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 16);
            progressBar.Style = ProgressBarStyle.Marquee;
            // 
            // executionTimeLabel
            // 
            executionTimeLabel.Name = "executionTimeLabel";
            executionTimeLabel.Size = new Size(139, 17);
            executionTimeLabel.Text = "Czas wykonywania: 00:00";
            // 
            // imageNameLabel
            // 
            imageNameLabel.Name = "imageNameLabel";
            imageNameLabel.Size = new Size(42, 17);
            imageNameLabel.Text = "Nazwa";
            // 
            // imageSizeLabel
            // 
            imageSizeLabel.Name = "imageSizeLabel";
            imageSizeLabel.Size = new Size(50, 17);
            imageSizeLabel.Text = "Rozmiar";
            // 
            // imageResolutionLabel
            // 
            imageResolutionLabel.Name = "imageResolutionLabel";
            imageResolutionLabel.Size = new Size(79, 17);
            imageResolutionLabel.Text = "Rozdzielczość";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.AccessibleName = "Pomoc";
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { oAplikacjiToolStripMenuItem });
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(58, 20);
            toolStripDropDownButton1.Text = "Pomoc";
            // 
            // oAplikacjiToolStripMenuItem
            // 
            oAplikacjiToolStripMenuItem.Name = "oAplikacjiToolStripMenuItem";
            oAplikacjiToolStripMenuItem.Size = new Size(129, 22);
            oAplikacjiToolStripMenuItem.Text = "O aplikacji";
            oAplikacjiToolStripMenuItem.Click += oAplikacjiToolStripMenuItem_Click;
            // 
            // optionsGroupBox
            // 
            optionsGroupBox.Controls.Add(startStopButton);
            optionsGroupBox.Controls.Add(filterSelectLabel);
            optionsGroupBox.Controls.Add(filterSelectCombobox);
            optionsGroupBox.Controls.Add(threadsNumberLabel);
            optionsGroupBox.Controls.Add(threadsNumbersInput);
            optionsGroupBox.Controls.Add(threadsTrackBar);
            optionsGroupBox.Controls.Add(concurrentProcessingCheckbox);
            optionsGroupBox.Controls.Add(loadImageButton);
            optionsGroupBox.Location = new Point(3, 3);
            optionsGroupBox.MinimumSize = new Size(202, 300);
            optionsGroupBox.Name = "optionsGroupBox";
            optionsGroupBox.Size = new Size(202, 475);
            optionsGroupBox.TabIndex = 0;
            optionsGroupBox.TabStop = false;
            optionsGroupBox.Text = "Opcje";
            // 
            // startStopButton
            // 
            startStopButton.Enabled = false;
            startStopButton.Location = new Point(6, 445);
            startStopButton.Name = "startStopButton";
            startStopButton.Size = new Size(188, 23);
            startStopButton.TabIndex = 8;
            startStopButton.Text = "Rozpocznij filtrowanie";
            startStopButton.UseVisualStyleBackColor = true;
            startStopButton.Click += startStopButton_Click;
            // 
            // filterSelectLabel
            // 
            filterSelectLabel.AutoSize = true;
            filterSelectLabel.Enabled = false;
            filterSelectLabel.Location = new Point(6, 200);
            filterSelectLabel.Name = "filterSelectLabel";
            filterSelectLabel.Size = new Size(70, 15);
            filterSelectLabel.TabIndex = 7;
            filterSelectLabel.Text = "Wybierz filtr";
            // 
            // filterSelectCombobox
            // 
            filterSelectCombobox.Enabled = false;
            filterSelectCombobox.FormattingEnabled = true;
            filterSelectCombobox.Location = new Point(6, 218);
            filterSelectCombobox.Name = "filterSelectCombobox";
            filterSelectCombobox.Size = new Size(188, 23);
            filterSelectCombobox.TabIndex = 6;
            // 
            // threadsNumberLabel
            // 
            threadsNumberLabel.AutoSize = true;
            threadsNumberLabel.Enabled = false;
            threadsNumberLabel.Location = new Point(5, 125);
            threadsNumberLabel.Name = "threadsNumberLabel";
            threadsNumberLabel.Size = new Size(75, 15);
            threadsNumberLabel.TabIndex = 5;
            threadsNumberLabel.Text = "Ilość wątków";
            // 
            // threadsNumbersInput
            // 
            threadsNumbersInput.Enabled = false;
            threadsNumbersInput.Location = new Point(6, 147);
            threadsNumbersInput.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            threadsNumbersInput.Name = "threadsNumbersInput";
            threadsNumbersInput.Size = new Size(47, 23);
            threadsNumbersInput.TabIndex = 4;
            threadsNumbersInput.Value = new decimal(new int[] { 2, 0, 0, 0 });
            threadsNumbersInput.ValueChanged += threadsNumbersInput_ValueChanged;
            // 
            // threadsTrackBar
            // 
            threadsTrackBar.Enabled = false;
            threadsTrackBar.Location = new Point(59, 147);
            threadsTrackBar.Minimum = 2;
            threadsTrackBar.Name = "threadsTrackBar";
            threadsTrackBar.Size = new Size(135, 45);
            threadsTrackBar.TabIndex = 3;
            threadsTrackBar.Value = 2;
            threadsTrackBar.ValueChanged += threadsTrackBar_ValueChanged;
            // 
            // concurrentProcessingCheckbox
            // 
            concurrentProcessingCheckbox.AutoSize = true;
            concurrentProcessingCheckbox.Enabled = false;
            concurrentProcessingCheckbox.Location = new Point(6, 93);
            concurrentProcessingCheckbox.Name = "concurrentProcessingCheckbox";
            concurrentProcessingCheckbox.Size = new Size(166, 19);
            concurrentProcessingCheckbox.TabIndex = 2;
            concurrentProcessingCheckbox.Text = "Przetwarzanie współbieżne";
            concurrentProcessingCheckbox.UseVisualStyleBackColor = true;
            concurrentProcessingCheckbox.CheckedChanged += concurrentProcessingCheckbox_CheckedChanged;
            // 
            // loadImageButton
            // 
            loadImageButton.Location = new Point(6, 31);
            loadImageButton.Name = "loadImageButton";
            loadImageButton.Size = new Size(188, 28);
            loadImageButton.TabIndex = 0;
            loadImageButton.Text = "Wybierz zdjęcie";
            loadImageButton.UseVisualStyleBackColor = true;
            loadImageButton.Click += loadImageButton_Click;
            // 
            // panel
            // 
            panel.Controls.Add(imageContainer);
            panel.Location = new Point(207, 3);
            panel.Name = "panel";
            panel.Size = new Size(672, 475);
            panel.TabIndex = 3;
            // 
            // imageContainer
            // 
            imageContainer.Location = new Point(4, 0);
            imageContainer.Name = "imageContainer";
            imageContainer.Size = new Size(666, 475);
            imageContainer.SizeMode = PictureBoxSizeMode.AutoSize;
            imageContainer.TabIndex = 0;
            imageContainer.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 204F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(optionsGroupBox, 0, 0);
            tableLayoutPanel1.Controls.Add(panel, 1, 0);
            tableLayoutPanel1.Location = new Point(0, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(882, 483);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(882, 512);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            Text = "Image Filtrator";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            optionsGroupBox.ResumeLayout(false);
            optionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)threadsNumbersInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)threadsTrackBar).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageContainer).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripProgressBar progressBar;
        private ToolStripStatusLabel imageNameLabel;
        private ToolStripStatusLabel executionTimeLabel;
        private ToolStripStatusLabel imageSizeLabel;
        private ToolStripStatusLabel imageResolutionLabel;
        private GroupBox optionsGroupBox;
        private Button startStopButton;
        private Label filterSelectLabel;
        private ComboBox filterSelectCombobox;
        private Label threadsNumberLabel;
        private NumericUpDown threadsNumbersInput;
        private TrackBar threadsTrackBar;
        private CheckBox concurrentProcessingCheckbox;
        private Button loadImageButton;
        private Panel panel;
        private PictureBox imageContainer;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem oAplikacjiToolStripMenuItem;
    }
}