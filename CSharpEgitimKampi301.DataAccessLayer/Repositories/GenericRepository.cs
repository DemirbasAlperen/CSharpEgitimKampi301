using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class // T class olmak şartı ile IGenericDal dan miras alacak
    {
        KampContext context = new KampContext();  // KampContext sınıfından den context nesne örneği türettim
        private readonly DbSet<T> _object;   // DbSet türünde içine T değeri alan ismi _object olan bir field örnekledim.

        public GenericRepository()
        {
            _object = context.Set<T>();   // context ten gelen Set<T>(entity değerini Admin, Product...) değerini _object e atayacak
        }
        public void Delete(T entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;    // *** EntityState bizim için bir enum olarak gelir. Aslında ekleme, silme, güncelleme gibi işlemlere izin veren bir kod bloğu.*** 
            context.SaveChanges();   // Değişiklikleri kaydedecek.
        }

        public List<T> GetAll()   // Burada EntityState kullanmayız. Çünkü entity üzerinde yapacağım bir değişiklik yok sadece tüm listeyi getireceğim.
        {
            return _object.ToList();    // Listeyi döndürecek.
        }

        public T GetById(int id)   // Burada da EntityState kullanmayız. Çünkü sadece id ye göre değer getireceğiz. 
        {
            return _object.Find(id);    // Find ile id ye göre değer döndürecek bize.
        }

        public void Insert(T entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;      // EntityState ekleme işlemi
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updatedEntity = context.Entry(entity);     // updatedEntity oluşturuldu
            updatedEntity.State = EntityState.Modified;   // EntityState güncelleme işlemi. Yani yukarıda oluşturulan updatedEntity Entity Framework'e bu varlığın değiştirildiği belirtiliyor. 
            context.SaveChanges();   // Değişiklikler kayıt ediliyor.
        }
    }
}
