using System;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using D10221;
using NLog;
using Dapper;

namespace ScriptResources.Demo
{
    public class Database
    {
        public static Database Default = new Database();

        ILogger logger = LogManager.GetCurrentClassLogger();

        IDbConnection connection;

        public Database()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "License.Manager.sqlite.db");
            connection = new SqliteConnection($"Data Source={path}");
            connection.Open();
        }

        public IDbConnection Connection
        {
            get
            {
                return connection;
            }
        }

        private readonly string[] scripts = StringResource.GetStrings<Database>("Setup");

        public void Setup()
        {
            try
            {
                foreach (var script in scripts)
                {
                    try
                    {
                        logger.Info(script);
                        connection.Execute(script);

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                }
                logger.Info("Setup Completed");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        public object Query()
        {
            return Connection
                .Query(
                    StringResource.GetString<Database>("Query"),
                    new { name = "x" })
                        .FirstOrDefault();
        }

    }
}