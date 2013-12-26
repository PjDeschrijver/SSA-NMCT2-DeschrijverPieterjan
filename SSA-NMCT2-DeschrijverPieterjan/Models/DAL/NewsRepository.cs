using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models.DAL
{
    public class NewsRepository
    {
        public static List<News> getNews()
        {

            string sql = "SELECT * FROM [News]";

            DbDataReader reader = Database.GetData(sql, null);
            List<News> news = new List<News>();
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    news.Add(Fill(reader));
                }
            }
            return news;

        }

        private static News Fill(DbDataReader reader)
        {
            News n = new News();
            n.Content = reader["Content"].ToString();
            n.ID = int.Parse(reader["ID"].ToString());
            n.Title = reader["Title"].ToString();
            n.Author = reader["Author"].ToString();
            n.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());
            return n;
        }
    }
}