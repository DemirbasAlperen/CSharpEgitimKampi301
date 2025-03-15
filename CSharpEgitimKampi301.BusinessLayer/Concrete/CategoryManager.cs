using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;   // _categoryDal isminde field(class içinde direkt olarak tanımlandı) örnekledik. Sonra ctrl + . ya tıkladık ve Generate Constructor(aşağıda) oluşturduk

        public CategoryManager(ICategoryDal categoryDal)   // Yapıcı metot
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);   // Delete metodu DataAccess de  ve entity den gelen değeri silecek
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();  // Listeleme işlemi
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);   // id den gelen değere göre bize getirir.
        }

        public void TInsert(Category entity)
        {
            _categoryDal.Insert(entity);      // Ekleme işlemi
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);     // Güncelleme işlemi
        }

        // Burada DataAccessLayer katmanındaki metotlarımı, Business katmanı metotlarımın içine çağırdım. 
    }
}
