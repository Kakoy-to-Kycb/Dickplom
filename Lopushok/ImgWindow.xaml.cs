using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lopushok
{
    /// <summary>
    /// Логика взаимодействия для ImgWindow.xaml
    /// </summary>
    public partial class ImgWindow : Window
    {
        public string ImgUri { get; private set; }

        public ImgWindow()
        {
            InitializeComponent();

            ShowImages();
        }

        private string[] GetImages()
        {
            string[] imgs = Directory.GetFiles("../../products");
            for (int i = 0; i < imgs.Length; i++)
                imgs[i] = imgs[i].Remove(0, 5);

            return imgs;
        }

        private void ShowImages()
        {
            const int rowLength = 5;

            string[] imgs = GetImages();

            StackPanel column = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            for (int i = 0; i <= imgs.Length / rowLength; i++)
            {
                StackPanel row = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(5, 5, 5, 5)
                };

                for (int j = rowLength * i; j < (rowLength * i) + rowLength; j++)
                {
                    if (j == imgs.Length)
                        break;

                    Image img = new Image
                    {
                        Width = 110,
                        Height = 110,
                        Margin = new Thickness(5, 5, 5, 5),
                        Source = new BitmapImage(new Uri(imgs[j], UriKind.Relative)),
                        Cursor = Cursors.Hand,
                        Tag = imgs[j]
                    };

                    img.MouseLeftButtonDown += Image_MouseLeftButtonDown;
                    row.Children.Add(img);
                }

                column.Children.Add(row);
            }

            gridImages.Children.Add(column);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            ImgUri = image.Tag.ToString();
            DialogResult = true;
            Close();
        }
    }
}
