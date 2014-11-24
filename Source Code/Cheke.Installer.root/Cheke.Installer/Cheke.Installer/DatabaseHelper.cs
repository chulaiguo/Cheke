using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Cheke.Installer
{
    public class DatabaseHelper
    {
        private readonly string _connectionString = string.Empty;
        private readonly string _databaseName = string.Empty;

        public DatabaseHelper(string connectionString, string databaseName)
        {
            this._connectionString = connectionString;
            this._databaseName = databaseName;
        }

        public bool IsDatabaseExist()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("use master ");
            builder.AppendFormat("SELECT NAME FROM SYSDATABASES WHERE NAME='{0}';", this._databaseName);
            string result = this.ExecuteScalar(builder.ToString());
            return !string.IsNullOrEmpty(result);
        }

        public void RestoreDatabase(string backupFile)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("use master ");
            builder.AppendFormat("select   filename   from   sysfiles   where   name= 'master';");
            string path = this.ExecuteScalar(builder.ToString());
            if (string.IsNullOrEmpty(path))
                return;

            int index = path.LastIndexOf('\\');
            string dataPath = path.Substring(0, index);

            builder = new StringBuilder();
            builder.AppendFormat("use master ");
            builder.AppendFormat("IF EXISTS (SELECT NAME FROM SYSDATABASES WHERE NAME='{0}') DROP DATABASE {0};", this._databaseName);
            builder.AppendFormat("restore database {1} from disk='{0}' WITH FILE = 1,MOVE '{1}' TO '{2}\\{1}.mdf', MOVE '{1}_log' TO '{2}\\{1}_log.ldf',REPLACE;", backupFile, this._databaseName, dataPath);
            this.ExecuteNonQuery(builder.ToString());
        }

        public void CreateDatabase()
        {
            string sql = string.Format("use master  create database \"{0}\";", this._databaseName);
            this.ExecuteNonQuery(sql);
        }

        public void DropDatabase()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("use master ");
            builder.AppendFormat("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", this._databaseName);
            builder.AppendFormat("drop database {0};", this._databaseName);
            builder.AppendFormat("DROP LOGIN [{0}];", this._databaseName);

            this.ExecuteNonQuery(builder.ToString());
        }

        public void CreateDatatableBySQLFile(string sqlFile, string databaseConnectionString)
        {
            if (!File.Exists(sqlFile))
                return;

            string sql = string.Empty;
            string[] lines = File.ReadAllLines(sqlFile);
            foreach (string line in lines)
            {
                if(string.IsNullOrEmpty(line))
                    continue;

                if(line.StartsWith("/*"))
                    continue;

                if (line.StartsWith("create database", StringComparison.OrdinalIgnoreCase) 
                    || line.StartsWith("use", StringComparison.OrdinalIgnoreCase))
                    continue;

                if(string.Compare(line, "go", StringComparison.OrdinalIgnoreCase) != 0)
                {
                    sql += line.TrimEnd('\r', '\n');
                    continue;
                }

                if(string.IsNullOrEmpty(sql))
                    continue;

                ExecuteNonQuery(sql, databaseConnectionString);
                sql = string.Empty;
            }
        }

        public void CreateLoginUser()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("use master ");
            builder.AppendFormat("if exists (select * from sys.server_principals where type = 'S' and name ='{0}')  drop login [{0}];", this._databaseName);
            builder.AppendFormat("create login [{0}] with password='', default_database = [{0}], check_expiration=off, check_policy=off;", this._databaseName);
            this.ExecuteNonQuery(builder.ToString());
        }

        public void CreateDatabaseUser()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("use {0} ", this._databaseName);
            builder.AppendFormat("if exists (select * from sys.database_principals where type = 'S' and name ='{0}')  drop user {0};", this._databaseName);
            builder.AppendFormat("create user [{0}] for login [{0}] with default_schema = [dbo];", this._databaseName);
            builder.AppendFormat("exec sp_addrolemember 'db_owner', [{0}];", this._databaseName);
            this.ExecuteNonQuery(builder.ToString());
        }

        public void ExecuteSql(string sql)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("use master ");
            builder.AppendFormat("{0}", sql);
          
            this.ExecuteNonQuery(builder.ToString());
        }

        private void ExecuteNonQuery(string commandText)
        {
            ExecuteNonQuery(commandText, this._connectionString);
        }

        private string ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, this._connectionString);
        }

        private static void ExecuteNonQuery(string commandText, string connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = commandText;
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
            }
        }

        private static string ExecuteScalar(string commandText, string connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = commandText;
                    object obj = command.ExecuteScalar();
                    if (obj != null)
                    {
                        return obj.ToString();
                    }
                }
            }
            catch
            {
            }

            return string.Empty;
        }
    }
}


//use master
//IF EXISTS (SELECT NAME FROM SYSDATABASES WHERE NAME='REST') DROP DATABASE REST;
//restore database REST from disk='F:\REST.bak'
//WITH FILE = 1,
//   MOVE 'REST' TO 'F:\REST.mdf', 
//   MOVE 'REST_log' TO 'F:\REST_log.ldf',
//REPLACE, STATS = 10



//-- =======================================================================
//-- SQL SCRIPT to create LOGIN in the SERVER, and assign sysadmin role to it.
//-- =======================================================================
//use master
//go
 
//if exists (select * from sys.server_principals where type = 'S' and name ='REST')
// drop login [REST]
//go
//create login [REST] with password='REST_REST', default_database = [REST]
//go
//--exec sp_addsrvrolemember 'REST','sysadmin'


//-- =======================================================================
//-- SQL SCRIPT to create DATABASE USER linked to the existing 
//-- SERVER LOGIN in Test Database. And then assign db_owner role to this 
//-- database user 'REST'.
//-- =======================================================================
//use REST
//go
 
//if exists (select * from sys.database_principals where type = 'S' and name ='REST')
// drop user REST
//go

//create user [REST] for login [REST] with default_schema = [dbo]
//go

//exec sp_addrolemember 'db_owner', [REST]
//go

