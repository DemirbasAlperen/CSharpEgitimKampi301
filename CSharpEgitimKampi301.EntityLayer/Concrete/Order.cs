using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Order   // Sipariş Sınıfı
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }  // hangi ürünün satıldığı bilinmeli
        public virtual Product Product { get; set; }  // Product türünde bir Product property si olmalı
        public int Quantity { get; set; }    // kaç adet satıldı
        public decimal UnitPrice { get; set; }  // birim fiyatı
        public decimal TotalPrice { get; set; }   // toplam fiyat
        public int CustomerId { get; set; }   // Bu ürün kime satıldı
        public virtual Customer Customer { get; set; }  // Müşterinin diğer bilgilerine ulaşabilmek için Customer türünde Customer property si oluşturduk
    }
}
