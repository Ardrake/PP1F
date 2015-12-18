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
                }
                if (fname == "Comptes.txt")
                {
                    //C;J001;10005;7210
                    string LeType = tab[0];
                    string LeClient = tab[1];
                    string LeNumeroDeCompte = tab[2];
                    string LaBalance = tab[3];
                    // Ajouter Compte dans tableau des comptes
                }


            }
        }

    }
}
