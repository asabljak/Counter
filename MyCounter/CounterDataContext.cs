using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace MyCounter
{
    public class CounterDataContext : DataContext
    {
        public static string DBConnectionString="Data Source=isostore:/Counter.sdf";

        public CounterDataContext(string connectionString):base(connectionString)
        {}

       // public Table<CountItem> items;
    }
}
