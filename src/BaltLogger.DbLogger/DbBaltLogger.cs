﻿using BaltLogger.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Composition;
using System.Runtime.InteropServices;

namespace BaltLogger.DbLogger
{
    [Export(typeof(IBaltLogger))]
    public class DbBaltLogger : IBaltLogger
    {
        
        private LoggerDbContext _db;
        private DbContextOptionsBuilder<LoggerDbContext> _optionsBuilder;

        //for tests
        [ImportingConstructor]
        public DbBaltLogger()
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=BaltLoggerDb;Trusted_Connection=True;";
            _optionsBuilder = new DbContextOptionsBuilder<LoggerDbContext>();
            _optionsBuilder.UseSqlServer(connectionString);
            _db = new LoggerDbContext(_optionsBuilder.Options);
            _db.Database.Migrate();
        }
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

        public string LoggerName => "Balt Database Logger";

        public bool Error(string message)
        {
            try
            {
                _db.Logs.Add(new DbLogInfo { Type = "Error", Message = message, Date = DateTime.Now });
                _db.SaveChanges();
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
            try
            {
                _db.Logs.Add(new DbLogInfo { Type = "Success", Message = message, Date = DateTime.Now });
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool Warning(string message)
        {
            try
            {
                _db.Logs.Add(new DbLogInfo { Type = "Warning", Message = message, Date = DateTime.Now });
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
