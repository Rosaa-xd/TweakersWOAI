using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Tweakers.Models
{
    /// <summary>
    /// Model class for User
    /// </summary>
    public class User : DbContext
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public List<UserList> UserLists;
        public List<Review> Reviews;

        #region Constructors
        /// <summary>
        /// Constructor for getting a User out of the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public User(int id, string name, string password)
        {
            ID = id;
            Name = name;
            Password = password;
        }

        /// <summary>
        /// Constructor for inserting a User into the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="userLists"></param>
        /// <param name="reviews"></param>
        public User(string name, string password, List<UserList> userLists, List<Review> reviews)
        {
            Name = name;
            Password = password;
            UserLists = userLists;
            Reviews = reviews;
        }
        #endregion

        #region DatabaseMethods
        /// <summary>
        /// Databasemethod for logging in a User
        /// Puts a new User in the dictionary and returns the user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User FindByLogin(string name, string password)
        {
            string query = "SELECT * " +
                           "FROM TBL_USER " +
                           "WHERE USERNAME=:name " +
                           "AND PASSWORD=:password";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("name", name));
                command.Parameters.Add(new OracleParameter("password", password));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var dicId = GetUserIdFromRecord(reader);
                        if (!Dictionaries.Users.ContainsKey(dicId))
                        {
                            Dictionaries.Users.Add(dicId, GetUserFromDataRecord(reader));
                        }
                        return Dictionaries.Users[dicId];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Databasemethod for finding a User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User FindById(int id)
        {
            string query = "SELECT * " +
                           "FROM TBL_USER " +
                           "WHERE ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add("id", id);

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var dicId = GetUserIdFromRecord(reader);
                        if (!Dictionaries.Users.ContainsKey(dicId))
                        {
                            Dictionaries.Users.Add(dicId, GetUserFromDataRecord(reader));
                        }
                        return Dictionaries.Users[dicId];
                    }
                }
            }
            return null;
        }

        public static User FindByName(string name)
        {
            string query = "SELECT * " +
                           "FROM TBL_USER " +
                           "WHERE UPPER(USERNAME) = UPPER(:name)";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("name", name));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var dicId = GetUserIdFromRecord(reader);
                        if (!Dictionaries.Users.ContainsKey(dicId))
                        {
                            Dictionaries.Users.Add(dicId,
                                GetUserFromDataRecord(reader));
                        }
                        return Dictionaries.Users[GetUserIdFromRecord(reader)];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Databasemethod that returns a User instance from the database
        /// Puts new Users in the dictionary and returns a user.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static User GetUserFromDataRecord(IDataRecord record)
        {
            return new User
            (
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["USERNAME"]),
                Convert.ToString(record["PASSWORD"])
            );
        }

        /// <summary>
        /// Database method that returns the User_id
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static int GetUserIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}