using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics: Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();   // önce bir db nesnesi örneği türettim
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            // Toplam Lokasyon Sayısı için: 
            lblLocationCount.Text = db.Location.Count().ToString();   // lblLocationCount bunu string formatta yazıyoruz.

            // Toplam Kapasite için:
            lblSumCapasity.Text = db.Location.Sum(x => x.Capacity).ToString();  // Her satırın kapasite değerleri toplanacak ve lblSumCapasity ye string olarak atanacak

            // Rehber Sayısı için:
            lblGuideCount.Text = db.Guide.Count().ToString();   // Rehber tablosundan rehber sayısını string formatında lblGuideCount içine atıyoruz.

            // Ortalama Kapasite için: 
            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity)?.ToString("F2");    // Location tablosunun kapasite sütununun ortalamasını alıp string formatında lblAvgCapacity içine atayacak.

            // Ortalama Tur Fiyatı için:
            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price)?.ToString("F2") + "₺";    // Location tablosunun Fiyat sütununun ortalamasını alıp string formatında lblAvgLocationPrice içine atayacak. Virgül den sonra 2 basamak yazması için F2 kullandık ve ToString metodu hata vermemesi için ?(null kontrolü) işareti koyduk
            // lblAvgLocationPrice.Text = Math.Round((decimal)db.Location.Average(x => x.Price), 2).ToString("F2") + "₺";    // 2 .yöntem

            // Eklenen Son Ülke için:
            int lastCountryId = db.Location.Max(x=>x.LocationId);     // önce eklenen son ülkenin id sini buluyoruz. Bunu en büyük(Max) id numarası ile bulabiliriz.
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();   // Önce yukarıdaki işlemi kendi tabloma yansıtarak en yüksek id değerine eriştim, sonra bulunduğum id de bu ülkenin ismini seçtik, en son tüm liste değil tek bir isim getirmek istediğim için FirstOrDefault() metodunu kulandım.

            // Kapadokya Tur Kapasitesi için:
            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();   // Önce Location tablomdan where şartı kullanarak Kapadokya şehrine erişiyoruz. Sonra select kullanarak capacity değerine erişiyoruz. Eriştiğimiz değer sayı olduğundan bu değeri string e dönüştürüyoruz.           

            // Türkiye Turları Ortalama Kapasitesi için:
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();  // Önce Location tablosundan where kullanarak ülkeye erişiyoruz. Sonra kapasitenin ortalamasını alıyoruz. Son olarak ortalamayı string formata dönüştürüyoruz.

            // Roma Gezisinin Rehberinin İsmi için: burada alt sorgu var
            var romeGuideId = db.Location.Where(x => x.City == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();      // Önce Location tablosunda Roma Turistik şehrinin GuideId sini yakaladım. 
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();      // sonra rehber tabosuna gidip id si romeGuideId ye eşit olan değerin isim ve soyismini getirmiş oldum.

            // En Yüksek Kapasiteli Tur için:
            var maxCapacity = db.Location.Max(x => x.Capacity);   // önce Location tablosundan maksimum Capacity(80) yi bulup maxCapacity ye atıyoruz.
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();   // burada Location tablomuzdan maxCapacity ye erişiyoruz ve bu değere eşit olan City değerini string olarak ve tek(FirstOrDefault()) başına çekiyoruz.

            // En Pahalı Tur için:
            var maxPrice = db.Location.Max(x => x.Price);   // önce Location tablosundan maksimum Price yi bulup maxPrice ye atıyoruz.
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();    // location tablosundan max price değerine eşit olan City yi string formatta ve sadece o şehri lblMaxPriceLocation sayacına atıyoruz.

            // Ayşegül Çınar Tur Sayısı için:
            var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();    // Rehber tablosundan where şartı kullanarak Ayşegül Çınar isimli kişinin Id sini guideIdByNameAysegulCinar içine attık
            lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();    // Location tablosunda bulunan GuideId değerine yukarıdaki hesapladığımız guideIdByNameAysegulCinar değerini eşitleyip, değerini string formatta lblAysegulCinarLocationCount sayacına atıyoruz.

        }

    }
}
