using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models.DAL
{
    public class TicketRepository
    {
         
       public static List<Ticket> GetTickets()
        {
            //0.vars          
            List<Ticket> list = new List<Ticket>();
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [Ticket]";
            sSQL += " ORDER BY [Ticket].ID";

            //2.Data ophalen met reader
            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return (list);
        }

        //SQL helpers ------------------------------------------------
        private static Ticket Fill(DbDataReader reader)
        {
            string ID = reader["ID"].ToString();
            Ticket item = new Ticket();
            item.ID = ID;
            item.TicketHolder = (string)reader["TicketHolder"];
            item.TicketHolderEmail = reader["TicketHolderEmail"].ToString();
            item.TicketType = TicketTypeRepository.FindById(reader["TicketType"].ToString());
            item.Amount = (int)reader["Amount"];
            //item.Youtube = (string)reader["Youtube"];
            
            return item;

        }
        public static List<Ticket> GetCoursesByLevel(int TicketID)
        {
            //0.vars          
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [Ticket]";
            sSQL += " WHERE [Ticket].[ID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", TicketID);

            List<Ticket> lijst = GetList(sSQL, idPar);

            DbDataReader reader = Database.GetData(sSQL, idPar);
            while (reader.Read())
            {
                lijst.Add(Fill(reader));
            }
            return lijst;
        }

        public static int CountCourses(string TicketID)
        {
            string sSQL = "SELECT * FROM [Ticket]";
            sSQL += " WHERE [Ticket].[ID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", TicketID);

            List<Ticket> lijst = GetList(sSQL, idPar);

            DbDataReader reader = Database.GetData(sSQL, idPar);

            int i = 0;
            while (reader.Read())
            {
                i++;
            }
            return i;
        }

        public static Ticket FindById(string TicketID)
        {
            //0.vars          
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [Ticket]";
            sSQL += " WHERE [Ticket].[ID] = @ID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@ID", TicketID);

            List<Ticket> lijst = GetList(sSQL, idPar);
            if (lijst != null && lijst.Count > 0)
            {
                return lijst[0];
            }
            return null;
        }
        private static List<Ticket> GetList(string sSQL, params DbParameter[] dbParams)
        {
            List<Ticket> list = new List<Ticket>();

            DbDataReader reader = Database.GetData(sSQL, dbParams);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return list;
        }

        public static void SetTicket(Ticket t)
        {
            string ticketType = t.TicketType.ToString();
            TicketType tt = TicketTypeRepository.getTicketTypeByName(ticketType);
            String sSQL = "INSERT INTO Ticket(Ticketholder, TicketholderEmail, Tickettype, Amount) VALUES(@Ticketholder, @TicketholderEmail, @Tickettype, @Amount)";

            DbParameter par1 = Database.AddParameter("@Ticketholder", t.TicketHolder);
            if (par1.Value == null) par1.Value = DBNull.Value;

            DbParameter par2 = Database.AddParameter("@TicketholderEmail", t.TicketHolderEmail);
            if (par2.Value == null) par2.Value = DBNull.Value;

            DbParameter par3 = Database.AddParameter("@Tickettype", tt.ID);
            if (par3.Value == null) par3.Value = DBNull.Value;

            DbParameter par4 = Database.AddParameter("@Amount", t.Amount);
            if (par4.Value == null) par4.Value = DBNull.Value;

            DbParameter[] pars = new DbParameter[] { par1, par2, par3, par4 };
            Database.ModifyData(sSQL, pars);
        }
    }
    }
