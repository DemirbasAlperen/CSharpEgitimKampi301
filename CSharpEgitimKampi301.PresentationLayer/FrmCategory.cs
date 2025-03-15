using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmCategory: Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()         // Burada kullanılan yöntem çok doğru bir yöntem değil sadece sürdürülebilir bir yöntem.
        {
            _categoryService = new CategoryManager(new EfCategoryDal());    // CategoryManager sınıfından bir nesne örnekledim ve parametre olarak benden ICategoryDal a karşılık gelen bir değer istiyor bende EfCategoryDal() ı çağırdım. Sonra Ctrl + . ile Add reference to ... seçeneğini seçtim ve referans olarak eklemiş oldum.
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)    // Listeleme
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)    // Ekleme
        {
            Category category = new Category();  // entity den alınan nesne örneği
            category.CategoryName = txtCategoryName.Text;  
            category.CategoryStatus = true;
            _categoryService.TInsert(category);   // category den gelen değerler _categoryService e eklenecek
            MessageBox.Show("Ekleme başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)  // Silme 
        {
            int id = int.Parse(txtCategoryId.Text);    // id yi int türüne parse ettik.  
            var deletedValues = _categoryService.TGetById(id);   // id den gelen değeri bulacak
            _categoryService.TDelete(deletedValues);    // deletedValues den gelen değeri sil
            MessageBox.Show("Silme başarılı");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int idGetir = int.Parse(txtCategoryId.Text);
            var values = _categoryService.TGetById(idGetir);
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedId = int.Parse(txtCategoryId.Text);
            var updatedValue = _categoryService.TGetById(updatedId);  // updatedId buraya gelen id değeri updatedValue buraya atanacak
            updatedValue.CategoryName = txtCategoryName.Text;
            updatedValue.CategoryStatus = true;
            _categoryService.TUpdate(updatedValue);
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
