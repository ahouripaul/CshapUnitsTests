using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Calculateur.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /*
         * Pour envoyer des messages vers la console de sortie:
         * Console.WriteLine
         * Debug.WriteLine
         * MessageBox.Show()
         * TestContext - WriteLine
         * 
         */

        //TestContext: classe abstraite fournie par MsTest, qui propose certaines méthodes d'instances
        //intéressantes.
        //Pour instancier la classe TestContext, il suffit de déclarer un attribut qui porte de la classe

        public TestContext TestContext { get; set; }

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
            Console.WriteLine("Message via Console.WriteLIne()");
            Debug.WriteLine("Message via Debug.WriteLine()");
            MessageBox.Show("Message via MessageBox");
            TestContext.WriteLine("Message via TestContext");
            TestContext.WriteLine(TestContext.TestName);
        }
    }
}
