using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Spider.DbHelp
{
    public class Utilities
    {
        //执行查询
        public bool ExecBoolean(string SqlStr,string dbName) 
        {
            object result = null;
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            con.Open();
            try
            {
                result = com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Common.TypeConverter.StrToBool(result, false);
        }

        public DataSet ExecDataSet(string SqlStr, string dbName) 
        {
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public DataTable ExecDataTable(string SqlStr, string dbName) 
        {
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

        public decimal ExecDecimal(string SqlStr, string dbName)
        {
            object result = null;
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            con.Open();
            try
            {
                result = com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Common.TypeConverter.ObjectToDecimal(result);
        }

        public int ExecInt(string SqlStr, string dbName) 
        {
            object result = null;
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            con.Open();
            try
            {
                result = com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Common.TypeConverter.ObjectToInt(result, -1);
        }

        public SqlDataReader ExecReader(string SqlStr, string dbName)
        {
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = null;
            try
            {
                dr = com.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dr;
        }

        public void ExecNonQuery(string SqlStr, string dbName)
        {
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            con.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void ExecNonQuery(string SqlStr, SqlParameter[] paraArgs, string dbName)
        {
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            if (paraArgs.Length > 0)
            {
                com.Parameters.AddRange(paraArgs);
            }
            con.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void ExecNonQuery(SqlCommand mycom, string dbName)
        {
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            mycom.Connection = con;
            con.Open();
            try
            {
                mycom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public object ExecScalar(string SqlStr, string dbName)
        {
            object result = null;
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            con.Open();
            try
            {
                result = com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public string ExecString(string SqlStr, string dbName)
        {
            string result = "";
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection con = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand com = new SqlCommand(SqlStr, con);
            com.CommandType = CommandType.Text;
            con.Open();
            try
            {
                result = com.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        //批量插入
        public void TableValuedToDB(string Sql, DataTable dt, string dbName)
        {
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection sqlConn = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlCommand cmd = new SqlCommand(Sql, sqlConn);
            SqlParameter catParam = cmd.Parameters.AddWithValue("@NewBulkTestTvp", dt);
            catParam.SqlDbType = SqlDbType.Structured;
            //表值参数的名字叫BulkUdt，在上面的建立测试环境的SQL中有。  
            catParam.TypeName = "dbo.BulkUdt";
            try
            {
                sqlConn.Open();
                if (dt != null && dt.Rows.Count != 0)
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public void BulkToDB(DataTable dt, string dbName)
        {
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;
            SqlConnection sqlConn = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConn);
            bulkCopy.DestinationTableName = dt.TableName;
            bulkCopy.BatchSize = dt.Rows.Count;

            try
            {
                sqlConn.Open();
                if (dt != null && dt.Rows.Count != 0)
                    bulkCopy.WriteToServer(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                if (bulkCopy != null)
                    bulkCopy.Close();
            }
        }
      

        public void ExecuteBatchByCommandSet(SqlCommand[] cmdArgs, string dbName)
        {
            if (dbName == "") dbName = DbInfo.DefaultDbConfigName;

            using (SqlConnection conn = new SqlConnection(DbInfo.DbInfoDictionary[dbName].ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                try
                {
                    SqlCommandSet commandSet = new SqlCommandSet();
                    commandSet.Connection = conn;
                    commandSet.Transaction = trans;
                    SqlCommand cmd;
                    for (int i = 0; i < cmdArgs.Length; i++)
                    {
                        cmd = cmdArgs[i];
                        cmd.Connection = conn;
                        commandSet.Append(cmd);
                    }
                    commandSet.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    Console.WriteLine(e.ToString());
                }
            }

        }

    }
}
