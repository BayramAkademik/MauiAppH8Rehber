using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppH8Rehber.Model
{
    public class Kişi : INotifyPropertyChanged
    {

        string id, ad,soyad,telefon,mail,adres,resim;

        public string Id
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set { id = value;
                OnPropertyChanged();
            }
        }
        public string Adı
        {
            get { return ad; }
            set { ad = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AdSoyad));
            }
        }
        public string Soyadı
        {
            get { return soyad; }
            set
            {
                soyad = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AdSoyad));
            }
        }
        public string AdSoyad => Adı + " " + Soyadı;

        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged();
            }
        }
        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                OnPropertyChanged();
            }
        }
        public string Adres
        {
            get { return adres; }
            set
            {
                adres = value;
                OnPropertyChanged();
            }
        }
        public string Resim
        {
            get { return resim; }
            set
            {
                resim = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void  OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
