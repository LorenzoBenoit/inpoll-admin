using InpollAdmin.model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InpollAdmin.services
{

    public class UtilisateurService
    {
        private static UtilisateurService? Instance;
        public ObservableCollection<Utilisateur>? ListeUtilisateurs { get; set; }
        private readonly string apiUrl = "https://inpoll-lbenoit.azurewebsites.net/utilisateurs";
        public async Task<ObservableCollection<Utilisateur>?> GetUtilisateursAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(apiUrl);
            Utilisateur[]? ar = JsonConvert.DeserializeObject<Utilisateur[]>(response);
            if (ar != null)
            {
                ListeUtilisateurs = new ObservableCollection<Utilisateur>(ar);
            }
            return ListeUtilisateurs;
        }


        public async Task<bool> DeleteUtilisateurAsync(Utilisateur utilisateur)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync(apiUrl + "/" + utilisateur._Id);
            if(response.IsSuccessStatusCode && ListeUtilisateurs != null)
            {
                ListeUtilisateurs.Remove(utilisateur);
                return true;
            } 
            else
            {
                return false;
            }
        }


        public static UtilisateurService GetInstance()
        {
            if (Instance == null)
            {
                Instance = new UtilisateurService();
            }
            return Instance;
        }
    }
}