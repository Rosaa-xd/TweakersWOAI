using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    /// <summary>
    /// Model class for ProductType
    /// </summary>
    public class ProductType : DbContext
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Product> Products;

        #region Constructor
        /// <summary>
        /// Constructor for getting a ProductType out of the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public ProductType(int id, string name)
        {
            ID = id;
            Name = name;
        }
        #endregion

        #region DatabaseMethods
        /// <summary>
        /// Databasemethod for finding a ProductType by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ProductType FindById(int id)
        {
            string query = "SELECT * " +
                           "FROM TBL_PRODUCTTYPE " +
                           "WHERE ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            return GetProductTypeFromDataRecord(reader);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Databasemethod that returns a ProductType instance from the database
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static ProductType GetProductTypeFromDataRecord(IDataRecord record)
        {
            return new ProductType(
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["NAME"]));
        }

        #endregion
    }
}