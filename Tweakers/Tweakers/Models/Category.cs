using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public class Category : DbContext
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Category ParentCategory { get; set; }
        public List<Product> Products;

        #region Constructors

        public Category(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public Category(int id, string name, Category category)
        {
            ID = id;
            Name = name;
            ParentCategory = category;
        }

        public Category(string name, List<Product> products)
        {
            Name = name;
            Products = products;
        }

        public Category(int id, string name, Category category, List<Product> products)
        {
            ID = id;
            Name = name;
            ParentCategory = category;
            Products = products;
        }

        #endregion

        #region DatabaseMethods
        public static List<Category> ReturnAllSubCategories (int id)
        {
            List<Category> categories = new List<Category>();

            string query = "SELECT * " +
                           "FROM TBL_CATEGORY " +
                           "WHERE CATEGORY_ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dicId = GetCategoryIdFromRecord(reader);
                        if (!Dictionaries.Categories.ContainsKey(dicId))
                        {
                            Dictionaries.Categories.Add(dicId, GetCategoryFromDataRecord(reader));
                        }
                        categories.Add(Dictionaries.Categories[dicId]);
                    }
                }
            }
            return categories;
        }

        public static List<Category> ReturnAllParentCategories()
        {
            List<Category> parentCategories = new List<Category>();

            string query = "SELECT * " +
                           "FROM TBL_CATEGORY " +
                           "WHERE CATEGORY_ID IS NULL";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var dicId = GetCategoryIdFromRecord(reader);
                    if (!Dictionaries.Categories.ContainsKey(dicId))
                    {
                        Dictionaries.Categories.Add(dicId, GetCategoryFromDataRecord(reader));
                    }
                    parentCategories.Add(Dictionaries.Categories[dicId]);
                }
            }
            return parentCategories;
        }

        public static Category FindById(int id)
        {
            string query = "SELECT * FROM TBL_CATEGORY WHERE ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var dicId = GetCategoryIdFromRecord(reader);
                        if (!Dictionaries.Categories.ContainsKey(dicId))
                        {
                            Dictionaries.Categories.Add(dicId, GetCategoryFromDataRecord(reader));
                        }
                        return Dictionaries.Categories[dicId];
                    }
                }
            }
            return null;
        }

        private static Category GetCategoryFromDataRecord(IDataRecord record)
        {
            if (!Convert.IsDBNull(record["CATEGORY_ID"]))
            {
                return new Category(
                    Convert.ToInt32(record["ID"]),
                    Convert.ToString(record["NAME"]),
                    FindById(Convert.ToInt32(record["CATEGORY_ID"])));
            }
            return new Category(
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["NAME"]));
        }

        private static int GetCategoryIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}