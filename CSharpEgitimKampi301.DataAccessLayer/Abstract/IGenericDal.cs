using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class   // dışarıdan bir T (bizim entitlerimiz Category, Customer, Order ...) al ve bu T değeri mutlaka class olmalı (sadece sınıflar ile çalışıyor olacağız)
    {
        // CRUD işlemlerini bütün entitylere özgün olarak yapacağız ve burada bunları generic hale getirdik
        void Insert(T entity);   // eklemek
        void Update(T entity);   // güncelleme
        void Delete(T entity);    // Silme : T türünde entiy parametresi kullandık
        List<T> GetAll();   // Bütün verileri getirecek olan GetAll isminde metot tanımladık
        T GetById(int id);  // T türünde dışarıdan int id parametresi alan bir metot tanımladık
    }
}
