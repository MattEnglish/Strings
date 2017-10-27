using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTraining.Tests
{
    [TestClass()]
    public class FixedWidthTests
    {
        [TestMethod()]
        public void GetFormattedTableTest()
        {
            var table = FixedWidth.GetFormattedTable();
            Assert.AreEqual(table[0], "| Pub Date    |                       Title | Authors                         |");
            Assert.AreEqual(table[1],"|=============================================================================|");
            Assert.AreEqual(table[2], "| 28 Nov 2008 |             Learning C# 3.0 | Jesse Liberty & Brian MacDonald |");
            Assert.AreEqual(table[3], "| 16 Sep 2013 |               Head First C# | Jennifer Greene & Andrew Ste... |");
            Assert.AreEqual(table[4], "| 27 Oct 2015 | Learn C# in One Day and ... | Jamie Chan                      |");
        }
    }
}