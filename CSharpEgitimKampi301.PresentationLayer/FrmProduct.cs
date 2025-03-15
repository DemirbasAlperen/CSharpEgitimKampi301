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
    public partial class FrmProduct: Form
    {
        private readonly IProductService _productService;     // IProductService den bir tane _productService örnekledim.
        private readonly ICategoryService _categoryService;   // ICategoryService den bir tane _categoryService örnekledim. 
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());   // _categoryService i buraya tanımlayıp CategoryManeger ı çağırıp EfCategoryDal da bunu örnekledim.
        }
        // Aşağıdaki kısım yerine yukarıdakini gibi yazdık ve bu kodu FrmProduct içine biraz değiştirip kopyaladık.
        // ProductManager productManager = new ProductManager(new EfProductDal());   // ProductManager sınıfından bir tane productManager nesne örneği türetiyorum.
        private void btnList_Click(object sender, EventArgs e)    // birinci listeleme
        {
            var values = _productService.TGetAll();   
            dataGridView1.DataSource = values;
        }

        private void btnList2_Click(object sender, EventArgs e)   // ikinci listeleme
        {
            var values = _productService.TGetProductsWithCategory();  // TGetProductsWithCategory() --> Product entity sine özgü bir metot 
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);     // önce id aldım
            var value = _productService.TGetById(id);  // sonra tanımladığım servis ile id ye eriştim ve onu value içerisine atadım.
            _productService.TDelete(value);   // value değerine atanan id yi sildim
            MessageBox.Show("Silme İşlemi Başarılı"); 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();   // Product sınıfından product nesne örneği türettim.
            product.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());          // product tan gelecek değerleri atadım
            product.ProductPrice = decimal.Parse(txtProductPrice.Text);
            product.ProductName = txtProductName.Text;
            product.ProductDescription = txtDescription.Text;
            product.ProductStock = int.Parse(txtProductStock.Text);
            _productService.TInsert(product);      // oluşturduğum nesne örneğini ekleme işlemş için kullandım
            MessageBox.Show("Ekleme İşlemi Yapıldı");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);   // id ye ihtiyacım var
            var value = _productService.TGetById(id);   // TGetById servisi ile id çektim ve value içine atadım
            dataGridView1.DataSource = value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);   // önce id aldım
            var value = _productService.TGetById(id);  // TGetById servisi ile id çektim ve value içine atadım
            value.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());  // Kategorilerin seçimi için yazdık
            value.ProductDescription = txtDescription.Text;   // value içerisine atamalarımı yaptım
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductStock = int.Parse(txtProductStock.Text);
            value.ProductName = txtProductName.Text;
            _productService.TUpdate(value);    // servisimde bulunan güncelleme metodu içine value değerlerini atadım
            MessageBox.Show("Güncelleme İşlemi Başarılı");

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();  // TGetAll metodu ile Category listesini values içerisine atadık
            cmbCategory.DataSource = values;
            cmbCategory.DisplayMember = "CategoryName";  // kullanıcıya görünecek olan kısım CategoryName olacak
            cmbCategory.ValueMember = "CategoryId";      // cmbCategory arka planda çalışacak olan değeri CategoryId olacak
            // Burada yapılan işlemler sonucunda form da görünen Kategori kısmında kategorilerim ismiyle görünecek ve ben istediğimi buradan seçebileceğim
        }
    }
}
