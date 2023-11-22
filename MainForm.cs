using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ImageFiltrator
{
    public partial class MainForm : Form
    {
        private int SelectedThreadsNumber = 1;
        private readonly int MaxThreadsNumber = Process.GetCurrentProcess().Threads.Count;
        private const string ImageFileFilter = "Image Files (*.jpg;*.jpeg;.*.png;)|*.jpg;*.jpeg;.*.png";
        private ImageProcessor imageProcessor = new();
        private DateTime startTime;
        TimeSpan elapsed;
        private System.Windows.Forms.Timer? timer;
        private delegate Bitmap ApplyFilterDelegate(Bitmap originalImage, string filter);
        private bool isRunning = false;
        private object cancellationTokenLock = new object();
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainForm()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeInputAndTrackBar();
            InitializeImageInfo();
            InitializeScrollablePictureBox();

        }
        private void InitializeScrollablePictureBox()
        {
            optionsGroupBox.Dock = DockStyle.Fill;
            startStopButton.Anchor = AnchorStyles.Bottom;
            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(panel, 1, 0);
            panel.Controls.Add(imageContainer);
            imageContainer.SizeMode = PictureBoxSizeMode.AutoSize;
            imageContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        private void InitializeImageInfo()
        {
            imageNameLabel.Visible = false;
            imageSizeLabel.Visible = false;
            imageResolutionLabel.Visible = false;
            progressBar.Style = ProgressBarStyle.Blocks;

        }
        private void InitializeTimer()
        {
            executionTimeLabel.Text = $"Czas wykonywania: 00:00";
            timer = new();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            startTime = DateTime.Now;
            timer.Start();

        }

        private void Timer_Tick([AllowNull] object sender, EventArgs e)
        {
            if (timer != null)
            {
                elapsed = DateTime.Now - startTime;
                executionTimeLabel.Text = $"Czas wykonywania: {elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
            }

        }

        private void InitializeInputAndTrackBar()
        {
            threadsNumbersInput.Value = 2;
            threadsNumbersInput.Maximum = MaxThreadsNumber;
            threadsTrackBar.Value = 2;
            threadsTrackBar.Maximum = MaxThreadsNumber;
        }

        private void InitializeComboBox()
        {
            filterSelectCombobox.Items.Add("Filtr Gaussa");
            filterSelectCombobox.Items.Add("Efekt Ostrzenia Konturów");
            filterSelectCombobox.Items.Add("Filtr Olejny");

            filterSelectCombobox.SelectedIndex = 0;
            filterSelectCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = ImageFileFilter;
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = opnfd.FileName;

                Bitmap image = new Bitmap(filePath);

                long fileSizeInBytes = new FileInfo(filePath).Length;
                double fileSizeInMB = fileSizeInBytes / (1024.0 * 1024.0);
                int width = image.Width;
                int height = image.Height;

                imageContainer.Image = image;
                concurrentProcessingCheckbox.Enabled = true;
                filterSelectLabel.Enabled = true;
                filterSelectCombobox.Enabled = true;
                startStopButton.Enabled = true;
                loadImageButton.Text = "Zmieñ zdjêcie";
                imageNameLabel.Visible = true;
                imageSizeLabel.Visible = true;
                imageResolutionLabel.Visible = true;
                imageNameLabel.Text = opnfd.FileName;
                imageSizeLabel.Text = $"Rozmiar: {fileSizeInMB:F2} MB";
                imageResolutionLabel.Text = $"Rozdzielczoœæ: {width}x{height}";
            }
        }

        private void concurrentProcessingCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (concurrentProcessingCheckbox.Checked)
            {
                threadsNumberLabel.Enabled = true;
                threadsNumbersInput.Enabled = true;
                threadsTrackBar.Enabled = true;
                SelectedThreadsNumber = threadsTrackBar.Value;
            }
            else
            {
                SelectedThreadsNumber = 1;
                threadsNumberLabel.Enabled = false;
                threadsNumbersInput.Enabled = false;
                threadsTrackBar.Enabled = false;
            }
        }

        private void threadsNumbersInput_ValueChanged(object sender, EventArgs e)
        {
            SelectedThreadsNumber = Convert.ToInt32(threadsNumbersInput.Value);
            threadsTrackBar.Value = Convert.ToInt32(threadsNumbersInput.Value);
        }

        private void threadsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SelectedThreadsNumber = threadsTrackBar.Value;
            threadsNumbersInput.Value = threadsTrackBar.Value;
        }


        private void SyncThreadsResults(bool[] flags, Bitmap originalImage, Bitmap[] partialsOfImage, CancellationToken cancellationToken)
        {
            lock (cancellationTokenLock)
            {
                if (flags.All(flag => flag == true) && !cancellationToken.IsCancellationRequested)
                {
                    Bitmap mergedBitmap = new Bitmap(originalImage.Width, originalImage.Height);

                    using (Graphics g = Graphics.FromImage(mergedBitmap))
                    {
                        int y = 0;

                        foreach (Bitmap image in partialsOfImage)
                        {
                            g.DrawImage(image, new Rectangle(0, y, originalImage.Width, image.Height));
                            y += image.Height;
                        }


                    }

                    UpdateImageContainer(mergedBitmap);

                }

            }

        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (imageContainer.Image != null)
            {
                if (!isRunning)
                {
                    setControls(false);

                    string selectedFilter = filterSelectCombobox.Text;
                    Bitmap originalImage = new Bitmap(imageContainer.Image);
                    InitializeTimer();

                    int numberOfThreads = SelectedThreadsNumber;

                    Thread[] threads = new Thread[numberOfThreads];
                    Bitmap[] partialsOfImage = new Bitmap[numberOfThreads];
                    bool[] partialsReadyFlags = new bool[numberOfThreads];

                    int heightPerThread = originalImage.Height / numberOfThreads;
                    int width = originalImage.Width;



                    for (int i = 0; i < numberOfThreads; i++)
                    {
                        partialsOfImage[i] = new Bitmap(width, heightPerThread);
                        Rectangle sourceRectangle = new Rectangle(0, heightPerThread * i, width, heightPerThread);

                        using (Graphics g = Graphics.FromImage(partialsOfImage[i]))
                        {
                            g.DrawImage(originalImage, new Rectangle(0, 0, partialsOfImage[i].Width, partialsOfImage[i].Height),
                                        sourceRectangle, GraphicsUnit.Pixel);
                        }

                    }

                    for (int i = 0; i < numberOfThreads; i++)
                    {
                        int currentIndex = i;

                        threads[currentIndex] = new Thread(() =>
                        {
                            CancellationToken cancellationToken;
                            lock (cancellationTokenLock)
                            {
                                cancellationToken = cancellationTokenSource.Token;
                            }

                            ApplyFilterDelegate applyFilterDelegate = new ApplyFilterDelegate(imageProcessor.ApplyFilter);

                            Bitmap filteredImage = applyFilterDelegate.Invoke(partialsOfImage[currentIndex], selectedFilter);

                            partialsOfImage[currentIndex] = filteredImage;
                            partialsReadyFlags[currentIndex] = true;
                            SyncThreadsResults(partialsReadyFlags, originalImage, partialsOfImage, cancellationToken);

                        });
                        threads[currentIndex].Start();
                    }


                }
                else
                {
                    lock (cancellationTokenLock)
                    {
                        cancellationTokenSource.Cancel();
                        cancellationTokenSource.Dispose();
                        cancellationTokenSource = new CancellationTokenSource();
                    }

                    setControls(true);

                }

            }

            else
            {
                MessageBox.Show("Wczytaj obraz przed zastosowaniem filtra.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void setControls(bool finish)
        {
            if (finish == true)
            {
                startStopButton.Text = "Rozpocznij filtrowanie";
                loadImageButton.Enabled = true;
                filterSelectCombobox.Enabled = true;
                concurrentProcessingCheckbox.Enabled = true;
                if (concurrentProcessingCheckbox.Checked == true)
                {
                    threadsNumbersInput.Enabled = true;
                    threadsTrackBar.Enabled = true;
                }

                timer?.Stop();
                isRunning = false;
                progressBar.Style = ProgressBarStyle.Blocks;

            }
            else
            {
                isRunning = true;
                startStopButton.Text = "Zatrzymaj filtrowanie!";
                loadImageButton.Enabled = false;
                filterSelectCombobox.Enabled = false;
                concurrentProcessingCheckbox.Enabled = false;
                progressBar.Style = ProgressBarStyle.Marquee;
                if (concurrentProcessingCheckbox.Checked == true)
                {
                    threadsNumbersInput.Enabled = false;
                    threadsTrackBar.Enabled = false;
                }
            }
        }
        private void UpdateImageContainer(Bitmap image)
        {
            if (imageContainer.InvokeRequired)
            {
                imageContainer.BeginInvoke(new Action(() => UpdateImageContainer(image)));
            }
            else
            {
                imageContainer.Image = image;
                setControls(true);
                string elapsedTimeText = $"{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
                MessageBox.Show($"Filtrowanie zosta³o zakoñczone. Czas potrzebny do wykonania operacji to: {elapsedTimeText}", "Sukces", MessageBoxButtons.OK);

            }
        }

        private void oAplikacjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Kamil Wypych. \n2023r.", "O aplikacji");
        }
    }
}