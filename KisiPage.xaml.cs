using MauiAppH8Rehber.Model;

namespace MauiAppH8Rehber
{
	public partial class KisiPage : ContentPage
	{
		Kişi kisi;
		public KisiPage(Kişi k)
		{
			InitializeComponent();
			kisi = k;
			BindingContext = kisi;
		}

		public Action<Kişi> KişiEklemeMetodu;
		public Action<string,Kişi> KişiDüzenlemeMetodu;
		public Action<Kişi> ResimEklemeMetodu;

        private void OkClicked(object sender, EventArgs e)
        {
			if (KişiEklemeMetodu != null)
				KişiEklemeMetodu(kisi);
			else if (KişiDüzenlemeMetodu != null)
				KişiDüzenlemeMetodu(kisi.Id, kisi);

            Navigation.PopModalAsync();
        }

        private void CancelClicked(object sender, EventArgs e)
        {
			Navigation.PopModalAsync();
        }

        private void ResimClicked(object sender, EventArgs e)
        {
			if (ResimEklemeMetodu != null)
				ResimEklemeMetodu(kisi);
        }
    }
}