using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CodeChallenge.Entities;

namespace CodeChallenge.DAL.Chat
{
    public sealed class ChatDAL
    {
        private static readonly ChatDAL instance = new ChatDAL();
        static ChatDAL() { } // Make sure it's truly lazy
        private ChatDAL() { } // Prevent instantiation outside
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static ChatDAL Instance { get { return instance; } }

        public void InsertMessage(string username, string text)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_add_message", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@Text", SqlDbType.VarChar).Value = text;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Message> GetMessages(int amount)
        {
            List<Message> list = new List<Message>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_get_messages", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = amount;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        Message m = new Message()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Username = reader["UserName"].ToString(),
                            Text = reader["Text"].ToString(),
                            TimeStamp = DateTime.Parse(reader["Ts"].ToString())

                        };
                        list.Add(m);
                    }
                }
            }

            return list;
        }

    }
}