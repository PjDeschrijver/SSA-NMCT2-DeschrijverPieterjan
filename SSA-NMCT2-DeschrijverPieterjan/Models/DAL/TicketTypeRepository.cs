using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models.DAL
{
    public class TicketTypeRepository
    {
        public static List<TicketType> GetTickets()
        {
            //0.vars          
            List<TicketType> list = new List<TicketType>();
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [TicketType]";
            sSQL += " ORDER BY [TicketType].ID";

            //2.Data ophalen met reader
            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return (list);
        }

        //SQL helpers ------------------------------------------------
        private static TicketType Fill(DbDataReader reader)
        {
            string ID = reader["ID"].ToString();
            TicketType item = new TicketType();
            item.ID = ID;
            item.AvailableTickets = (int)reader["AvailableTickets"];
            item.Name = reader["Name"].ToString();
            
            //item.Youtube = (string)reader["Youtube"];

            return item;

        }
        public static List<TicketType> GetCoursesByLevel(int TicketID)
        {
            //0.vars          
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [TicketType]";
            sSQL += " WHERE [TicketType].[ID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", TicketID);

            List<TicketType> lijst = GetList(sSQL, idPar);

            DbDataReader reader = Database.GetData(sSQL, idPar);
            while (reader.Read())
            {
                lijst.Add(Fill(reader));
            }
            return lijst;
        }

        public static int CountCourses(string TicketID)
        {
            string sSQL = "SELECT * FROM [TicketType]";
            sSQL += " WHERE [TicketType].[ID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", TicketID);

            List<TicketType> lijst = GetList(sSQL, idPar);

            DbDataReader reader = Database.GetData(sSQL, idPar);

            int i = 0;
            while (reader.Read())
            {
                i++;
            }
            return i;
        }

        public static TicketType FindById(string TicketID)
        {
            //0.vars          
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [TicketType]";
            sSQL += " WHERE [TicketType].[ID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", TicketID);

            List<TicketType> lijst = GetList(sSQL, idPar);
            if (lijst != null && lijst.Count > 0)
            {
                return lijst[0];
            }
            return null;
        }
        private static List<TicketType> GetList(string sSQL, params DbParameter[] dbParams)
        {
            List<TicketType> list = new List<TicketType>();

            DbDataReader reader = Database.GetData(sSQL, dbParams);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return list;
        }
        public static TicketType getTicketTypeByName(string Name)
        {
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [TicketType]";
            sSQL += " WHERE [Name] = @Name";
            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@Name", Name);
            //3. Haal data op en controleer op null/lege velden
            DbDataReader reader = Database.GetData(sSQL, idPar);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    TicketType t = Fill(reader);
                    return t;
                }
            }
            return null;

        }
    }
}