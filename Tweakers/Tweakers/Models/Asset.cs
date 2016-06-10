using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public enum AssetType { Positive, Negative }

    public class Asset : DbContext
    {
        public int ID { get; set; }
        public AssetType Type { get; set; }
        public string Explanation { get; set; }
        public List<ProductReview> ProductReviews;

        #region Constructors
        public Asset(int id, AssetType type, string explanation)
        {
            ID = id;
            Type = type;
            Explanation = explanation;
        }
        #endregion

        #region DatabaseMethods

        public static List<Asset> AllProductReviewAssets(int id)
        {
            List<Asset> assets = new List<Asset>();

            string query = "SELECT * " +
                           "FROM TBL_ASSET A " +
                           "INNER JOIN TBL_REVIEW_ASSET RA ON A.ID = RA.ASSET_ID " +
                           "INNER JOIN TBL_PRODUCT_REVIEW PR ON PR.REVIEW_ID = RA.PRODUCTREVIEW_ID " +
                           "WHERE PR.REVIEW_ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dicId = GetAssetIdFromRecord(reader);
                        if (!Dictionaries.Assets.ContainsKey(dicId))
                        {
                            Dictionaries.Assets.Add(dicId, GetAssetDataFromRecord(reader));
                        }
                        assets.Add(Dictionaries.Assets[dicId]);
                    }
                }
            }
            return assets;
        }

        private static Asset GetAssetDataFromRecord(IDataRecord record)
        {
            AssetType type;

            switch (Convert.ToString(record["ASSET_TYPE"]))
            {
                case "P":
                    type = AssetType.Positive;
                    break;
                default:
                    type = AssetType.Negative;
                    break;
            }

            return new Asset(
                Convert.ToInt32(record["ID"]),
                type,
                Convert.ToString(record["EXPLANATION"]));
        }

        private static int GetAssetIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}