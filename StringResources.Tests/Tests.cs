using System;
using System.Linq;
using D10221;
using NUnit.Framework;

namespace StringResources.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(
               StringResource.GetString(typeof(Tests), "One"),
               "select 1 as One"
           );
        }
        [Test]
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
        [Test]
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
