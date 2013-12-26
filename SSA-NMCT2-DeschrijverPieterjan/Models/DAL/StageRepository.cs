using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models.DAL
{
    public class StageRepository
    {
        public static Stage GetStageByID(int BandID)
        {
            string sql = "SELECT * FROM [Stage]";
            sql += " WHERE [ID] = @ID";

            DbParameter idpar = Database.AddParameter("@ID", BandID);

            DbDataReader reader = Database.GetData(sql, idpar);
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    Stage s = Fill(reader);
                    return s;
                }
            }
            return null;
        }

        public static Stage Fill(DbDataReader reader)
        {
            Stage s = new Stage();
            s.Name = reader["Name"].ToString();
            s.ID = int.Parse(reader["ID"].ToString());
            return s;
        }
    }
}