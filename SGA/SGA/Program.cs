using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGA
{
    public class Program
    {
        // Logic dépot guichet
        public static void DepotGuichet(int montant = 5000)
        {
            if (DataGuichet.totalGuichet + montant <= 20000)
            {
                DataGuichet.totalGuichet += montant;
            } 
        }

        // Ecrire la transaction dans le fichier transaction
        public static void EcrireTransac(Transaction transac)
        {
            string datetransac = DateTime.Now.ToShortDateString();
            string fname = "transaction_" + datetransac + ".dat";
            if (!File.Exists(fname))
            {
                using (StreamWriter sw = File.CreateText(fname))
                {
                    sw.WriteLine("Fichier des transaction pour le " + datetransac);
                }
            }
            using (StreamWriter sw = File.AppendText(fname))
            {
                sw.WriteLine(DateTime.Now.ToShortDateString() + ";" + DateTime.Now.ToShortTimeString() + ";" + Compteur.compteurTransac + ";" + transac.TypeTransaction + ";" + transac.TransactionCompte.NumeroDeCompte + ";" + transac.Montant + ";" + transac.Balance);
            }
        }

        //load la nouvelle valeur du compteur - pour les transaction
        public static int GetCompteurValue(string fname)
        {
            if (!File.Exists(fname))
            {
                return 1;
            }
            StreamReader sr = new StreamReader(fname);
            string valeur = sr.ReadLine();
            int compteur = int.Parse(valeur);
            sr.Close();
            return compteur;
        }

        //save la valeur courante du compteur dans un fichier
        public static void SetCompteurValue(string fname, int valeur)
        {
            if (File.Exists(fname))
            {
                File.Delete(fname);
            }

            using (StreamWriter sw = File.CreateText(fname))
            {
                sw.WriteLine(valeur);
            }
        }

        //Sauvegarde du data quichet 
        public static void SauvegarderFichier(string fname)
        {
            
            if (File.Exists(fname))
            {
                File.Delete(fname);
            }
            //B; 0000; 00000; 15000
            //C; D001; 10001; 457.98

            using (StreamWriter sw = File.CreateText(fname))
            {
                sw.WriteLine("B;0000;00000;"+DataGuichet.totalGuichet);
            }

            foreach (Compte item in DataGuichet.listeComptes)
            {
                using (StreamWriter sw = File.AppendText(fname))
                {
                    string typecompte = "";
                    if (item.GetType() == typeof(Epargne))
                    {
                        typecompte = "E";
                    }
                    if (item.GetType() == typeof(Cheque))
                    {
                        typecompte = "C";
                    }
                    sw.WriteLine(typecompte + ";" + item.NumeroDeClient + ";" + item.NumeroDeCompte + ";" + item.Balance);
                }
            }
        }

        // load le data guicher en memoire
        public static void OuvrirFichier(string fname)
        {
            StreamReader sr = new StreamReader(fname);
            string[] tab;

            while (sr.Peek() >= 0)
            {
                string valeur = sr.ReadLine();
                tab = valeur.Split(';');
                if (fname == "Clients.txt")
                {
                    // Korben Dallas;D001
                    string LeNom = tab[0];
                    string LePin = tab[1];
                    // Ajouter client dans tableau des clients
                    Client newClient = new Client(LeNom, LePin);
                    DataGuichet.listeClients.Add(newClient);
                }
                if (fname == "Comptes.txt")
                {
                    //C;J001;10005;7210
                    string LeType = tab[0];
                    string LeClient = tab[1];
                    string LeNumeroDeCompte = tab[2];
                    decimal LaBalance = decimal.Parse(tab[3]);
                    // Ajouter Compte dans tableau des comptes
                    if (LeType == "E")
                    {
                        Epargne newEpargne = new Epargne(LeClient, LeNumeroDeCompte, LaBalance, (decimal)0.01);
                        DataGuichet.listeComptes.Add(newEpargne);
                    }
                    if (LeType == "C")
                    {
                        Cheque newCheque = new Cheque(LeClient, LeNumeroDeCompte, LaBalance, (decimal)1.25);
                        DataGuichet.listeComptes.Add(newCheque);
                    }
                    if (LeType == "B")
                    {
                        DataGuichet.totalGuichet = (int)LaBalance;
                    }
                }
            }
            sr.Close();
        }
    }
}
