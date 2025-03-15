using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class   // dışarıdan T alacak ve bu T class olmak zorunda 
    {
        // Aşağıdaki metotları IGenericDal içinden aldık ikisi karışmasın diye metot isimlerinin başına T yazdık.
        // PresentatonLayer da çağırırken başında T olan metotları çağıracağızki DataAccessLayer a doğrudan erişmemiş olalım.
        void TInsert(T entity);   
        void TUpdate(T entity);   
        void TDelete(T entity);   
        List<T> TGetAll();   
        T TGetById(int id);
    }
}
