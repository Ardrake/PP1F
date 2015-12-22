﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGA
{
    public class Program
    {

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
                        Epargne newEpargne = new Epargne(LeClient, LeNumeroDeCompte, LaBalance, (decimal)0.01, (decimal)1.25);
                        DataGuichet.listeComptes.Add(newEpargne);
                    }
                    if (LeType == "C")
                    {
                        Cheque newCheque = new Cheque(LeClient, LeNumeroDeCompte, LaBalance, 0, (decimal)1.25);
                        DataGuichet.listeComptes.Add(newCheque);
                    }
                    if (LeType == "B")
                    {
                        DataGuichet.totalGuichet = (int)LaBalance;
                    }
                }


            }
        }

    }
}
