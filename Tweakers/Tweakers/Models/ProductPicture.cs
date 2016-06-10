using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public class ProductPicture : DbContext
    {
        public int ID { get; set; }
        public string PictureURL { get; set; }
        public Product Product { get; set; }


        #region Constructors

        public ProductPicture(int id, string pictureURL)
        {
            ID = id;
            PictureURL = pictureURL;
        }
        #endregion

        #region DatabaseMethods

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

        private static ProductPicture GetProductPictureDataFromRecord(IDataRecord record)
        {
            return new ProductPicture(
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["PICTURELINK"]));
        }

        private static int GetProductPictureIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}