using System;
using System.Linq;
using D10221;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringResources.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(
               StringResource.GetString(typeof(Tests), "One"),
               "select 1 as One"
           );
        }
        [TestMethod]
        public void Test2()
        {
            Exception ex = null;
            try
            {
                StringResource.GetString(typeof(Tests), "x");
            }
            catch (StringResourceException e)
            {                
                ex = e;
            }
            Assert.IsNotNull(ex);
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(
               StringResource.GetStrings(typeof(Tests), "Two")
                .Aggregate((a, b) => a + b).Replace("\r", "").Replace("\n", ""),
               "select 1 as Two;select 2 as Two;"
           );
        }
    }
}
