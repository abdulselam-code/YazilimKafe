namespace SiparisHesapla;

public partial class MainPage : ContentPage
{
    // Kullanıcının o anda seçtiği kahvenin adı.
    string secilenUrun = "";

    // Seçilen kahvenin birim fiyatı.
    double birimFiyat = 0;

    // Bir ekstra espresso shot fiyatı.
    const double EkstraShotFiyati = 25;

    // Kullanıcının seçtiği sipariş türü.
    string siparisTuru = "";

    // Sepette bulunan bütün ürünleri tutar.
    List<SiparisKalemi> sepet = new List<SiparisKalemi>();


    public MainPage()
    {
        InitializeComponent();
    }


    // =====================================
    // SEPETTE TUTULACAK ÜRÜN SINIFI
    // =====================================

    public class SiparisKalemi
    {
        public string UrunAdi { get; set; } = "";

        public double BirimFiyat { get; set; }

        public int Adet { get; set; }

        public int EkstraShot { get; set; }

        public double ToplamFiyat { get; set; }
    }


    // =====================================
    // KAHVE SEÇİMİ
    // =====================================

    private void LatteButton_Clicked(
        object? sender,
        EventArgs e)
    {
        secilenUrun = "Latte";

        birimFiyat = 150;

        SecilenUrunLabel.Text =
            "Seçilen: Latte • 150 TL";

        UrunButonlariniSifirla();

        LatteButton.BackgroundColor =
            Color.FromArgb("#1F3A34");
    }


    private void AmericanoButton_Clicked(
        object? sender,
        EventArgs e)
    {
        secilenUrun = "Americano";

        birimFiyat = 120;

        SecilenUrunLabel.Text =
            "Seçilen: Americano • 120 TL";

        UrunButonlariniSifirla();

        AmericanoButton.BackgroundColor =
            Color.FromArgb("#1F3A34");
    }


    private void MochaButton_Clicked(
        object? sender,
        EventArgs e)
    {
        secilenUrun = "Mocha";

        birimFiyat = 170;

        SecilenUrunLabel.Text =
            "Seçilen: Mocha • 170 TL";

        UrunButonlariniSifirla();

        MochaButton.BackgroundColor =
            Color.FromArgb("#1F3A34");
    }


    private void UrunButonlariniSifirla()
    {
        LatteButton.BackgroundColor =
            Color.FromArgb("#C77B4A");

        AmericanoButton.BackgroundColor =
            Color.FromArgb("#C77B4A");

        MochaButton.BackgroundColor =
            Color.FromArgb("#C77B4A");
    }


    // =====================================
    // SİPARİŞ TÜRÜ
    // =====================================

    private void MasadaButton_Clicked(
        object? sender,
        EventArgs e)
    {
        siparisTuru = "Masada";

        SiparisTuruLabel.Text =
            "Sipariş Türü: Masada";

        SiparisTuruButonlariniSifirla();

        MasadaButton.BackgroundColor =
            Color.FromArgb("#1F3A34");
    }


    private void GelAlButton_Clicked(
        object? sender,
        EventArgs e)
    {
        siparisTuru = "Gel-Al";

        SiparisTuruLabel.Text =
            "Sipariş Türü: Gel-Al";

        SiparisTuruButonlariniSifirla();

        GelAlButton.BackgroundColor =
            Color.FromArgb("#1F3A34");
    }


    private void PaketButton_Clicked(
        object? sender,
        EventArgs e)
    {
        siparisTuru = "Paket";

        SiparisTuruLabel.Text =
            "Sipariş Türü: Paket";

        SiparisTuruButonlariniSifirla();

        PaketButton.BackgroundColor =
            Color.FromArgb("#1F3A34");
    }


    private void SiparisTuruButonlariniSifirla()
    {
        MasadaButton.BackgroundColor =
            Color.FromArgb("#C77B4A");

        GelAlButton.BackgroundColor =
            Color.FromArgb("#C77B4A");

        PaketButton.BackgroundColor =
            Color.FromArgb("#C77B4A");
    }


    // =====================================
    // STEPPER - EKSTRA SHOT
    // =====================================

    private void EkstraShotStepper_ValueChanged(
        object? sender,
        ValueChangedEventArgs e)
    {
        EkstraShotLabel.Text =
            "Ekstra Shot: " +
            e.NewValue.ToString("0");
    }


    // =====================================
    // SLIDER - BAHŞİŞ
    // =====================================

    private void BahsisSlider_ValueChanged(
        object? sender,
        ValueChangedEventArgs e)
    {
        double bahsis =
            Math.Round(e.NewValue);

        BahsisLabel.Text =
            "Bahşiş: %" +
            bahsis.ToString("0");
    }


    // =====================================
    // SİPARİŞE ÜRÜN EKLEME
    // =====================================

    private void SepeteEkleButton_Clicked(
        object? sender,
        EventArgs e)
    {
        // Kahve seçilmiş mi?
        if (string.IsNullOrWhiteSpace(secilenUrun))
        {
            SepetLabel.Text =
                "Lütfen önce bir kahve seçiniz.";

            return;
        }


        // Adet geçerli bir sayı mı?
        if (!int.TryParse(
            AdetEntry.Text,
            out int adet))
        {
            SepetLabel.Text =
                "Lütfen geçerli bir adet giriniz.";

            return;
        }


        // Adet sıfır veya negatif olamaz.
        if (adet <= 0)
        {
            SepetLabel.Text =
                "Ürün adedi en az 1 olmalıdır.";

            return;
        }


        // Stepper'dan ekstra shot sayısını alır.
        int ekstraShot =
            (int)EkstraShotStepper.Value;


        // Kahvelerin toplam fiyatını hesaplar.
        double urunToplami =
            birimFiyat * adet;


        // Ekstra shot ücretini hesaplar.
        double shotToplami =
            adet *
            ekstraShot *
            EkstraShotFiyati;


        // Bu sipariş kaleminin toplamı.
        double kalemToplami =
            urunToplami +
            shotToplami;


        // Yeni sipariş kalemi oluşturulur.
        SiparisKalemi yeniUrun =
            new SiparisKalemi
            {
                UrunAdi = secilenUrun,

                BirimFiyat = birimFiyat,

                Adet = adet,

                EkstraShot = ekstraShot,

                ToplamFiyat = kalemToplami
            };


        // Ürün sepete eklenir.
        sepet.Add(yeniUrun);


        // Sepetin ekrandaki görünümü güncellenir.
        SepetiGoster();


        // Bir sonraki ürün için seçim alanı temizlenir.
        UrunSeciminiTemizle();
    }


    // =====================================
    // SEPETİ EKRANDA GÖSTER
    // =====================================

    private void SepetiGoster()
    {
        if (sepet.Count == 0)
        {
            SepetLabel.Text =
                "Sepetiniz henüz boş.";

            return;
        }


        string sepetMetni = "";


        for (int i = 0; i < sepet.Count; i++)
        {
            SiparisKalemi urun =
                sepet[i];


            sepetMetni +=
                (i + 1) + ". " +
                urun.Adet + " x " +
                urun.UrunAdi + "\n";


            sepetMetni +=
                "Ekstra Shot: " +
                urun.EkstraShot + "\n";


            sepetMetni +=
                "Tutar: " +
                urun.ToplamFiyat.ToString("0.00") +
                " TL";


            if (i < sepet.Count - 1)
            {
                sepetMetni +=
                    "\n\n";
            }
        }


        SepetLabel.Text =
            sepetMetni;
    }


    // =====================================
    // YENİ ÜRÜN İÇİN SEÇİMİ TEMİZLE
    // =====================================

    private void UrunSeciminiTemizle()
    {
        secilenUrun =
            "";

        birimFiyat =
            0;


        SecilenUrunLabel.Text =
            "Henüz bir kahve seçilmedi.";


        AdetEntry.Text =
            "1";


        EkstraShotStepper.Value =
            0;


        EkstraShotLabel.Text =
            "Ekstra Shot: 0";


        UrunButonlariniSifirla();
    }


    // =====================================
    // SİPARİŞİ HESAPLA
    // =====================================

    private void HesaplaButton_Clicked(
        object? sender,
        EventArgs e)
    {
        // Müşteri adı girilmiş mi?
        if (string.IsNullOrWhiteSpace(MusteriAdiEntry.Text))
        {
            SonucLabel.Text =
                "Lütfen müşteri adını giriniz.";

            return;
        }


        // Sipariş türü seçilmiş mi?
        if (string.IsNullOrWhiteSpace(siparisTuru))
        {
            SonucLabel.Text =
                "Lütfen sipariş türünü seçiniz.";

            return;
        }


        // Sepette ürün var mı?
        if (sepet.Count == 0)
        {
            SonucLabel.Text =
                "Lütfen siparişe en az bir ürün ekleyiniz.";

            return;
        }


        // Text özelliği null olabileceği için
        // null durumunda boş string kullanılır.
        string musteriAdi =
            MusteriAdiEntry.Text ?? "";


        // Sepetteki ürünlerin ara toplamı.
        double araToplam =
            0;


        foreach (SiparisKalemi urun in sepet)
        {
            araToplam +=
                urun.ToplamFiyat;
        }


        // Slider'dan bahşiş yüzdesi alınır.
        double bahsisOrani =
            Math.Round(BahsisSlider.Value);


        // Bahşiş tutarı hesaplanır.
        double bahsisTutari =
            araToplam *
            bahsisOrani /
            100;


        // Genel toplam hesaplanır.
        double toplamTutar =
            araToplam +
            bahsisTutari;


        // Toplam ürün adedi hesaplanır.
        int toplamUrunAdedi =
            0;


        foreach (SiparisKalemi urun in sepet)
        {
            toplamUrunAdedi +=
                urun.Adet;
        }


        // Siparişte alınan ürünleri
        // özet alanında göstermek için hazırlar.
        string siparisDetayi =
            "";


        foreach (SiparisKalemi urun in sepet)
        {
            siparisDetayi +=
                urun.Adet + " x " +
                urun.UrunAdi + "\n" +

                "Ekstra Shot: " +
                urun.EkstraShot + "\n" +

                "Tutar: " +
                urun.ToplamFiyat.ToString("0.00") +
                " TL\n\n";
        }


        // Sipariş özeti ekranda gösterilir.
        SonucLabel.Text =
            "Müşteri: " +
            musteriAdi + "\n" +

            "Sipariş Türü: " +
            siparisTuru + "\n\n" +

            "Alınan Ürünler:\n\n" +

            siparisDetayi +

            "Toplam Ürün Adedi: " +
            toplamUrunAdedi + "\n" +

            "Ara Toplam: " +
            araToplam.ToString("0.00") +
            " TL\n" +

            "Bahşiş: %" +
            bahsisOrani.ToString("0") +
            "\n" +

            "Bahşiş Tutarı: +" +
            bahsisTutari.ToString("0.00") +
            " TL";


        // Genel toplam büyük alanda gösterilir.
        ToplamLabel.Text =
            toplamTutar.ToString("0.00") +
            " TL";
    }


    // =====================================
    // YENİ SİPARİŞ
    // =====================================

    private void YeniSiparisButton_Clicked(
        object? sender,
        EventArgs e)
    {
        // Sepetteki bütün ürünler silinir.
        sepet.Clear();


        // Müşteri adı temizlenir.
        MusteriAdiEntry.Text =
            "";


        // Sipariş türü sıfırlanır.
        siparisTuru =
            "";


        SiparisTuruLabel.Text =
            "Henüz sipariş türü seçilmedi.";


        // Ürün seçimleri sıfırlanır.
        UrunSeciminiTemizle();


        // Bahşiş sıfırlanır.
        BahsisSlider.Value =
            0;


        BahsisLabel.Text =
            "Bahşiş: %0";


        // Sepet temizlenir.
        SepetLabel.Text =
            "Sepetiniz henüz boş.";


        // Sonuç alanı temizlenir.
        SonucLabel.Text =
            "Siparişiniz henüz hesaplanmadı.";


        // Genel toplam sıfırlanır.
        ToplamLabel.Text =
            "0.00 TL";


        // Sipariş türü butonları
        // başlangıç rengine döner.
        SiparisTuruButonlariniSifirla();
    }
}