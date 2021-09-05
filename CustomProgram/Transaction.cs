using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomProgram
{
    public class Transaction
    {
        private string _id;
        private string _date;
        private string _details;
        
        public Transaction(string date, string details)
        {
            _date = date;
            _details = details;
        }

        //need this constructor to load from file
        public Transaction()
        {

        }

        public void Save(StreamWriter writer)
        {
            writer.WriteLine(_id);
            writer.WriteLine(_date);
            writer.WriteLine(_details);
        }

        public void Load(StreamReader reader)
        {
            _id = reader.ReadLine();
            _date = reader.ReadLine();
            _details = reader.ReadLine();
        }

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Date
        {
            get
            {
                return _date;
            }
        }

        public string Details
        {
            get
            {
                return _details;
            }
        }
    }
}
