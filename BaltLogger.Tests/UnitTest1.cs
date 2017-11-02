using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using BaltLogger.DbLogger;
using BaltLogger.FileLogger;

namespace BaltLogger.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private LoggerDbContext _context;

        //public UnitTest1()
        //{
        //    InitContext();
        //}

        //private void InitContext()
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<LoggerDbContext>()
        //        .UseInMemoryDatabase();
        //    //var connection = @"Server=(localdb)\mssqllocaldb;Database=BaltLoggerDb;Trusted_Connection=True;";
        //    //optionsBuilder.UseSqlServer(connection);
        //    _context = new LoggerDbContext(optionsBuilder.Options);
        //}

        [TestMethod]
        public void TestMethod1()
        {            
            var logger = new DbBaltLogger();
            var result = logger.Error(":( 2");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var logger = new FileBaltLogger();
            var result = logger.Error(":( 2");
            Assert.IsTrue(result);
        }
    }
}
