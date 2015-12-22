using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA
{
    public class Compte
    {
        private readonly string _numeroDeClient;
        private readonly string _numeroDeCompte;
        protected decimal _balance;

        
        public string NumeroDeClient
        {
            get { return _numeroDeClient; }
        }

        public string NumeroDeCompte
        {
            get { return _numeroDeCompte; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public Compte(string numeroDeClient, string numeroDeCompte, decimal balance)
        {
            _numeroDeClient = numeroDeClient;
            _numeroDeCompte = numeroDeCompte;
            _balance = balance;
            // Transaction
        }

        public virtual void Retrait(decimal montant)
        {
            _balance -= montant;
            // Code pour la transaction
        }

        public virtual void Depot(decimal montant)
        {
            _balance += montant;
            // code pour la transaction
        }

        public override string ToString()
        {
            return string.Format("Numéro de compte: {0} Balance: {1}", _numeroDeCompte, _balance);
        }



    }
}
