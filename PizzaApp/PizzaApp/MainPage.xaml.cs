using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PizzaApp.Model;
using Xamarin.Forms;

namespace PizzaApp
{
    public partial class MainPage : ContentPage
    {
        // List<Pizza> pizzas;

        public MainPage()
        {
            InitializeComponent();


            // string pizzaJson = "[{\"nom\":\"4 fromages\",\"ingredients\":[\"cantal\",\"mozzarella\",\"fromage de chèvre\",\"gruyère\"],\"prix\":11,\"imageUrl\":\"https://www.galbani.fr/wp-content/uploads/2017/07/pizza_filant_montage_2_3.jpg\"},{\"nom\":\"tartiflette\",\"ingredients\":[\"pomme de terre\",\"oignons\",\"crème fraiche\",\"lardons\",\"mozzarella\"],\"prix\":14,\"imageUrl\":\"https://cdn.pizzamatch.com/1/35/1375105305-pizza-napolitain-630.JPG?1375105310\"},{\"nom\":\"margherita\",\"ingredients\":[\"sauce tomate\",\"mozzarella\",\"basilic\"],\"prix\":7,\"imageUrl\":\"https://www.misteriosocultos.com/wp-content/uploads/2018/12/pizza.jpg\"},{\"nom\":\"indienne\",\"ingredients\":[\"curry\",\"mozzarella\",\"poulet\",\"poivron\",\"oignon\",\"coriandre\"],\"prix\":10,\"imageUrl\":\"https://assets.afcdn.com/recipe/20160519/15342_w1024h768c1cx3504cy2338.jpg\"},{\"nom\":\"mexicaine\",\"ingredients\":[\"boeuf\",\"mozzarella\",\"maïs\",\"tomates\",\"oignon\",\"coriandre\"],\"prix\":13,\"imageUrl\":\"https://fac.img.pmdstatic.net/fit/http.3A.2F.2Fprd2-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2FFAC.2Fvar.2Ffemmeactuelle.2Fstorage.2Fimages.2Fminceur.2Fastuces-minceur.2Fminceur-choix-pizzeria-47943.2F14883894-1-fre-FR.2Fminceur-comment-faire-les-bons-choix-a-la-pizzeria.2Ejpg/750x562/quality/80/crop-from/center/minceur-comment-faire-les-bons-choix-a-la-pizzeria.jpeg\"},{\"nom\":\"chèvre et miel\",\"ingredients\":[\"miel\",\"mozzarella\",\"fromage de chèvre\",\"roquette\"],\"prix\":10,\"imageUrl\":\"http://gfx.viberadio.sn/var/ezflow_site/storage/images/news/conso-societe/les-4-aliments-a-eviter-de-consommer-le-soir-00018042/155338-1-fre-FR/Les-4-aliments-a-eviter-de-consommer-le-soir.jpg\"},{\"nom\":\"napolitaine\",\"ingredients\":[\"sauce tomate\",\"mozzarella\",\"anchois\",\"câpres\"],\"prix\":9,\"imageUrl\":\"https://www.fourchette-et-bikini.fr/sites/default/files/pizza_tomate_mozzarella.jpg\"},{\"nom\":\"kebab\",\"ingredients\":[\"poulet\",\"oignons\",\"sauce tomate\",\"sauce kebab\",\"mozzarella\"],\"prix\":11,\"imageUrl\":\"https://res.cloudinary.com/serdy-m-dia-inc/image/upload/f_auto/fl_lossy/q_auto:eco/x_0,y_0,w_3839,h_2159,c_crop/w_576,h_324,c_scale/v1525204543/foodlavie/prod/recettes/pizza-au-chorizo-et-fromage-cheddar-en-grains-2421eadb\"},{\"nom\":\"louisiane\",\"ingredients\":[\"poulet\",\"champignons\",\"poivrons\",\"oignons\",\"sauce tomate\",\"mozzarella\"],\"prix\":12,\"imageUrl\":\"http://www.fraichementpresse.ca/image/policy:1.3167780:1503508221/Pizza-dejeuner-maison-basilic-et-oeufs.jpg?w=700&$p$w=13b13d9\"},{\"nom\":\"orientale\",\"ingredients\":[\"merguez\",\"champignons\",\"sauce tomate\",\"mozzarella\"],\"prix\":11,\"imageUrl\":\"https://www.atelierdeschefs.com/media/recette-e30299-pizza-pepperoni-tomate-mozza.jpg\"},{\"nom\":\"hawaïenne\",\"ingredients\":[\"jambon\",\"ananas\",\"sauce tomate\",\"mozzarella\"],\"prix\":12,\"imageUrl\":\"https://www.atelierdeschefs.com/media/recette-e16312-pizza-quatre-saisons.jpg\"},{\"nom\":\"reine\",\"ingredients\":[\"jambon\",\"champignons\",\"sauce tomate\",\"mozzarella\"],\"prix\":8,\"imageUrl\":\"https://static.cuisineaz.com/400x320/i96018-pizza-reine.jpg\"}]";
            // string pizzaJson = "";

            maListView.RefreshCommand = new Command((obj) =>
            {
                DownloadData((pizzas) =>
                {
                    maListView.ItemsSource = pizzas;
                    maListView.IsRefreshing = false;
                });
            });


            maListView.IsVisible = false;
            waitLayout.IsVisible = true;

            // ETAPE 1 on arrive dans le Main Page

            //Appel a ma fonction
            DownloadData((pizzas) =>
            {
                maListView.ItemsSource = pizzas;

                maListView.IsVisible = true;
                waitLayout.IsVisible = false;
                maListView.IsRefreshing = false;
            });


            // pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzaJson);
            //pizzas = new List<Pizza>();
            // pizzas.Add(new Pizza
            //     {nom = "végétariene", prix = 7, ingredients = new string[] {"tomate", "poivrons", "oignons"}, imageUrl = "https://m.bettybossi.ch/static/rezepte/x/bb_itku120801_0243a_x.jpg"});
            // pizzas.Add(new Pizza
            //     {nom = "Cannibale", prix = 12, ingredients = new string[] {"Viande", "pomme de terre", "oignons", "olive", "cheddar" , "chévre" ,"miel" , "lardon" , "camembert" , "crème fraiche" , "frites" , "Steak"}, imageUrl = "https://fac.img.pmdstatic.net/fit/http.3A.2F.2Fprd2-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2Ffac.2F2018.2F07.2F30.2F6aaa4088-b316-4160-a97d-74ec7ca71b07.2Ejpeg/750x562/quality/80/crop-from/center/cr/wqkgVGhpbmtzdG9jay9HZXR0eSBJbWFnZXMgLyBGZW1tZSBBY3R1ZWxsZQ%3D%3D/pizza-royale.jpeg"});
            // pizzas.Add(new Pizza
            //     {nom = "MONTAGNARDE", prix = 10, ingredients = new string[] {"tomate", "poivrons", "oignons"}, imageUrl = "https://www.toutlevin.com/img/a0fc4ba355969aa491841847eb63dcc1004740003000-960.jpg"});
            //completez le code
            // maListView.ItemsSource = pizzas;
        }

        public void DownloadData(Action<List<Pizza>> action)
        {
            const string URL = "https://drive.google.com/uc?export=download&id=1uQA0Bb_Ph73Uq-pr0xXq9sqh-kuClRNE";

            using (var webclient = new WebClient())
            {
                // pizzaJson = webclient.DownloadString(URL);

                webclient.DownloadStringCompleted += delegate(object sender, DownloadStringCompletedEventArgs e)
                {
                    // Console.WriteLine("Données télécharger: " + e.Result);
                    try
                    {
                        string pizzaJson = e.Result;
                        List<Pizza> pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzaJson);

                        //
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            action.Invoke(pizzas);
                        });
                    }
                    catch (Exception ex)
                    {
                        //thread réseau
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Erreur", "une erreur réseau s'est produite: " + ex.Message, "ok");
                            action.Invoke(null);
                        });
                        
                    }
                };

                webclient.DownloadStringAsync(new Uri(URL));
            }
        }
    }
}