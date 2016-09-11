using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Windows.Forms;

namespace AlphabetDictionaryGGJM.SqliteClass
{
    /// <summary>
    /// SQLITE DB 資料庫
    /// </summary>
    public class SqliteDB
    {


        /// <summary>
        /// 建構式 - 讀取Sqlite config
        /// </summary>
        public SqliteDB()
        {
        }

        /// <summary>
        /// 取得Guid 16個小寫字母 ascii 97~122
        /// </summary>
        private string Get_guid()
        {
            string guid = "";
            Random Get=new Random();
            for (int i = 0; i < 16; i++)
                guid += (char)Get.Next(97, 123); 

            return guid;
        }

        /// <summary>
        /// 建立資料表 
        /// </summary>
        /// <param name="tableName">資料表名稱</param>
        /// <param name="column">資料表欄位</param>
        /// <param name="attrtitube">資料屬性</param>
        public string BuildeTable(string tableName, List<string> column)//, List<string> attrtitube)
        {
            SQLiteConnection sqlite_conn;//----連結建立
            SQLiteCommand sqlite_cmd;//--------連結指令建立
            try
            {
                sqlite_conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["sqlite"].ToString());//取得sqlite位置
                sqlite_conn.Open();//--------------打開資料庫
                sqlite_cmd = sqlite_conn.CreateCommand();//--啟動資料庫指令

                //組合 column名稱
                string Combine = "";
                for (int i = 0; i < column.Count; i++)
                {
                    if (i >= column.Count - 1)
                        Combine += column[i];
                    else
                        Combine += column[i] + ", ";
                }

                string guid = this.Get_guid();
                //建立表的語法
                sqlite_cmd.CommandText = "CREATE TABLE if not exists " + guid + "(" + Combine + ");";
                sqlite_cmd.ExecuteNonQuery();//----執行

                #region  =======  並且要插入索引中  ==========

                //建立索引表 
                sqlite_cmd.CommandText = "CREATE TABLE  if not exists " + "Table_Index" + "(Guid, TableName);";
                sqlite_cmd.ExecuteNonQuery();//----執行

                //INSERT INTO StockNo (StockNo, StockName, StockClass) VALUES ( " + '"' + DB[
                sqlite_cmd.CommandText = "insert into Table_Index (Guid, TableName) values('" + guid + "', '" + tableName + "');";
                sqlite_cmd.ExecuteNonQuery();//----執行
                #endregion
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                return "error :" + ex.Message;
            }
            return "建立成功!";
        }

        /// <summary>
        /// 回傳目前的Table_index表 里的資料項目
        /// </summary>
        /// <returns></returns>
        public List<string> Get_Table_Index()
        {
            List<string> DB = new List<string>();

            try
            {
                SQLiteConnection sqlite_conn;//----連結建立
                SQLiteCommand sqlite_cmd;//--------連結指令建立

                sqlite_conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["sqlite"].ToString());//取得sqlite位置
                sqlite_conn.Open();//--------------打開資料庫
                sqlite_cmd = sqlite_conn.CreateCommand();//--啟動資料庫指令


                sqlite_cmd.CommandText = "Select * From  Table_Index";//--取得該表資料
                sqlite_cmd.ExecuteNonQuery();//----執行
                SQLiteDataReader Data = sqlite_cmd.ExecuteReader();

                while (Data.Read())//---------------------------------不斷的寫入股號
                    DB.Add(Data["TableName"].ToString());

                sqlite_conn.Close();//close
            }
            catch (Exception ex)
            {
                DB.Add(ex.Message);
            }
            return DB;
            
        }

        /// <summary>
        /// 回傳使用者選定的資料表 DataGridView
        /// </summary>
        /// <param name="table_name">資料表名稱</param>
        /// <param name="ResourceGrid">帶進來的GridData</param>
        /// <returns>取得的所有資料內容</returns>
        public DataGridViewRowCollection Get_SelectTable(string table_name , DataGridViewRowCollection ResourceGrid)
        {
            DataGridViewRowCollection DB = ResourceGrid;

            string apply_guid = Get_apply_guid(table_name);//取得對應的表GUID
            try
            {
                SQLiteConnection sqlite_conn;//----連結建立
                SQLiteCommand sqlite_cmd;//--------連結指令建立

                sqlite_conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["sqlite"].ToString());//取得sqlite位置
                sqlite_conn.Open();//--------------打開資料庫
                sqlite_cmd = sqlite_conn.CreateCommand();//--啟動資料庫指令

                sqlite_cmd.CommandText = "Select *  From " + apply_guid;//--取得該表資料(轉成GUID)
                sqlite_cmd.ExecuteNonQuery();//----執行
                SQLiteDataReader Data = sqlite_cmd.ExecuteReader();

                while (Data.Read())//---------------------------------不斷的取資料
                    DB.Add(new object[] { Data["English"].ToString(), Data["Chinese"].ToString() });

                Data.Close();
                sqlite_conn.Close();//close
            }
            catch(Exception ex)
            {
                DB.Add(new object[] { "error", ex.Message });
            }

            return DB;
        }

        /// <summary>
        /// 回傳使用者選定的資料表 List 
        /// </summary>
        /// <param name="table_name">資料表名稱</param>
        /// <param name="ResourceGrid">帶進來的GridData</param>
        /// <returns>取得的所有資料內容</returns>
        public List<AlphaBetTable> Get_SelectTable(string table_name)
        {
            List<AlphaBetTable> DB = new List<AlphaBetTable>(); ;
            string apply_guid = Get_apply_guid(table_name);//取得對應的表GUID
            try
            {
                SQLiteConnection sqlite_conn;//----連結建立
                SQLiteCommand sqlite_cmd;//--------連結指令建立

                sqlite_conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["sqlite"].ToString());//取得sqlite位置
                sqlite_conn.Open();//--------------打開資料庫
                sqlite_cmd = sqlite_conn.CreateCommand();//--啟動資料庫指令

                sqlite_cmd.CommandText = "Select *  From " + apply_guid;//--取得該表資料(轉成GUID)
                sqlite_cmd.ExecuteNonQuery();//----執行
                SQLiteDataReader Data = sqlite_cmd.ExecuteReader();

                while (Data.Read())//---------------------------------不斷的取資料
                {
                    AlphaBetTable Single = new AlphaBetTable();
                    Single.English = Data["English"].ToString();
                    Single.Chinese = Data["Chinese"].ToString();

                    DB.Add(Single);
                }
                Data.Close();
                sqlite_conn.Close();//close
            }
            catch (Exception ex)
            {
                
            }

            return DB;
        }


        /// <summary>
        /// 寫入單字到資料表
        /// </summary>
        /// <param name="table_name">寫進的資料表</param>
        /// <param name="eng">英文單字</param>
        /// <param name="chi">中文內容</param>
        /// <returns>回傳訊息</returns>
        public string Write_Alphabet(string table_name, string eng , string chi)
        {

            string apply_guid = Get_apply_guid(table_name);//取得對應的表GUID
            SQLiteConnection sqlite_conn;//----連結建立
            SQLiteCommand sqlite_cmd;//--------連結指令建立
            try
            {
                sqlite_conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["sqlite"].ToString());//取得sqlite位置
                sqlite_conn.Open();//--------------打開資料庫
                sqlite_cmd = sqlite_conn.CreateCommand();//--啟動資料庫指令

                sqlite_cmd.CommandText = "insert into " + apply_guid + "(English, Chinese) values(@English, @Chinese);";

                sqlite_cmd.Parameters.AddWithValue("@English", eng);
                sqlite_cmd.Parameters.AddWithValue("@Chinese", chi);
                sqlite_cmd.ExecuteNonQuery();//----執行

                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                return "error :" + ex.Message;
            }

            return "寫入單字成功!";
        }

        /// <summary>
        /// 從資料表刪除該單字
        /// </summary>
        /// <param name="table_name">工作的資料表</param>
        /// <param name="eng">英文單字</param>
        /// <param name="chi">中文內容</param>
        /// <returns>回傳訊息</returns>
        public string Delete_Alphabet(string table_name, string eng, string chi)
        {
            SQLiteConnection sqlite_conn;//----連結建立
            SQLiteCommand sqlite_cmd;//--------連結指令建立

            try
            {
                sqlite_conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["sqlite"].ToString());//取得sqlite位置
                sqlite_conn.Open();//--------------打開資料庫
                sqlite_cmd = sqlite_conn.CreateCommand();//--啟動資料庫指令

                string apply_guid = Get_apply_guid(table_name);

                sqlite_cmd.CommandText = "DELETE FROM " + apply_guid + " WHERE English = @English ";
                sqlite_cmd.Parameters.AddWithValue("@English", eng);
                sqlite_cmd.ExecuteNonQuery();//----執行

                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                return "error :" + ex.Message;
            }
            return "刪除單字成功!";
        }

        /// <summary>
        /// 取得對應到的GUID => TableName
        /// </summary>
        /// /// <param name="table_name">資料表中文名稱</param>
        /// <returns></returns>
        public string Get_apply_guid(string table_name)
        {
            string apply_guid = "";
            try
            {
                SQLiteConnection sqlite_conn;//----連結建立
                SQLiteCommand sqlite_cmd;//--------連結指令建立

                sqlite_conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["sqlite"].ToString());//取得sqlite位置
                sqlite_conn.Open();//--------------打開資料庫
                sqlite_cmd = sqlite_conn.CreateCommand();//--啟動資料庫指令

                sqlite_cmd.CommandText = "Select *  From Table_index Where TableName = '" + table_name + "'";//--取得該表資料
                sqlite_cmd.ExecuteNonQuery();//----執行
                SQLiteDataReader Data = sqlite_cmd.ExecuteReader();


                while (Data.Read())//---------------------------------取得tablename對應的GUID
                {
                    apply_guid = Data["Guid"].ToString();
                }
                Data.Close();
                sqlite_conn.Close();//close
            }
            catch (Exception ex)
            { 

            }
            return apply_guid;
        }
    }


    public class AlphaBetTable
    {
        public string English;
        public string Chinese;
    }
}
