using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using WpfAnimatedGif;

namespace CatFactory
{
    public partial class AnswerWindow : Window
    {
        public AnswerWindow()
        {
            InitializeComponent();
        }

        void Img_Load(object sender, RoutedEventArgs e)
        {    
            String sourceImage = GetContent.GetLink();

            if (sourceImage.Contains(".gif")) {
                BitmapImage Bi = new BitmapImage();
                Bi.BeginInit();
                Bi.CacheOption = BitmapCacheOption.OnLoad;
                Bi.UriSource = new Uri(sourceImage);
                Bi.EndInit();

                var image = sender as Image;
                image.Source = Bi;
                ImageBehavior.SetAnimatedSource(image, Bi);
            }
            else
            {
                BitmapImage Bi = new BitmapImage();
                Bi.BeginInit();
                Bi.CacheOption = BitmapCacheOption.OnLoad;
                Bi.UriSource = new Uri(sourceImage);
                Bi.EndInit();


                var image = sender as Image;
                image.Source = Bi;
            }

            this.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight / 2;
            this.MaxWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.SizeToContent = SizeToContent.WidthAndHeight;

            Fact.Background = Brushes.Gray;
            Fact.HorizontalAlignment = HorizontalAlignment.Center;
            Fact.VerticalAlignment = VerticalAlignment.Top;
            List<String> fact = GetContent.GetCatFact();
            String fullFact = "";
            for(int i = 0; i < fact.Count; i++)
            {
                if (fullFact.Equals(""))
                {
                    fullFact = fact[i];
                }
                else
                {
                    fullFact = fullFact + "\n" + fact[i];
                }
            }
            Fact.Text = fullFact;

            SourceText.Background = Brushes.Gray;
            SourceText.HorizontalAlignment = HorizontalAlignment.Center;
            SourceText.VerticalAlignment = VerticalAlignment.Bottom;
            SourceText.Text = "Original Bild: " + sourceImage;
        }

    }
}
