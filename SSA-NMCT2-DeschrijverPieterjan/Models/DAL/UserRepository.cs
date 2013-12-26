using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models.DAL
{
    public class UserRepository
    {
        public static User GetUserById(string ID)
        {
            //0.vars          
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [UserProfile]";
            sSQL += " WHERE [UserProfile].[UserID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", ID);

            

            DbDataReader reader = Database.GetData(sSQL, idPar);
            while (reader.Read())
            {
                User i = Fill(reader);
                return i;
            }
            return null;
        }
        private static User Fill(DbDataReader reader)
        {
            string ID = reader["UserID"].ToString();
            User item = new User();
            item.ID = ID;
            item.Name = (string)reader["UserName"];
            item.Email = reader["Email"].ToString();
           
            return item;

        }
        private static List<User> GetList(string sSQL, params DbParameter[] dbParams)
        {
            List<User> list = new List<User>();

            DbDataReader reader = Database.GetData(sSQL, dbParams);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return list;
        }
    }
}