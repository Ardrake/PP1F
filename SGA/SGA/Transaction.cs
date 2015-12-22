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
        public Compte TransactionCompte { get; private set; }
        public decimal Montant { get; private set; }
        public decimal Balance { get; private set; }

        public Transaction(DateTime date, TypeTransaction transactionType, Compte transactionCompte, decimal montant, decimal balance)
        {
            Date = date;
            Montant = montant;
            Balance = balance;
            TypeTransaction = transactionType;
            TransactionCompte = transactionCompte;

            if (transactionType == TypeTransaction.Retrait || transactionType == TypeTransaction.Facture || transactionType == TypeTransaction.TransfertRetrait)
            {
                Montant = Montant * -1;
            }
        }

        public override string ToString()
        {
            return  string.Format("Date: {0}, Type: {1}, Compte: {2} Montant: {3}, Balance {4}", Date, TypeTransaction, TransactionCompte.NumeroDeCompte, Montant, Balance);
        }

    }



    
}
