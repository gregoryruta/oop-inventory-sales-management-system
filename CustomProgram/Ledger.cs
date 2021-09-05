using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class Ledger
    {
        private List<Transaction> _transactions;

        public Ledger()
        {
            _transactions = new List<Transaction>();
        }

        public void Put(Transaction transaction)
        {
            _transactions.Add(transaction);

            //only create transaction id if its not loaded from file
            if (transaction.Id == null)
                transaction.Id = IdCreator();
        }

        public string IdCreator()
        {
            return _transactions.Count.ToString("D6");
        }

        public List<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
        }
    }
}
