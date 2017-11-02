using BaltLogger.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace BaltLogger.DbLogger
{

    public class DbBaltLogger : IBaltLogger
    {
        private LoggerDbContext _db;
        private DbContextOptionsBuilder<LoggerDbContext> _optionsBuilder;

        //for tests
        public DbBaltLogger(string connectionString = null)
        {
            if (connectionString == null) connectionString = @"Server=(localdb)\mssqllocaldb;Database=BaltLoggerDb;Trusted_Connection=True;";
            _optionsBuilder = new DbContextOptionsBuilder<LoggerDbContext>();
            _optionsBuilder.UseSqlServer(connectionString);
            _db = new LoggerDbContext(_optionsBuilder.Options);
            _db.Database.Migrate();
        }

        //for asp.net core
        public DbBaltLogger(LoggerDbContext db)
        {
            _db = db;
        }
        public bool Error(string message)
        {
            try
            {
                _db.Logs.Add(new DbLogInfo { Type = "Error", Message = message, Date = DateTime.Now });
                _db.SaveChanges();
                _db.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }

        public bool Success(string message)
        {
            throw new NotImplementedException();
        }

        public bool Warning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
