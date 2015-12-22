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
        public static string selectedCompteString = "";
    }

    public static class SelectionTransaction
    {
        public static string selectedTransac = "";
    }

    public static class ClientCourant
    {
        public static Client ClientActif = null;
        public static List<Compte> CompteActif = new List<Compte>();
        public static Compte compteCheque = null;
        public static Compte compteEpargne = null;
    }


    public static class DataGuichet
    {
        public static int totalGuichet = 0;
        public static List<Compte> listeComptes = new List<Compte>();
        public static List<Client> listeClients = new List<Client>();
        public static List<Transaction> listeTransactions = new List<Transaction>();
    }
    
}
