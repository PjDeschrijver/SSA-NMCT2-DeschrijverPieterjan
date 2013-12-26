using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models.DAL
{
    public class BandRepository
    {
        public static List<Band> GetBands()
        {
            //0.vars          
            List<Band> list = new List<Band>();
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [Band]";
            sSQL += " ORDER BY [Band].ID";

            //2.Data ophalen met reader
            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return (list);
        }

        //SQL helpers ------------------------------------------------
        private static Band Fill(DbDataReader reader)
        {
            string ID = reader["ID"].ToString();
            Band item = new Band();
            item.ID = ID;
            item.Name = reader["Name"].ToString();
            item.Description = reader["Description"].ToString();
            item.Facebook = reader["Facebook"].ToString();
            item.Twitter = reader["Twitter"].ToString();
            item.Youtube = reader["Youtube"].ToString();
            item.Picture = reader["Picture"].ToString();
            return item;

        }
        public static List<Band> GetBandsByID(string BandID)
        {
            //0.vars          
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [Band]";
            sSQL += " WHERE [Band].[ID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", BandID);

            List<Band> lijst = GetList(sSQL, idPar);

            DbDataReader reader = Database.GetData(sSQL, idPar);
            while (reader.Read())
            {
                lijst.Add(Fill(reader));
            }
            return lijst;
        }

        public static int CountCourses(string BandID)
        {
            string sSQL = "SELECT * FROM [Band]";
            sSQL += " WHERE [Band].[ID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", BandID);

            List<Band> lijst = GetList(sSQL, idPar);

            DbDataReader reader = Database.GetData(sSQL, idPar);

            int i = 0;
            while (reader.Read())
            {
                i++;
            }
            return i;
        }

        public static Band FindById(string BandID)
        {
            //0.vars          
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [Band]";
            sSQL += " WHERE [Band].[ID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", BandID);

            List<Band> lijst = GetList(sSQL, idPar);
            if (lijst != null && lijst.Count > 0)
            {
                return lijst[0];
            }
            return null;
        }
        private static List<Band> GetList(string sSQL, params DbParameter[] dbParams)
        {
            List<Band> list = new List<Band>();

            DbDataReader reader = Database.GetData(sSQL, dbParams);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return list;
        }
    }
}