using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    /// <summary>
    /// Model class for ProductReview
    /// </summary>
    public class ProductReview : Review
    {
        [Range(1, 5, ErrorMessage = "Score mag niet lager zijn dan 1 of hoger dan 5")]
        public int Score { get; set; }
        [DataType(DataType.MultilineText)]
        public string Explanation { get; set; }
        public List<Asset> Assets;

        #region Constructors
        /// <summary>
        /// Constructor for getting a ProductReview out of the database without assets
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="product"></param>
        /// <param name="date"></param>
        /// <param name="score"></param>
        /// <param name="explanation"></param>
        public ProductReview(int id, User user, DateTime date, int score, string explanation)
            : base(id, user, date)
        {
            Score = score;
            Explanation = explanation;
        }

        /// <summary>
        /// Constructor for getting a ProductReview out of a database with assets
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="date"></param>
        /// <param name="score"></param>
        /// <param name="explanation"></param>
        /// <param name="assets"></param>
        public ProductReview(int id, User user, DateTime date, int score, string explanation, List<Asset> assets)
            : base(id, user, date)
        {
            Score = score;
            Explanation = explanation;
            Assets = assets;
        }

        /// <summary>
        /// Constructor for inserting a ProductReview in a database without assets
        /// </summary>
        /// <param name="user"></param>
        /// <param name="product"></param>
        /// <param name="date"></param>
        /// <param name="score"></param>
        /// <param name="explanation"></param>
        public ProductReview(User user, Product product, DateTime date, int score, string explanation)
            : base(user, product, date)
        {
            Score = score;
            Explanation = explanation;
        }

		/// <summary>
        /// Constructor for inserting a ProductReview in a database with assets
        /// </summary>
        /// <param name="user"></param>
        /// <param name="product"></param>
        /// <param name="date"></param>
        /// <param name="score"></param>
        /// <param name="explanation"></param>
        /// <param name="assets"></param>
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
        /// <summary>
        /// Databasemethod to get all ProductReviews that belongs to a certain Product.
        /// Puts all new assets in the direcotry and returns a list of ProductReviews
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Databasemethod that inserts a ProductReview in the database
        /// </summary>
        /// <param name="pr"></param>
        public static void SaveProductReview(ProductReview pr)
        {
            string query =
                "INSERT INTO TBL_PRODUCTREVIEW (USER_ID, PRODUCT_ID, DATE, SCORE, EXPLANATION) " +
                "VALUES(:user_id, :product_id, :date, :score, :explanation)";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;

                string date = pr.Date.ToString("DD-MM-YYYY HH24:MI:SS");

                command.Parameters.Add(new OracleParameter("user_id", pr.User.ID));
                command.Parameters.Add(new OracleParameter("product_id", pr.Product.ID));
                command.Parameters.Add(new OracleParameter("date", DateTime.Now));
                command.Parameters.Add(new OracleParameter("score", pr.Score));
                command.Parameters.Add(new OracleParameter("explanation", pr.Explanation));

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Databasemethod to get a ProductReview instance from the database
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Databasemethod that returns the ProductReview_id from a Datarecord
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static int GetProductReviewIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}