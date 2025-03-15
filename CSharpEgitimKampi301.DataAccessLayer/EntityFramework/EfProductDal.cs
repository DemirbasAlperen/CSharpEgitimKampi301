using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using CSharpEgitimKampi301.DataAccessLayer.Repositories;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Object> GetProductsWithCategory()
        {
            var context = new KampContext();   // KampContext() sınıfımızı çağırdık
            var values = context.Products      // context içerisinde Products(sql de ki tablomuz) a git
                .Select(x => new       
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductStock = x.ProductStock,
                    ProductPrice = x.ProductPrice,
                    ProductDescription = x.ProductDescription,
                    CategoryName = x.Category.CategoryName   // bu kısım hata verdi hatayı çözmek için Product sınıfına gidip NotMapped isminde attribute ekledik
                }).ToList();

            return values.Cast<object>().ToList();   // Cast ile obje ye dönüştürüp liste formatında bize döndürecek
        }
    }
}
