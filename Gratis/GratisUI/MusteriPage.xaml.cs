using GratisBL;
using GratisBL;

namespace GratisUI;

public partial class MusteriPage : ContentPage
{
    public MusteriPage()
    {
        InitializeComponent();
        listMusteriler.ItemsSource = BL.MusterilerList;

    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    string error;
   

    void AddKisi(Musteriler c)
    {
        var res = BL.MusteriEkle(c, out error);
        if (!res)
        {
            DisplayAlert("hata oluþtu", error, "OK");
        }
    }

    private void KisiEkleClicked(System.Object sender, System.EventArgs e)
    {
        MusteriEditPage page = new MusteriEditPage() { AddMetod = AddKisi };
        Navigation.PushModalAsync(page);
    }

    void KisileriYukleClicked(System.Object sender, System.EventArgs e)
    {
        KisileriYukle();
        refreshView.IsRefreshing = false;
    }

    void KisiDuzenleClicked(System.Object sender, System.EventArgs e)
    {
        var b = sender as ImageButton;
        if (b != null)
        {
            var kisi = BL.MusterilerList.First(o => o.ID == b.CommandParameter.ToString());
            MusteriEditPage page = new MusteriEditPage(kisi) { EditMetod = EditKisi };
            Navigation.PushModalAsync(page);
        }
    }

    private void EditKisi(Musteriler c)
    {
        BL.MusteriGuncelle(c, out error);
    }

    async void KisiSilClicked(System.Object sender, System.EventArgs e)
    {
        var b = sender as ImageButton;
        if (b != null)
        {
            var y = await DisplayAlert("silinsin mi?", "silmeyi onayla", "OK", "CANCEL");
            if (y)
            {
                var kisi = BL.MusterilerList.First(o => o.ID == b.CommandParameter.ToString());
                var res = BL.MusteriSil(kisi, out error);
                if (!res)
                {
                    await DisplayAlert("hata oluþtu", error, "OK");
                }
            }


        }
    }


}
