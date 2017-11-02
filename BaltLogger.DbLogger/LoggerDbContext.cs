using BaltLogger.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltLogger.DbLogger
{
    public class DbLogInfo : LogInfo
    {
        public int Id { get; set; } //key
    }

    public class LoggerDbContext : DbContext
    {
        public LoggerDbContext(DbContextOptions<LoggerDbContext> options)
        : base(options)
        { }

        public DbSet<DbLogInfo> Logs { get; set; }
    }
}
