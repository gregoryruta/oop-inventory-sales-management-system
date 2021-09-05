using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class LedgerView : IView
    {
        private Ledger _ledger;

        public LedgerView(Ledger ledger)
        {
            _ledger = ledger;
        }
        public List<string> Execute()
        {
            List<string> output = new List<string>();
            output.Add("All transactions");
            output.Add(null);

            //get details for each transaction in the ledger
            foreach (Transaction transcation in _ledger.Transactions)
                output.Add($"{transcation.Id} | {transcation.Date} | {transcation.Details}");
            return output;
        }
    }
}
