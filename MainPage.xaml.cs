using MauiAppH8Rehber.Model;

using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace MauiAppH8Rehber
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(filepath))
            {
                var data = File.ReadAllText(filepath);
                Kişiler = JsonSerializer.Deserialize<ObservableCollection<Kişi>>(data);
            }

            lstKisiler.ItemsSource = Kişiler;
        }

        const string filename = "kisiler.json";
        string filepath = Path.Combine(FileSystem.Current.AppDataDirectory, filename);

        void SaveKişiler()
        {
            var data = JsonSerializer.Serialize<ObservableCollection<Kişi>>(Kişiler);
            File.WriteAllText( filepath, data);
        }


        ObservableCollection<Kişi> Kişiler = new()
        {
            new Kişi()
            {
                Adı = "Ali",
                Soyadı = "Kara",
                Telefon = "0535 000 00 00",
                Mail = "alikara@mail.com",
                Resim = "dotnet_bot.png"
            },
            new Kişi()
            {
                Adı = "Ayşe",
                Soyadı = "Sarı",
                Telefon = "0544 000 00 00",
                Mail = "aysesari@mail.com",
                Resim = "dotnet_bot.png"
            },
            new Kişi()
            {
                Adı="Veli",
                Soyadı = "Beyaz",
                Telefon = "0532 333 33 33",
                Mail = "velibeyaz@mail.com",
                Adres = "Bartın",
                
            }

        };

        private async void Delete_Click(object sender, EventArgs e)
        {
            string id = (sender as MenuItem).CommandParameter.ToString();
            var res = await DisplayAlert("Silmeyi Onayla", "Silinsin mi?", "Evet", "Hayır");
            if (res)
                KişiSil(id);
        }
        private void ImageAdd_Click(object sender, EventArgs e)
        {
            string id = (sender as MenuItem).CommandParameter.ToString();
            Kişi k = Kişiler.First(o=>o.Id == id);
            ResimEkle(k);
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            string id = (sender as MenuItem).CommandParameter.ToString();
            var kişi = Kişiler.First(o => o.Id == id);

            var kp = new KisiPage(kişi);
            kp.KişiDüzenlemeMetodu = KişiDüzenle;
            kp.ResimEklemeMetodu = ResimEkle;
            Navigation.PushModalAsync(kp);

        }

        private void Add_Click(object sender, EventArgs e)
        {
            var kp = new KisiPage(new Kişi());
            kp.KişiEklemeMetodu = KişiEkle;
            Navigation.PushModalAsync(kp);
        }

        async void ResimEkle(Kişi k)
        {
            var res = await DisplayActionSheet("Resim Seç", null, null, "Galeri", "Kamera" );
            if (res == "Galeri")
            {

                var resim = await MediaPicker.Default.PickPhotoAsync();
                k.Resim = resim.FullPath;

            }
            else if (res == "Kamera")
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    var resim = await  MediaPicker.Default.CapturePhotoAsync();
                    k.Resim = resim.FullPath;
                }

            }
        }
        void KişiEkle(Kişi k)
        {
            Kişiler.Add(k);
        }

        void KişiDüzenle(string id, Kişi k)
        {
            var kişi = Kişiler.First(o => o.Id == id);
            kişi.Adı = k.Adı;
            kişi.Soyadı = k.Soyadı;
            kişi.Telefon = k.Telefon;
            kişi.Mail = k.Mail;
            kişi.Resim = k.Resim;
            kişi.Adres = k.Adres;
        }

        void KişiSil(string id)
        {
            var kişi = Kişiler.First(o => o.Id == id);
            Kişiler.Remove(kişi);
        }

        private void SaveData(object sender, EventArgs e)
        {
            SaveKişiler();
        }

        private void Kisileri_Kaydet_Click(object sender, EventArgs e)
        {
            SaveKişiler();
        }
    }

}
