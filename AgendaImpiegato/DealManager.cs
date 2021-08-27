using AgendaImpiegato.AdoRepository;
using AgendaImpiegato.Entity;
using AgendaImpiegato.Interfaces;
using AgendaImpiegato.ListRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AgendaImpiegato.Entity.Commit;

namespace AgendaImpiegato
{
    class DealManager
    {
        // static CommitListRepository commitRepository = new CommitListRepository();
        static CommitRepository commitRepository = new CommitRepository();


        // metodi menu
        internal static void ShowCommit()
        {
            List<Commit> commits = commitRepository.Fetch();
            foreach (var commit in commits)
                Console.WriteLine(commit.Print());
        }




        internal static void UpdateCommit()
        {
            List<Commit> commits = commitRepository.Fetch();
            int i = 1;
            foreach (var c in commits)
            {
                Console.WriteLine($"Premi {i} per modificare la {c.Print()}");
                i++;
            }
            bool isInt;
            int choosenCommit;
            do
            {
                Console.WriteLine("Quale impegno?");

                isInt = int.TryParse(Console.ReadLine(), out choosenCommit);

            } while (!isInt || choosenCommit<= 0 || choosenCommit > commits.Count);

            Commit commit  = commits.ElementAt(choosenCommit - 1);
            if (commit.Id == null)
            {
                commitRepository.Delete(commit);
            }

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Vuoi modificare il titolo?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                commit.Title = InsertTitle();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la descrizione?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                commit.Description = InsertDescription();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la data?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                commit.DateExpiration = InsertDateExpiration();
            }



            do
            {
                Console.WriteLine("Vuoi modificare la priorità?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                commit.Priority = (_Importance)InsertPriority();
            }

            do
            {
                Console.WriteLine("Vuoi modificare lo stato del tuo impegno?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                commit.IsFlag = InsertIsFlag();
            }


           








            commitRepository.Update(commit);
        }

        internal static void ShowFinishCommit()
        {
            throw new NotImplementedException();
        }

        internal static void ShowPriorityCommit()
        {
            throw new NotImplementedException();
        }

        internal static void ShowNextCommit()
        {
            throw new NotImplementedException();
        }






        internal static void InsertCommit()
        {
            Commit commit = new Commit();
            commit.Title = InsertTitle();
            commit.Description = InsertDescription();
            commit.DateExpiration = InsertDateExpiration();
            commit.Priority = (_Importance)InsertPriority();
            commit.IsFlag = InsertIsFlag();

        }





        internal static void DeleteCommit()
        {
            List<Commit> commits = commitRepository.Fetch();
            int count = 1;
            int choose;
            bool isInt;
            do
            {
                foreach (var commit in commits)
                {
                    Console.WriteLine($"Premi {count} per cancellare {commit.Print()}");
                    count++;
                }
                Console.WriteLine("Quale impegno vuoi eliminare?");
                isInt = int.TryParse(Console.ReadLine(), out choose);
            } while (!isInt || choose <= 0 || choose > commits.Count());

            var commitToDelete = commits.ElementAt(--choose);
            commitRepository.Delete(commitToDelete);

        }

        private static bool InsertIsFlag()
        {
            bool continuare = true;
            string IsFlag;
            do
            {
                Console.WriteLine("E' touch? Scrivi si o no");
                IsFlag = Console.ReadLine();
                if (IsFlag == "si" || IsFlag == "no")
                    continuare = false;
            } while (continuare);

            return IsFlag == "si" ? true : false;
        }

      
       

        private static object InsertPriority()
        {
            bool isInt;
            int choose;
            do
            {
                Console.WriteLine($"Premi {(int)_Importance.Alta} per scegliere il sistema operativo {_Importance.Alta}");
                Console.WriteLine($"Premi {(int)_Importance.Media} per scegliere il sistema operativo {_Importance.Media}");
                Console.WriteLine($"Premi {(int)_Importance.Bassa} per scegliere il sistema operativo {_Importance.Bassa}");

                isInt = int.TryParse(Console.ReadLine(), out choose);
            } while (!isInt || choose < 0 || choose > 2);

            return (_Importance)choose;
        }

        private static DateTime InsertDateExpiration()
        {
            DateTime date;
            

           

            do
            {
                Console.WriteLine("Inserisci la data: ");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out date) || date > DateTime.Now); 
            return date;
        }

        private static string InsertDescription()
        {
            string description = String.Empty;
            do
            {
                Console.WriteLine("Inserisci la descrizione");
                description = Console.ReadLine();
            } while (String.IsNullOrEmpty(description));

            return description;
        }





        private static string InsertTitle()
        {

            string title = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il Titolo");
                title = Console.ReadLine();
            } while (String.IsNullOrEmpty(title));

            return title;
        }
    }


  

























       

    
}
