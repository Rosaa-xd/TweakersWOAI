using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public abstract class DbContext
    {
        public static string ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                                "(HOST = fhictora01.fhict.local)(PORT = 1521)))(CONNECT_DATA=(SERVER=DEDICATED)" +
                                                "(SERVICE_NAME=fhictora)));User ID = dbi334051; PASSWORD=a112358aB";

        public static OracleConnection CreateConnection()
        {
            OracleConnection connection = new OracleConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}