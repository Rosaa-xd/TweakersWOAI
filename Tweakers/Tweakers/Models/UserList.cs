using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public enum UserListType { Inventory, WishList }
    
    /// <summary>
    /// Model class for UserList
    /// </summary>
    public class UserList : DbContext
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public UserListType Type { get; set; }
        public User User { get; set; }
        public List<Product> Products;

        #region Constructors
        /// <summary>
        /// Constructor for inserting a UserList into the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="user"></param>
        public UserList(string name, UserListType type, User user)
        {
            Name = name;
            Type = type;
            User = user;
        }
        /// <summary>
        /// Constructor for getting a UserList out of the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="user"></param>
        public UserList(int id, string name, UserListType type, User user, List<Product> products)
        {
            ID = id;
            Name = name;
            Type = type;
            User = user;
            Products = products;
        }

        /// <summary>
        /// Constructor for inserting or updating a UserList with Products into the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="user"></param>
        /// <param name="products"></param>
        public UserList(string name, UserListType type, User user, List<Product> products)
        {
            Name = name;
            Type = type;
            User = user;
            Products = products;
        }
        #endregion

        #region DatabaseMethods
        /// <summary>
        /// Databasemethod that gets all the UserLists that have a certain Product
        /// Puts all new UserLists in the direcotry and returns a list of UserLists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<UserList> AllUserListsWithProduct(int id)
        {
            List<UserList> userLists = new List<UserList>();

            string query = "SELECT L.* " +
                           "FROM TBL_LIST L " +
                           "INNER JOIN TBL_PRODUCT_LIST PL ON L.ID = PL.LIST_ID " +
                           "INNER JOIN TBL_PRODUCT P ON P.ID = PL.PRODUCT_ID " +
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
                        var dicId = GetUserListIdFromRecord(reader);
                        if (!Dictionaries.UserLists.ContainsKey(dicId))
                        {
                            Dictionaries.UserLists.Add(dicId, GetUserListDataFromRecord(reader));
                        }
                        userLists.Add(Dictionaries.UserLists[dicId]);
                    }
                }
            }
            return userLists;
        }

        /// <summary>
        /// Databasemethod that returns a UserList instrance from the database.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static UserList GetUserListDataFromRecord(IDataRecord record)
        {
            UserListType type;

            switch (Convert.ToString(record["LIST_TYPE"]))
            {
                case "I":
                    type = UserListType.Inventory;
                    break;
                default:
                    type = UserListType.WishList;
                    break;
            }

            return new UserList(
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["NAME"]),
                type,
                User.FindById(Convert.ToInt32(record["USER_ID"])),
                Product.FindAllProductsInUserList(Convert.ToInt32(record["ID"])));
        }

        /// <summary>
        /// Databasemethod that returns a UserList_id from a Datarecord
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static int GetUserListIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}