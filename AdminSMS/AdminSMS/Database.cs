using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace AdminSMS
{
    class Database
    {
        private OdbcConnection OC = null;
        public OdbcDataReader reader = null;
        private OdbcCommand dbCommand = null;

        public Database() {}
        
        public Database(string connectionString){
            OC = new OdbcConnection(connectionString);
            dbCommand = new OdbcCommand();
            dbCommand.Connection = OC;
            OC.Open();
        }

        public void executeReader(string q){
            dbCommand.CommandText = q;
            reader = dbCommand.ExecuteReader();
        }

        public void execute(string q){
            dbCommand.CommandText = q;
            dbCommand.ExecuteNonQuery();
        }

        public int executeScalar(string q)
        {
            dbCommand.CommandText = q;
            return Convert.ToInt32(dbCommand.ExecuteScalar());
        }

        public void dispose()
        {
            reader.Close();
            reader.Dispose();
            dbCommand.Dispose();
            OC.Close();
            OC.Dispose();
        }
    }
}
