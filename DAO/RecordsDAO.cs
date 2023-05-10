using kursovik.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace kursovik.DAO
{
    public class RecordsDAO : DAO
    {

        public List<Route> GetRoute()
        {
            Connect();

            List<Records> route = new List<Records>();

            try
            {
                SqlCommand SQLcomm = new SqlCommand("Select * from Route", Connection);

                SqlDataReader reader = SQLcomm.ExecuteReader();

                while (reader.Read())
                {
                    Records record = new Records();
                    record.Id = Convert.ToString(reader["ID"]);
                    record.DeparturePoint = Convert.ToString(reader["DeparturePoint"]);
                    record.ArrivalPoint = Convert.ToString(reader["ArrivalPoint"]);
                    record.TimeDeparture = Convert.ToString(reader["TimeDeparture"]);
                    record.TimeArrival = Convert.ToString(reader["TimeArrival"]);
                    record.TransportId = Convert.ToString(reader["TransportId"]);
                    route.Add(record);
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return route;
        }
    public bool AddToContacts(Records records)
    {
        bool result = true;
        Connect();
        
        try
        {
            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Route (DeparturePoint, ArrivalPoint, TimeDeparture, TimeArrival) " + "VALUES (@DeparturePoint, @ArrivalPoint, @TimeDeparture, @TimeArrival)", Connection);
            
            cmd.Parameters.Add(new SqlParameter("@DeparturePoint", records.DeparturePoint));
            cmd.Parameters.Add(new SqlParameter("@ArrivalPoint", records.ArrivalPoint));
            cmd.Parameters.Add(new SqlParameter("@TimeDeparture", records.TimeDeparture));
            cmd.Parameters.Add(new SqlParameter("@TimeArrival", records.TimeArrival));
            
                cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            result = false;
        }
        finally
        {
            Disconnect();
        }
        return result;
    }

    }
}