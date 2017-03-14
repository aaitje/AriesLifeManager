using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
//using Dapper_Database_Classes;


namespace AriesLifeManager
{
    class Relations
    {
        public List<Relation> getRelations()
        {
            using (SqlConnection DB = new SqlConnection("Data Source=DIRACT-LT111;Initial Catalog=LifeManagerDB;Integrated Security=True"))
            {
                DB.Open();
                return DB.Query<Relation>("select * from Relation").ToList();

            }
        }
    }

    class Relation
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime birthday { get; set; }
    }
}
