using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GratisBL;

public class Musteriler : INotifyPropertyChanged
{

    private string id = null;
    private string ad, soyad, telefon, mail;

    public String ID
    {
        get
        {
            if (id == null)
            {
                id = Guid.NewGuid().ToString();
            }
            return id;
        }
        set
        {
            id = value;
        }
    }

    public string Ad
    {
        get => ad;
        set
        {
            ad = value;
            NotifyPropertyChanged();
            NotifyPropertyChanged("AdSoyad");

        }
    }

    public string Soyad
    {
        get => soyad;
        set
        {
            soyad = value;
            NotifyPropertyChanged();
            NotifyPropertyChanged("AdSoyad");
        }
    }

    public string Telefon
    {
        get => telefon;
        set
        {
            telefon = value;
            NotifyPropertyChanged();
        }
    }

    public string Mail
    {
        get => mail;
        set
        {
            mail = value;
            NotifyPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
