using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA
{
    public enum TypeTransaction
    {
        Retrait, Depot, Transfert
    }

    public static class SelectionCompte
    {
        public static string selectedCompte = "";
    }

    public static class SelectionTransaction
    {
        public static string selectedTransac = "";
    }

    public static class DataGuichet
    {
        public static List<Compte> listeComptes = new List<Compte>();
        public static List<Client> listeClients = new List<Client>();
        public static List<Transaction> listeTransactions = new List<Transaction>();
    }
    
}
