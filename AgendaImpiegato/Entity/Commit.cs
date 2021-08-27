using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaImpiegato.Entity
{
    class Commit
    {


        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateExpiration { get; set; }
        public _Importance Priority { get; set; }
        public bool IsFlag { get; set; }
        public int? Id { get; set; }



        public Commit( string title, string description, DateTime dateExpiration, _Importance priority, bool flag, int? id)

        {
            Title = title;
            Description = description;
            DateExpiration = dateExpiration;
            Priority = priority;
            IsFlag = flag;
            Id = id;
        }

        public Commit()
        {
        }






        public string Print()
        {
            return $"{Title} - {Description} - {DateExpiration} - {Priority}  - {DateExpiration} - {IsFlag}";
        }

        public enum _Importance
        {
            Alta,
            Media,
            Bassa
        }



       
    }
}
