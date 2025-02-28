using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Product   // Ürün Sınıfı
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }    // Her ürünün bir CategoryId si olacak bu yüzden tekil olarak eklendi
        public virtual Category Category { get; set; }   // Category türünde bir prop tanımladık. (Product(ürün) tablosu üzerinden Category tablosuna gidebilmek için)
        // virtual : asp.net core da kullanılmıyor artık ama .net framework projelerinde hala var.

        public List<Order> Orders { get; set; }    // Order sınıfı ile çoğul olarak ilişki kuruldu. Ürün tablosu bir listeye dönüşmüş oldu
    }
}
