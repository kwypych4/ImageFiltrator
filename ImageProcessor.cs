using System.Drawing.Imaging;
using System.Threading;

namespace ImageFiltrator
{
    class ImageProcessor
    {
        public Bitmap ApplyFilter(Bitmap originalImage, string selectedFilter)
        {
            switch (selectedFilter)
            {
                case "Filtr Gaussa":
                    return ApplyGaussianBlur(originalImage);
                case "Efekt Ostrzenia Konturów":
                    return SharpenImageLaplace(originalImage);
                case "Filtr Olejny":
                    return ApplyOilPaintingFilter(originalImage, 2);
                default:
                    return originalImage;
            }
        }

        private Bitmap ApplyGaussianBlur(Bitmap original)
        {
            int width = original.Width;
            int height = original.Height;

            double[,] gaussianKernel = GenerateGaussianKernel(5, 1.4);

            Bitmap blurred = new Bitmap(width, height);

            int halfSize = gaussianKernel.GetLength(0) / 2;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double r = 0, g = 0, b = 0;
                    double sum = 0.0;

                    for (int i = -halfSize; i <= halfSize; i++)
                    {
                        for (int j = -halfSize; j <= halfSize; j++)
                        {
                            int pixelX = Math.Max(0, Math.Min(width - 1, x + i));
                            int pixelY = Math.Max(0, Math.Min(height - 1, y + j));

                            Color pixel = original.GetPixel(pixelX, pixelY);

                            double factor = gaussianKernel[i + halfSize, j + halfSize];

                            sum += factor;
                            r += factor * pixel.R;
                            g += factor * pixel.G;
                            b += factor * pixel.B;
                        }
                    }

                    r /= sum;
                    g /= sum;
                    b /= sum;

                    blurred.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
            }

            return blurred;
        }

        private double[,] GenerateGaussianKernel(int size, double sigma)
        {
            double[,] kernel = new double[size, size];
            double sum = 0.0;

            int halfSize = size / 2;

            for (int x = -halfSize; x <= halfSize; x++)
            {
                for (int y = -halfSize; y <= halfSize; y++)
                {
                    double exponent = -(x * x + y * y) / (2.0 * sigma * sigma);
                    kernel[x + halfSize, y + halfSize] = Math.Exp(exponent) / (2 * Math.PI * sigma * sigma);
                    sum += kernel[x + halfSize, y + halfSize];
                }
            }

            // Normalizacja kernela
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] /= sum;
                }
            }

            return kernel;
        }
        
        private Bitmap SharpenImageLaplace(Bitmap original)
        {
            int width = original.Width;
            int height = original.Height;

            int[,] laplaceKernel = { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };

            Bitmap sharpened = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int r = 0, g = 0, b = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int pixelX = Math.Max(0, Math.Min(width - 1, x + i));
                            int pixelY = Math.Max(0, Math.Min(height - 1, y + j));

                            Color pixel = original.GetPixel(pixelX, pixelY);

                            r += laplaceKernel[i + 1, j + 1] * pixel.R;
                            g += laplaceKernel[i + 1, j + 1] * pixel.G;
                            b += laplaceKernel[i + 1, j + 1] * pixel.B;
                        }
                    }

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    sharpened.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return sharpened;
        }
        
        private Bitmap ApplyOilPaintingFilter(Bitmap originalImage, int radius)
        {
            int width = originalImage.Width;
            int height = originalImage.Height;

            Bitmap oilPaintingImage = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Dictionary<Color, int> colorHistogram = new Dictionary<Color, int>();

                    for (int j = -radius; j <= radius; j++)
                    {
                        int newY = y + j;

                        if (newY >= 0 && newY < height)
                        {
                            for (int i = -radius; i <= radius; i++)
                            {
                                int newX = x + i;

                                if (newX >= 0 && newX < width)
                                {
                                    Color pixelColor = originalImage.GetPixel(newX, newY);

                                    if (colorHistogram.ContainsKey(pixelColor))
                                    {
                                        colorHistogram[pixelColor]++;
                                    }
                                    else
                                    {
                                        colorHistogram[pixelColor] = 1;
                                    }
                                }
                            }
                        }
                    }

                    Color dominantColor = colorHistogram.OrderByDescending(pair => pair.Value).First().Key;

                    oilPaintingImage.SetPixel(x, y, dominantColor);
                }
            }

            return oilPaintingImage;
        }
    }
}
