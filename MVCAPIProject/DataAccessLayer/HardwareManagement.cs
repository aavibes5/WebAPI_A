using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MVCAPIProject.DataAccessLayer
{
    public class HardwareManagement
    {
        #region Get All Device Details
        public DataSet GetDetails()
        {
            DataSet ds = new DataSet();
            ConnectionLayer.ConnectionClass cn = new ConnectionLayer.ConnectionClass();

            SqlDataAdapter sda = new SqlDataAdapter("getallplanets", cn.OpenConn());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            sda.Fill(ds);
            return ds;
        }
        #endregion


        #region Get Device Details By ID

        public DataSet getCategoryGV(int cde)
        {

            ConnectionLayer.ConnectionClass conto = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                conto = new ConnectionLayer.ConnectionClass();
                ds = new DataSet();
                sda = new SqlDataAdapter("getfromidplanets", conto.OpenConn());
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@pplntid", cde);
                sda.Fill(ds);
                return ds;

            }
            catch (SqlException x)
            {
                throw x;

            }
            finally
            {
                conto.CloseConn();

            }

        }
        #endregion

        #region Insert Into Planet Booking
        internal Task<int> InsertToTemp(Models.PlanetBooking book)
        {
            int res = 0;
            ConnectionLayer.ConnectionClass conto = null;
            SqlCommand cmd = null;
            try
            {
                conto = new ConnectionLayer.ConnectionClass();

                cmd = new SqlCommand("InsertOn", conto.OpenConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pEID", book.EID);
                cmd.Parameters.AddWithValue("@pPlID", book.PlanetID);
                cmd.Parameters.AddWithValue("@pHumnNme", book.HumanName);
                cmd.Parameters.AddWithValue("@pGendr", book.Gender);
                cmd.Parameters.AddWithValue("@pFamily", book.FamilySize);
                res = cmd.ExecuteNonQuery();
                return Task.FromResult(res);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conto.CloseConn();

            }
        }

        #endregion


        #region Update Temporary Booking
        internal Task<int> UpdateToTemp(int id, Models.PlanetBooking bk)
        {
            
            int res = 0;
            ConnectionLayer.ConnectionClass conto = null;
            SqlCommand cmd = null;
            try
            {
                conto = new ConnectionLayer.ConnectionClass();

                cmd = new SqlCommand("UpdteTempBook", conto.OpenConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pEID", id);
                cmd.Parameters.AddWithValue("@pPlID", bk.PlanetID);
                cmd.Parameters.AddWithValue("@pHumnNme", bk.HumanName);
                cmd.Parameters.AddWithValue("@pGendr", bk.Gender);
                cmd.Parameters.AddWithValue("@pFamily", bk.FamilySize);
                res = cmd.ExecuteNonQuery();
                return Task.FromResult(res);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conto.CloseConn();

            }
        }

        #endregion

        #region Delete Booking
        internal Task<int> DeleteRec(int id)
        {
            int res = 0;
            ConnectionLayer.ConnectionClass conto = null;
            SqlCommand cmd = null;
            try
            {
                conto = new ConnectionLayer.ConnectionClass();
                cmd = new SqlCommand("DeleteMyRecord", conto.OpenConn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EID", id);
                res = cmd.ExecuteNonQuery();
                return Task.FromResult(res);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion



    }
}