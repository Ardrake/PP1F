using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA
{
    // data type de transaction
    public enum TypeTransaction
    {
        Retrait, Depot, TransfertRetrait, TransfertDepot, Facture, Frais, Interet
    }

    // sauvegarde objet selection du compte
    public static class SelectionCompte
    {
        public static string selectedCompteString = "";
    }

    //sauvegarde objet selection du type de transaction
    public static class SelectionTransaction
    {
        public static string selectedTransac = "";
    }

    // sauvegarde du compteur de transaction
    public static class Compteur
    {
        public static int compteurTransac = 0;
    }

    // storage temporaire des datas client courant pour la transaction
    public static class ClientCourant
    {
        public static Client ClientActif = null;
        public static List<Compte> CompteActif = new List<Compte>();
        public static Compte compteCheque = null;
        public static Compte compteEpargne = null;
    }

    // Data gucihet automatique
    public static class DataGuichet
    {
        public static int totalGuichet = 0;
        public static List<Compte> listeComptes = new List<Compte>();
        public static List<Client> listeClients = new List<Client>();
        public static List<Transaction> listeTrasanction = new List<Transaction>();
    }
    
}
