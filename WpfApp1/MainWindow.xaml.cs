using System;
using System.Collections.ObjectModel;
using System.Windows;
using kolostemplate;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Plytoteka plytoteka;
        public MainWindow()
        {
            InitializeComponent();

            plytoteka = Plytoteka.Odczytaj("binarny.bin");
            NameTxt.Text = plytoteka.Nazwa;
            PhoneTxt.Text = plytoteka.Telefon;
            Counter.Text = plytoteka.Podsumowanie().ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Enum.TryParse<KategoriaMuzyki>(KategoriaTxt.Text, out  KategoriaMuzyki tmp);
            var list = plytoteka.Szukaj(tmp);
            LstPlyty.ItemsSource = new ObservableCollection<PlytaAudio>(list);
        }
    }
}
