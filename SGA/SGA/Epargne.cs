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
        public decimal Interet { get; private set; }

        public Epargne(string numeroDeClient, string numeroDeCompte, decimal balance, decimal interet, decimal frais) : base(numeroDeClient, numeroDeCompte, balance)
        {
            Frais = frais;
            Interet = interet;
        }
    }
}
