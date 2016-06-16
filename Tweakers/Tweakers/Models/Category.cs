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
        /// <summary>
        /// Constructor for getting a parentcategory out of the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Category(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// Constructor for getting a subcategory out of the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="category"></param>
        public Category(int id, string name, Category category)
        {
            ID = id;
            Name = name;
            ParentCategory = category;
        }
        #endregion

        #region DatabaseMethods
        /// <summary>
        /// Databasemethod that gets all subcategories.
        /// Puts all new Categories in the directory and returns a list of categories.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>categories</returns>
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

        /// <summary>
        /// Databasemethod that gets all parentcategories.
        /// Puts all new Categories in the directory and returns a list of categories.
        /// </summary>
        /// <returns>categories</returns>
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

        /// <summary>
        /// Databasemethod to find a category by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category</returns>
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

        /// <summary>
        /// Databasemethod that returns an Category instance from a datarecord.
        /// </summary>
        /// <param name="record"></param>
        /// <returns>new Category</returns>
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

        /// <summary>
        /// Databasemethod that returns the Category_id from a datarecord.
        /// </summary>
        /// <param name="record"></param>
        /// <returns>id</returns>
        private static int GetCategoryIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}