using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA
{
    class Epargne : Compte
    {
        public decimal _Interet;

        public decimal Interet
        {
            get { return _Interet; }
        }

        public Epargne(string numeroDeClient, string numeroDeCompte, decimal balance, decimal interet) : base(numeroDeClient, numeroDeCompte, balance)
        {
            _Interet = interet;
        }
    }
}
