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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)    // Yapıcı metot
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
            // if(yetki varsa)               // Bu koşullar Logic kurallarıdır.
            // {
            //      listeleme yap
            // }
            // else(yetki yoksa)
            // {
            //      uyarı ver
            // }

            return _customerDal.GetAll(); 
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)    // burada genellikle manuel yötem kullanılır fakat .net core da bu kadar manuel işlem olmaz.
        {
            if (entity.CustomerName!="" && entity.CustomerName.Length>=3 && entity.CustomerCity!=null && entity.CustomerSurname!="" && entity.CustomerName.Length <= 30)  // Validasyon kuralı yazımı. Buradaki entityler Customer sınıfını temsil eder.
            {
                _customerDal.Insert(entity);
                // şart sağlarsa ekleme işlemi yap
            }
            else
            {
                // şart sağlamıyorsa hata mesajı ver
            }
        }

        public void TUpdate(Customer entity)
        {
            if(entity.CustomerId!=0 && entity.CustomerCity.Length >= 3)
            {
                _customerDal.Update(entity);
            }
            else
            {
                // hata mesajı
            }
            
        }
    }
}
