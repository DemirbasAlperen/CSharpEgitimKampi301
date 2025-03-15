using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Repositories;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.EntityFramework
{
    // GenericRepository içinde tanımladığımız T ler burada entity olarak değişecek
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal   // GenericRepository den Admin sınıfı için ve IAdminDal dan miras aldık.
    {
    }
}

/*
 Entity ye özgü olmayan metodlar: Ekle, Sil, Güncelle, Listele, Id'ye Göre Getir (sistemdeki bütün entitler için geçerlidir.)

// İçinde a harfi geçmeyen kullanıcıları liste dersem o zaman entity ye özgü bir metot olur.
 */
