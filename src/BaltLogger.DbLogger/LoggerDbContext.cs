using BaltLogger.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltLogger.DbLogger
{
    public class DbLogInfo
    {
        public int Id { get; set; } //key
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }

    public class LoggerDbContext : DbContext
    {
        public LoggerDbContext(DbContextOptions<LoggerDbContext> options)
        : base(options)
        { }

        public DbSet<DbLogInfo> Logs { get; set; }
    }
}
