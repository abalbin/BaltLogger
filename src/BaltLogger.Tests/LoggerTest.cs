using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltLogger.DbLogger;
using BaltLogger.FileLogger;
using BaltLogger.ConsoleLogger;

namespace BaltLogger.Tests
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void DbTest()
        {
            var logger = new DbBaltLogger();
            var result = logger.Error("test");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FileTest()
        {
            var logger = new FileBaltLogger();
            var result = logger.Error("test");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ConsoleTest()
        {
            var logger = new ConsoleBaltLogger();
            var result = logger.Error("test");
            Assert.IsTrue(result);
        }
    }
}
