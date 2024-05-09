using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using InpollAdmin.model;
using InpollAdmin.services;

namespace InpollAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            chargerUtilisateurs();
        }

        private async void chargerUtilisateurs()
        {
            var utilisateurVM = UtilisateurService.GetInstance();
            await utilisateurVM.GetUtilisateursAsync();
            this.DataContext = utilisateurVM;
        }

        private void btnUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            FenUser fen = new();
            fen.Show();
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            FenData fen = new();
            fen.Show();
        }

    }
}
