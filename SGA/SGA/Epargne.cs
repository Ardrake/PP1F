using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA
{
    class Epargne : Compte
    {
        private DateTime _dernierRetrait;

        public decimal Frais { get; private set; }

        public Epargne(string numeroDeCompte, decimal balance, decimal frais) : base(numeroDeCompte, balance)
        {
            Frais = frais; 
        }

    }
}
