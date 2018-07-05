using System;
using System.Windows;


namespace CatFactory
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ButtonTextRandomizer();
        }

        void ClickClicky(object sender, RoutedEventArgs e)
        {
            AnswerWindow win = new AnswerWindow();
            win.Show();
            ButtonTextRandomizer();
        }

        void ButtonTextRandomizer()
        {
            String ButtonName= "Cat";

            Random rnd = new Random();
            int number = rnd.Next(0, ButtonNames.Length);
            ButtonName = ButtonNames[number];
            Clicky.Content = ButtonName;
        }

        String[] ButtonNames = {"Motivate Me!",
                                "CatFactory.newCat()",
                                "Cats are cool",
                                "You can never have enough",
                                "Cats are the better People",
                                "Cats > Dogs",
                                "Hier könnte ihre Werbung stehen"};
    }
}
