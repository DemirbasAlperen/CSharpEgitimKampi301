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
    public partial class FrmLocation: Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();   // önce bir db nesne örneği alıyoruz
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();   // db içerisinde bulunan Location tablomu listele
            dataGridView1.DataSource = values;    // dataGridView1 in DataSource alanına values ten gelen değeri yazdır.

        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new     // Select metodu ve lambda expression kullanarak liste içerisinden sadece adı ve soyadını çağırıp bunu FullName içerisine atıyoruz. Bunu yaparken de GuideId kullanıyoruz.
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();        // Bu listeyi döndürecek            

            cmbGuide.DisplayMember = "FullName";   // comboBox1 in ön kısmında Guide nin adı ve soyadı gelmesi için yukarıda bu kısmı ayarladık
            cmbGuide.ValueMember = "GuideId";     // comboBox1 in arka planda çalışacak değeri GuideId kısmından gelen değer olacak 
            cmbGuide.DataSource = values;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();  // Location tablosu üzerinden bir tane location parametresi üret
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());  // Capacity nin veri türü tinyint olduğu için byte dönüşümü yaptık ve nudCapacity buradan gelen değerleri location un Capacity değeri içerisine atmasını sağladık
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);   // parayı decimal türüne parse ederek location içerisindeki Price içine atayacak
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());  // SelectedValue obje türündedir, bu yüzden önce bunu ToString() ile string e dönüştürüyoruz ki int.Parse() bunu işleyebilsin. => Bu kısımıda location nesnesinin GuideId özelliğine atamak için kullanıyoruz.
            db.Location.Add(location);   // parametreden(locationdan) gönderdiğim değeri Location tablosuna ekle
            db.SaveChanges(); // Değişiklikleri kayıt edecek
            MessageBox.Show("Ekleme İşlemi Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);   // string olan txtId yi Parse yaparak int e çevirdik ve id içerisine atadık
            var deletedValue = db.Location.Find(id); // Location içinden id ye göre değeri bulup deletedValue(silinecek değer) içine atayacak
            db.Location.Remove(deletedValue);   // deletedValue dan gelen değeri Location içinden sil
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);  // string olan txtId yi Parse ladık ve int id içerisine atadık
            var updatedValue = db.Location.Find(id);   // Location içinden id ye göre değeri bulup updatedValue(güncellenecek değer) içine atayacak
            updatedValue.DayNight = txtDayNight.Text;      // Location içindeki her bir sütun içeriği için veri erişimlerini sağladık
            updatedValue.Price = decimal.Parse(txtPrice.Text);
            updatedValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updatedValue.City = txtCity.Text;
            updatedValue.Country = txtCountry.Text;
            updatedValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}
