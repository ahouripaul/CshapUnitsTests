using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculateur.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Démo")]
        [TestProperty("Test Groupe2", "Sécurité")]
        [Priority(2)]
        [Owner("Jehann")]
        public void TestMethod1()
        {
        }

        [TestMethod]
        [TestCategory("Démo")]
        [TestProperty("Test Groupe2", "Sécurité")]
        [Priority(2)]
        [Owner("Jehann")]
        public void TestMethod2()
        {
        }
    }
}
