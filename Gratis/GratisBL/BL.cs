using GratisDL;
using GratisBL;
namespace GratisBL;

public static class BL
{

    public static List<Musteriler> MusterilerList = new List<Musteriler>();


    public static bool MusteriEkle(Musteriler m, out string error)
    {

        var res = DL.MusteriEkle(m.ID, m.Ad, m.Soyad, m.Telefon, m.Mail, out error);
        if (res != -1)
        {
            MusterilerList.Add(m);
            return true;
        }

        return false;
    }

    public static bool MusteriGuncelle(Musteriler m, out string error)
    {

        var res = DL.MusteriEkle(m.ID, m.Ad, m.Soyad, m.Telefon, m.Mail, out error);
        if (res != -1)
        {
            var kisi = MusterilerList.Find(o => o.ID == m.ID);
            if (kisi != null)
            {
                kisi.Ad = m.Ad;
                kisi.Soyad = m.Soyad;
                kisi.Telefon = m.Telefon;
                kisi.Mail = m.Mail;
               
            }
            return true;
        }
        return false;
    }

    public static bool MusteriSil(Musteriler m, out string error)
    {

        var res = DL.MusteriSil(m.ID, out error);
        if (res != -1)
        {
            var kisi = MusterilerList.Find(o => o.ID == m.ID);
            if (kisi != null)
            {
                MusterilerList.Remove(kisi);
            }

            return true;
        }
        return false;
    }
  
}
