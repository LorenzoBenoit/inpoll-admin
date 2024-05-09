using InpollAdmin.model;
using InpollAdmin.services;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace InpollAdmin
{
    /// <summary>
    /// Logique d'interaction pour FenUser.xaml
    /// </summary>
    public partial class FenUser : Window
    {
        private UtilisateurService viewModel = UtilisateurService.GetInstance();

        public FenUser()
        {
            InitializeComponent();
            LoadData();
        }

        private async void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur utilisateur = (Utilisateur)Users.SelectedItem;

            if(await viewModel.DeleteUtilisateurAsync(utilisateur))
            {
                txtStatus.Text = "Utilisateur suprimé :" + utilisateur.Email + " !";
            }
            else
            {
                txtStatus.Text = "Erreur de suppresion !";
            }
        }

        private void btnUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            FenUser fen = new();
            fen.Show();
        }


        /**
         * ########## SPINNER LOADER + AFFICHE USERS ##########
         */

        //Affichage Spinner Loader (2s) + Affichage Tableau Utilisateurs
        private async void LoadData()
        {
            await Wait(3000);
            WaitComplete();
        }

        //Supprimer le spinner loader après les 2secondes plus affichage du DataGrid
        private async void WaitComplete()
        {
            Loader.Visibility = Visibility.Collapsed; 
            Users.ItemsSource = await viewModel.GetUtilisateursAsync();
        }

        //Affichage du spinner loader (2sec)
        private async Task Wait(int nbMs)
        {
            Loader.Visibility = Visibility.Visible;
            await Task.Delay(nbMs);
        }

     
    }
}
