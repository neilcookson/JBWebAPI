using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ProductsControllerTests
    {
        [DataRow(1)]
        [DataTestMethod]
        public void GeProduct_ReturnsProduct_MatchingId(int id)
        {
            
        }

        [DataRow(999)]
        [DataTestMethod]
        public void GetProduct_ReturnsNotFound_NoMatchingId()
        {
           
        }
    }
}
