using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domari;
using System;

namespace UnitTestProject2
{
    [TestClass]
    public class SobaTestovi
    {
        [TestMethod]
        public void DodajStanaraImaMjesta()
        {
            Soba soba = new Soba(123, 2);
            Student student1 = new Student();
            soba.DodajStanara(student1);
            Assert.AreEqual(soba.Stanari.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DodajStanaraNemaMjesta()
        {
            Soba soba = new Soba(123, 2);
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            soba.DodajStanara(student1);
            soba.DodajStanara(student2);
            soba.DodajStanara(student3);
        }

        [TestMethod]
        public void DaLiJeStanar()
        {
            Soba soba = new Soba(123, 2);
            Student student1 = new Student();
            Assert.IsFalse(soba.DaLiJeStanar(student1));
        }
    }
}
