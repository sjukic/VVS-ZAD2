using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Domari;


namespace UnitTestProject1
{
    class PromjenaInformacijaOSkolovanjuTest
    {
        [TestMethod]
        public void TEST1()
        {
            Student student = new Student();
            string fakultet = "Elektrotehnički fakultet"; 
            int godine = 1, ciklus = 1;
            student.PromjenaInformacijaOSkolovanju(fakultet, godine, ciklus);
            Assert.AreEqual(student.Skolovanje.MaticniFakultet, "Elektrotehnički fakultet");
        }
    }
}
