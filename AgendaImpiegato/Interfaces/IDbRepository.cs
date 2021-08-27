using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaImpiegato.Interfaces

{
    interface IDbRepository<T>
    {
       
        public List<T> Fetch();
      
        public void Update(T t);
        public void Delete(T t);
        public void Insert(T t);
       
    
    }
}
