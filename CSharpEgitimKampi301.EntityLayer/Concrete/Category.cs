using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category      // Kategori Sınıfı // Oluşturulacak olan Category tablosuna ait değerleri tutacak 
    {
        #region Field-Property-Veriable

        int x;   // field

        public int y { get; set; }  // property

        void test()   // veriable
        {
            int z;
        }

        /*

        *** Field-Veriable-Property bunları ve bunlar arasındaki farkı bilmeyen yazılımcı olamaz ***

        * Bir değişken direkt olarak sınıf içine tanımlanırsa bu Field dir. ( int x; )

        * Bir değişken yapısı sonuna get ve set isimli iki değer alırsa bu bir Property olur. ( public int y { get; set; } )

        * Bir değer metot içinde tanımlanırsa bu kez Veriable(değişken) olur. ( void test() {int z;} )
 
        */

        #endregion

        public int CategoryId { get; set; }   // Burada birincil anahtar olarak algılanması için CategoryId olarak adlandırılması daha doğrudur, yoksa program algılamaz
        public string CategoryName { get; set; }    // prop yazıp tab basarsan property oluşur. get:almak, set:ayarlamak 
        public bool CategoryStatus { get; set; }     // Property oluşturuken oluşturmak istediğimiz verinin veri tipi mutlaka belirtilir.
        public List<Product> Products  { get; set; }  // Product sınıfında yapılan değişikliklerden Category sınıfını haberdar ettik. Burada çoğul(ürünler) olarak tanımladık
    }
}


