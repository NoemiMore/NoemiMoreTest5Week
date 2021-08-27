using AgendaImpiegato.Entity;
using AgendaImpiegato.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AgendaImpiegato.Entity.Commit;
using System.Data;

namespace AgendaImpiegato.ListRepository
{
    class CommitListRepository: ICommitRepository
    {

        public static List<Commit> commits = new List<Commit>
        {
            new Commit("Studio", "studiare cap.4-5", "2021, 10,12", _Importance.Media, false, null),
            new Commit("Lavoro", "Riunione ore 15.00", ("2021,08,28"), _Importance.Alta, false, null),
            new Commit("Sport", "Palestra ore 19.00", (2021,08,28), _Importance.Bassa, false, null)
        };

        public void Delete(Commit commit)
        {
            commits.Remove(commit);
        }

        public List<Commit> Fetch()
        {
             return commits;
        }

        public void Insert(Commit commit)
        {
            commits.Add(commit);
        }

        public void Update(Commit commit)
        {
            Insert(commit);
        }
    }
}
