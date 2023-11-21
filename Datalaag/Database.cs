using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Datalaag
{
    public static class Database
    {
        private static SqlConnection cn = new SqlConnection("Server=h2865773.stratoserver.net;Database=DeRuisvoorn;User Id=sa;Password=!!fn8565fn##;");
        public static DataTable Selecteer(string sql)
        {
            var cmd = new SqlCommand(sql, cn);
            cn.Open();
            var dt = new DataTable();
            var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();
            return dt;
        }
        
        public static bool Controleervisdatum(DateTime datum, long Serieid)
        {
            var sql = $"SELECT * FROM Agenda WHERE Serieid = {Serieid} AND Datum = '{datum.Year}-{datum.Month}-{datum.Day}'";
            var dt = Selecteer(sql);

            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static DateTime Getdatum(long Agendaid)
        {
            var sql = $"SELECT Datum FROM Agenda WHERE Agendaid = {Agendaid}";
            var dt = Selecteer(sql);
            if(dt.Rows.Count == 0)
            {
                return new DateTime();
            }
            return DateTime.Parse(dt.Rows[0]["Datum"].ToString());
        }
    }
}
