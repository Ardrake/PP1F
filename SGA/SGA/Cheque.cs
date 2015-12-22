using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA
{
    class Cheque : Compte
    {
        public decimal _Frais;


        public decimal Frais
        {
            get { return _Frais; }
        }

        public Cheque(string numeroDeClient, string numeroDeCompte, decimal balance, decimal frais) : base(numeroDeClient, numeroDeCompte, balance)
        {
            _Frais = frais;
        }
    }
}
