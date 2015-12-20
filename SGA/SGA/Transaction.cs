using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA
{
    public class Transaction
    {
        public DateTime Date { get; private set; }
        public TypeTransaction TypeTransaction { get; private set; }
        public decimal Montant { get; private set; }
        public decimal Balance { get; private set; }

        public Transaction(DateTime date, TypeTransaction transactionType, decimal montant, decimal balance)
        {
            Date = date;
            Montant = montant;
            Balance = balance;
            TypeTransaction = transactionType;

            if (transactionType == TypeTransaction.Retrait)
            {
                Montant = Montant * -1;
            }
        }

        public override string ToString()
        {
            return  string.Format("Date: {0}, Type: {1}, Montant: {2}, Balance {3}", Date, TypeTransaction, Montant, Balance);
        }

    }



    
}
