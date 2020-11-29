using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Domari;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class PromjenaSobeTest
    {
        [TestMethod]
        public void TestKadaJeKapacitetVeci()
        {
            int brojSobe = 122;
            Student student1 = new Student(), student2 = new Student();
            StudentskiDom studentskiDom = new StudentskiDom(brojSobe);
            studentskiDom.Studenti.Add(student1);
            studentskiDom.Studenti.Add(student2);
            Soba soba = studentskiDom.Sobe[0];
            soba.Stanari.Add(student1);
            soba.Stanari.Add(student2);
            studentskiDom.PromjenaSobe(soba, 3);
            Assert.AreEqual(3, soba.Kapacitet);
        }

        [TestMethod]
        public void TestKadaJeKapacitetIsti()
        {
            int brojSobe = 350;
            Student student1 = new Student(), student2 = new Student();
            StudentskiDom studentskiDom = new StudentskiDom(brojSobe);
            studentskiDom.Studenti.Add(student1);
            studentskiDom.Studenti.Add(student2);
            Soba soba = studentskiDom.Sobe[0];
            soba.Stanari.Add(student1);
            soba.Stanari.Add(student2);
            studentskiDom.PromjenaSobe(soba, 2);
            Assert.AreEqual(2, soba.Kapacitet);
        }

        [TestMethod]
        public void TestKadaJeKapacitetManji()
        {
            int brojSobe = 350;
            Student student1 = new Student(), student2 = new Student();
            StudentskiDom studentskiDom = new StudentskiDom(brojSobe);
            studentskiDom.Studenti.Add(student1);
            studentskiDom.Studenti.Add(student2);
            Soba soba = studentskiDom.Sobe[0];
            soba.Stanari.Add(student1);
            soba.Stanari.Add(student2);
            studentskiDom.PromjenaSobe(soba, 1);
            Assert.AreEqual(1, soba.Kapacitet);
        }

        [TestMethod]
        public void TestPromjeneMatcnogFakulteta()
        {
            Student student = new Student();
            string fakultet = "Pravo";
            int godine = 1, ciklus = 1;
            student.Skolovanje = new Skolovanje();
            student.PromjenaInformacijaOSkolovanju(fakultet, godine, ciklus);
            Assert.AreEqual(student.Skolovanje.MaticniFakultet, "Pravo");
        }

        [TestMethod]
        public void TestIstiMatcniFakultet()
        {
            Student student = new Student();
            string fakultet = "Elektrotehnièki fakultet";
            int godine = 2, ciklus = 1;
            student.Skolovanje = new Skolovanje();
            student.PromjenaInformacijaOSkolovanju(fakultet, godine, ciklus);
            Assert.AreEqual(student.Skolovanje.MaticniFakultet, "Elektrotehnièki fakultet");
            Assert.AreEqual(student.Skolovanje.GodinaStudija, 2);
        }

        [TestMethod]
        public void TestIstiMatcniFakultetRazlicitCiklusStudija()
        {
            Student student = new Student();
            string fakultet = "Elektrotehnièki fakultet";
            int godine = 2, ciklus = 2;
            student.Skolovanje = new Skolovanje();
            student.PromjenaInformacijaOSkolovanju(fakultet, godine, ciklus);
            Assert.AreEqual(student.Skolovanje.MaticniFakultet, "Elektrotehnièki fakultet");
            Assert.AreEqual(student.Skolovanje.GodinaStudija, 2);
            Assert.AreEqual(student.Skolovanje.CiklusStudija, 2);
        }

        [TestMethod]
        public void TestPasswordaKadaSuRazliciti()
        {
            Student student = new Student();
            student.Username = "Faris";
            student.Password = "HrvoHrvo";

            try
            {
                student.PromjenaPassworda("SadikSadik", "SelmaBajrami");
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestPasswordaKadaSuIsti()
        {
            Student student = new Student();
            student.Username = "Faris";
            student.Password = "HrvoHrvo";

            try
            {
                student.PromjenaPassworda("HrvoHrvo", "SelmaBajrami");
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestSobaKadaJeKapacitet2()
        {
            Soba soba = new Soba(1, 3);
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            soba.Stanari.Add(student1);
            soba.Stanari.Add(student2);
            soba.Stanari.Add(student3);
            soba.PromjenaBrojaSobe(105);
            Assert.AreEqual(soba.Kapacitet,2);
            Assert.AreEqual(soba.Stanari.Count, 2);
        }

        [TestMethod]
        public void TestSobaKadaJeKapacitet3()
        {
            Soba soba = new Soba(1, 4);
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            Student student4 = new Student();
            soba.Stanari.Add(student1);
            soba.Stanari.Add(student2);
            soba.Stanari.Add(student3);
            soba.Stanari.Add(student4);
            soba.PromjenaBrojaSobe(205);
            Assert.AreEqual(soba.Kapacitet, 3);
            Assert.AreEqual(soba.Stanari.Count, 3);
        }

        [TestMethod]
        public void TestSobaKadaJeKapacitet4()
        {
            Soba soba = new Soba(1, 4);
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            Student student4 = new Student();
            Student student5 = new Student();
            soba.Stanari.Add(student1);
            soba.Stanari.Add(student2);
            soba.Stanari.Add(student3);
            soba.Stanari.Add(student4);
            soba.Stanari.Add(student5);
            soba.PromjenaBrojaSobe(325);
            Assert.AreEqual(soba.Kapacitet, 4);
            Assert.AreEqual(soba.Stanari.Count, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeuspjesnePromjeneKapaciteta()
        {
            Soba soba = new Soba(1, 4);
            soba.PromjenaBrojaSobe(525);
        }
    }
}
