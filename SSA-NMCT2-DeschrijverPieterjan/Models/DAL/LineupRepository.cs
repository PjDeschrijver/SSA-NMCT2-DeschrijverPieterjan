using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models.DAL
{
    public class LineupRepository
    {
        public static List<Lineup> GetLineup()
        {
            //0.vars          
            List<Lineup> list = new List<Lineup>();
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [LineUp]";
            sSQL += " ORDER BY [LineUp].ID";

            //2.Data ophalen met reader
            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return (list);
        }

        public static Lineup getLineUpByBand(int BandID)
        {

            string sql = "SELECT * FROM [LineUp]";
            sql += " WHERE [BandId] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", BandID);

            //3. Haal data op en controleer op null/lege velden
            DbDataReader reader = Database.GetData(sql, idPar);

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Lineup l = Fill(reader);
                    return l;
                }
            }
            return null;
        }

        public static Lineup Fill(DbDataReader reader)
        {

            Lineup l = new Lineup();
            l.Band = BandRepository.FindById(reader["BandId"].ToString());
            DateTime date = Convert.ToDateTime(reader["Date"].ToString());
            l.Date = date.ToString("dd-MM-yyyy");
            l.From = reader["From"].ToString();
            l.Until = reader["Until"].ToString();
            l.Stage = StageRepository.GetStageByID(int.Parse(reader["StageId"].ToString()));
            l.ID = int.Parse(reader["ID"].ToString());
            return l;

        }

        public static List<Lineup> GetAllDays()
        {
            List<Lineup> lineups = new List<Lineup>();
            string sSQL = "SELECT DISTINCT Date FROM LineUp";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                Lineup l = new Lineup();

                DateTime date = Convert.ToDateTime(reader["Date"].ToString());
                l.Date = date.ToString("dd-MM-yyyy");

                lineups.Add(l);
            }
            reader.Close();

            return lineups;
        }

        public static List<Lineup> GetLineupByDate(string Date)
        {

            string sql = "SELECT * FROM [LineUp]";
            sql += " WHERE [Date] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", Date);

            //3. Haal data op en controleer op null/lege velden
            DbDataReader reader = Database.GetData(sql, idPar);

            List<Lineup> list = new List<Lineup>();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Lineup l = Fill(reader);
                    list.Add(l);
                }
            }
            return list;
        }

    }
}