using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    /// <summary>
    /// Model class for ProductPicture
    /// </summary>
    public class ProductPicture : DbContext
    {
        public int ID { get; set; }
        public string PictureURL { get; set; }
        public Product Product { get; set; }


        #region Constructors
        /// <summary>
        /// Constructor for getting a ProductPicture out of the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pictureURL"></param>
        public ProductPicture(int id, string pictureURL)
        {
            ID = id;
            PictureURL = pictureURL;
        }
        #endregion

        #region DatabaseMethods
        /// <summary>
        /// Databasemethod that gets all the ProductPictures that is in a certain Product.
        /// Puts all new ProductPictures in the directory and retuns a list of asserts.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<ProductPicture> FindAllProductPicturesForProduct(int id)
        {
            List<ProductPicture> productPictures = new List<ProductPicture>();

            string query = "SELECT * " +
                           "FROM TBL_PRODUCTPICTURE " +
                           "WHERE PRODUCT_ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            var dicId = GetProductPictureIdFromRecord(reader);
                            if (!Dictionaries.ProductPictures.ContainsKey(dicId))
                            {
                                Dictionaries.ProductPictures.Add(dicId,
                                    GetProductPictureDataFromRecord(reader));
                            }
                            productPictures.Add(Dictionaries.ProductPictures[dicId]);
                        }
                    }
                }
            }
            return productPictures;
        }

        /// <summary>
        /// Databasemethod that returns a ProductPicture instance from the database.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static ProductPicture GetProductPictureDataFromRecord(IDataRecord record)
        {
            return new ProductPicture(
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["PICTURELINK"]));
        }

        /// <summary>
        /// Databasemethod that returns the ProductPicture_id from a Datarecord.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static int GetProductPictureIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}