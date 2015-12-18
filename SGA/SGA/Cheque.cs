using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA
{
    class Cheque : Compte
    {
        private DateTime _dernierRetrait;

        public decimal Frais { get; private set; }

        public Cheque(string numeroDeCompte, decimal balance, decimal frais) : base(numeroDeCompte, balance)
        {
            Frais = frais;
        }
    }
}
