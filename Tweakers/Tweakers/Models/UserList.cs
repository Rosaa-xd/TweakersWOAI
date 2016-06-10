using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public enum Type { Inventory, WishList }
    
    public class UserList : DbContext
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public User User { get; set; }
        public List<Product> Products;

        #region Constructors
        public UserList(int id, string name, Type type, User user)
        {
            ID = id;
            Name = name;
            Type = type;
            User = user;
        }
        #endregion

        #region DatabaseMethods

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

        private static UserList GetUserListDataFromRecord(IDataRecord record)
        {
            Type type;

            switch (Convert.ToString(record["LIST_TYPE"]))
            {
                case "I":
                    type = Type.Inventory;
                    break;
                default:
                    type = Type.WishList;
                    break;
            }

            return new UserList(
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["NAME"]),
                type,
                User.FindById(Convert.ToInt32(record["USER_ID"])));
        }

        private static int GetUserListIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}