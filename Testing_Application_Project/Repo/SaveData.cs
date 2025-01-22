using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Common_Project;
using Testing_Application_Project.Models;

namespace Testing_Application_Project.Repo
{
    public class SaveData
    {
        public void save(InstituteModel model) 
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection sqlcon = null;
            try
            {
                ClsFunction cls= new ClsFunction();
                sqlcon = cls.Connect();
                cmd.Connection = sqlcon;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Institute";
                cmd.Parameters.AddWithValue("@Institute_Name", model.Institute_Name);
                cmd.Parameters.AddWithValue("@Institute_Contact", model.Institute_Contact);
                cmd.Parameters.AddWithValue("@Institute_Address", model.Institute_Address);
                cmd.Parameters.AddWithValue("@Institute_Url", model.Institute_Url);
                cmd.Parameters.AddWithValue("@Institute_Email", model.Institute_Email);
                cmd.Parameters.AddWithValue("@Institute_Reg_No", model.Institute_Reg_No);

                if (model.Institute_id == 0)
                {
                    cmd.Parameters.AddWithValue("@flag", "I");
                    cmd.Parameters.AddWithValue("@Institute_id", model.Institute_id);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@flag", "U");
                    cmd.Parameters.AddWithValue("@Institute_id", model.Institute_id);
                }
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                cmd.Dispose();
                sqlcon.Close();
            }

        }
    }
}