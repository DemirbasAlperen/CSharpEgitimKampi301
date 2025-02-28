using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();  // db isimli nesne örneği türettim ve entity min olduğu modele ulaşmış oldum. Bunu aşağıda bulunan her bir metot içinde yazmaktansa buraya scope dışına yazarsam aşağıdakilerin hepsi için geçerli olur.
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();    // Guide yazdıktan sonra . koyunca çıka tüm metodlar entity metotlarıdır. ToList() metodu bana tüm listeyi döndürecek. Ayrıca önceki derslerde yazdığımız sqlconnection bağlantı kodlarının tamamı burada tek bir satırlık koda indirgenmiştir
            dataGridView1.DataSource = values;   // dataGrid aracının DataSource veri kısmına values i yazdır.                               
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();   // Ekleme işlemi Guide içerisine yapılacağı için bir tane guide parametresi ürettim.
            guide.GuideName = txtName.Text;  // txtName den gelen değeri GuideName içine atayacak
            guide.GuideSurname = txtSurname.Text;  // txtSurname den gelen değeri GuideSurname içine atayacak
            db.Guide.Add(guide);   // Guide tablosu içine guide yi ekle
            db.SaveChanges();   // Değişiklikleri veri tabanına kaydetmek için kullanılır
            MessageBox.Show("Rehber başarıyla eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);      // Silme işlemi için id yi alacağımız aracı eşliyeceğiz. Ayrıca başlangıçta sadece string format kabul edildiğinden string dışında birşey kullandığımız için dönüşüm(Parse) uyguladık.
            var removeValue = db.Guide.Find(id);   // removeValue : silinecek değer // Find() metodu : Bir id ye göre değeri bulur. Örneğin id olarak 3 gönderirsem bana id si 3 olan satırı döndürür.
            db.Guide.Remove(removeValue);   // Guide tablosunda removeValue değişkeninden gelen değeri sil
            db.SaveChanges();  // Değişiklikleri kaydet
            MessageBox.Show("Rehber başarıyla silindi");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);       // Delete ile aynı
            var updateValue = db.Guide.Find(id);   // Delete ile aynı
            updateValue.GuideName = txtName.Text;   // updateValue(güncelleyeceğim değerin) deki GuideName artık txtName den gelsin.
            updateValue.GuideSurname = txtSurname.Text;  // name için yaptığımızı surname içinde yaptık
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);  // Parametre kullanarak mesaj verdik. Sırayla(mesaj, başlık, Ok butonu, Sarı renk uyarı ikonu)


        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);  // id kullandık
            var values = db.Guide.Where(x => x.GuideId == id).ToList();   // x öyle ki GuideId si bizim dışarıdan gönderdiğimiz id ye eşit olan değeri Tolist() metodu ile listele   // burada ilk defa lambda expression (=>) kullandık. Öyle ki diye okunur. Şartlar için kullanıyoruz. 
            dataGridView1.DataSource = values;  // Sadece şartımın sağlandığı değerleri bana getirecek 
        }
    }
}
