using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public class ProductReview : Review
    {
        public int Score { get; set; }
        public string Explanation { get; set; }
        public List<Asset> Assets;

        #region Constructors
        public ProductReview(int id, User user, Product product, DateTime date, int score, string explanation)
            : base(id, user, product, date)
        {
            Score = score;
            Explanation = explanation;
        }

        public ProductReview(int id, User user, Product product, DateTime date, int score, string explanation,
            List<Asset> assets)
            : base (id, user, product, date)
        {
            Score = score;
            Explanation = explanation;
            Assets = assets;
        }

        public ProductReview(int id, User user, DateTime date, int score, string explanation, List<Asset> assets)
            : base(id, user, date)
        {
            Score = score;
            Explanation = explanation;
            Assets = assets;
        }

        public ProductReview(User user, Product product, DateTime date, int score, string explanation)
            : base(user, product, date)
        {
            Score = score;
            Explanation = explanation;
        }

        public ProductReview(User user, Product product, DateTime date, int score, string explanation,
            List<Asset> assets)
            : base(user, product, date)
        {
            Score = score;
            Explanation = explanation;
            Assets = assets;
        }
        #endregion

        #region DatabaseMethods
        public static List<ProductReview> AllProductReviews(int id)
        {
            List<ProductReview> productReviews = new List<ProductReview>();

            string query = "SELECT R.*, PR.SCORE, PR.EXPLANATION " +
                           "FROM TBL_PRODUCT_REVIEW PR " +
                           "INNER JOIN TBL_REVIEW R ON PR.REVIEW_ID = R.ID " +
                           "INNER JOIN TBL_PRODUCT P ON R.PRODUCT_ID = P.ID " +
                           "WHERE P.ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dicId = GetProductReviewIdFromRecord(reader);
                        if (!Dictionaries.ProductReviews.ContainsKey(dicId))
                        {
                            Dictionaries.ProductReviews.Add(dicId,
                                GetProductReviewDataFromRecord(reader));
                        }
                        productReviews.Add(Dictionaries.ProductReviews[dicId]);
                    }
                }
            }
            return productReviews;
        }

        private static ProductReview GetProductReviewDataFromRecord(IDataRecord record)
        {
            return new ProductReview(
                Convert.ToInt32(record["ID"]),
                User.FindById(Convert.ToInt32(record["USER_ID"])),
                Convert.ToDateTime(record["REVIEW_DATE"]),
                Convert.ToInt32(record["SCORE"]),
                Convert.ToString(record["EXPLANATION"]),
                Asset.AllProductReviewAssets(Convert.ToInt32(record["ID"])));
        }

        private static int GetProductReviewIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}