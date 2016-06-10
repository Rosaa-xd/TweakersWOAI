using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Tweakers.Models
{
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
        public User(int id, string name, string password)
        {
            ID = id;
            Name = name;
            Password = password;
        }
        #endregion

        #region DatabaseMethods
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
            string query = "SELECT ID " +
                           "FROM TBL_USER " +
                           "WHERE USERNAME=:name";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("name", name));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Dictionaries.Users[GetUserIdFromRecord(reader)];
                    }
                }
            }
            return null;
        }

        private static User GetUserFromDataRecord(IDataRecord record)
        {
            return new User
            (
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["USERNAME"]),
                Convert.ToString(record["PASSWORD"])
            );
        }

        private static int GetUserIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}