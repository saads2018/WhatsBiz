using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WASender
{
    public class SqLiteBaseRepository
    {

        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int id;
        bool isDoubleClick = false;
        String connectString = @"Data Source=" + Config.GetSysFolderPath() + @"\db.db;version=3";

        public static void createTable()
        {

        }

        public DataTable getBySessionId(string SessionId)
        {
            try
            {
                if (isDefaultColumnExist() == 0)
                {
                    CreateDefautultColumn();
                    markasDefault();
                }

                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandType = CommandType.Text;
                String sql = "SELECT * FROM Sessions where sesionID=@SessionId";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SQLiteParameter("@SessionId", SessionId));
                conn.Open();
                
                adapter = new SQLiteDataAdapter(cmd);
                
                ds.Reset();
                adapter.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DataTable ReadData(bool getOnlyDefault=false)
        {
            try
            {
                if (isDefaultColumnExist() == 0)
                {
                    CreateDefautultColumn();
                    markasDefault();
                }

                conn = new SQLiteConnection(connectString);
                conn.Open();
                cmd = new SQLiteCommand();
                String sql = "SELECT * FROM Sessions";
                if (getOnlyDefault == true)
                {
                    sql = "SELECT * FROM Sessions where isDefault=1";
                }
                adapter = new SQLiteDataAdapter(sql, conn);
                ds.Reset();
                adapter.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataTable ReadDataExists(string sessionName)
        {
            try
            {
                conn = new SQLiteConnection(connectString);
                conn.Open();
                cmd = new SQLiteCommand();
                String sql = "SELECT * FROM Sessions where sessionName='" + sessionName + "'";
                adapter = new SQLiteDataAdapter(sql, conn);
                ds.Reset();
                adapter.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public int DeleteSession(string SessionId)
        {
            conn = new SQLiteConnection(connectString);
            cmd = new SQLiteCommand();
            cmd.CommandText = @"Delete from Sessions where  sesionID=@sesionID";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SQLiteParameter("@sesionID", SessionId));
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }


        public void setPrimaryAccount(string SessionId)
        {
            makeIsDefaultNull();
            try
            {
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = @"update Sessions set IsDefault=1 where ID=@sesionID;";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@sesionID", SessionId));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private void makeIsDefaultNull()
        {
            try
            {
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = @"update Sessions set IsDefault=null;";
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public void markasDefault()
        {
            try
            {
                cmd = new SQLiteCommand();
                cmd.CommandText = @"update Sessions set IsDefault=1 where sessionName='Profile1'";
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public void CreateDefautultColumn()
        {
            try
            {
                cmd = new SQLiteCommand();
                cmd.CommandText = @"alter table Sessions add isDefault INTEGER";
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }


        public int isDefaultColumnExist()
        {
            GenerateDatabase();
            int i = 0;
            conn = new SQLiteConnection(connectString);
            try
            {
                cmd = new SQLiteCommand();
                cmd.CommandText = @"SELECT EXISTS (SELECT * FROM sqlite_master WHERE tbl_name = 'Sessions' AND sql LIKE '%isDefault%') as 'ss'; ";
                cmd.Connection = conn;
                conn.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return i;
        }
        public string AddSession(string sessionName, string sessionId="")
        {
            if (sessionId == "")
            {
                sessionId = Guid.NewGuid().ToString();
            }
            //connectString = @"Data Source=" + Config.GetSysFolderPath() + @"\db.db;version=3";
            GenerateDatabase();
            conn = new SQLiteConnection(connectString);
            cmd = new SQLiteCommand();
            cmd.CommandText = @"INSERT INTO Sessions (sessionName,sesionID) VALUES(@sessionName,@sesionID)";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SQLiteParameter("@sessionName", sessionName));
            cmd.Parameters.Add(new SQLiteParameter("@sesionID", sessionId));
            conn.Open();
            int i = cmd.ExecuteNonQuery();

            if (i == 1)
            {
                //MessageBox.Show("Successfully Created!");
            }
            return sessionId;
        }



        private void GenerateDatabase()
        {
            conn = new SQLiteConnection(connectString);
            conn.Open();
            string sql = "CREATE TABLE if not exists Sessions (ID INTEGER PRIMARY KEY AUTOINCREMENT, sessionName TEXT,sesionID TEXT)";
            cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
