using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Domari;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Zadatak1
    {
        //test napisao Faris Hrvo
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

        //test napisao Sanjin Šabanović
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

        //test napisao Sanjin Šabanović
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

        //test napisao Sadik Jukić
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

        //test napisao Sanjin Šabanović
        [TestMethod]
        public void TestIstiMatcniFakultet()
        {
            Student student = new Student();
            string fakultet = "Elektrotehnički fakultet";
            int godine = 2, ciklus = 1;
            student.Skolovanje = new Skolovanje();
            student.PromjenaInformacijaOSkolovanju(fakultet, godine, ciklus);
            Assert.AreEqual(student.Skolovanje.MaticniFakultet, "Elektrotehnički fakultet");
            Assert.AreEqual(student.Skolovanje.GodinaStudija, 2);
        }

        //test napisao Sanjin Šabanović
        [TestMethod]
        public void TestIstiMatcniFakultetRazlicitCiklusStudija()
        {
            Student student = new Student();
            string fakultet = "Elektrotehnički fakultet";
            int godine = 2, ciklus = 2;
            student.Skolovanje = new Skolovanje();
            student.PromjenaInformacijaOSkolovanju(fakultet, godine, ciklus);
            Assert.AreEqual(student.Skolovanje.MaticniFakultet, "Elektrotehnički fakultet");
            Assert.AreEqual(student.Skolovanje.GodinaStudija, 2);
            Assert.AreEqual(student.Skolovanje.CiklusStudija, 2);
        }

        //test napisao Faris Hrvo
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

        //test napisao Sadik Jukić
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

        //test napisao Faris Hrvo
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
            Assert.AreEqual(soba.Kapacitet, 2);
            Assert.AreEqual(soba.Stanari.Count, 2);
        }

        //test napisao Sadik Jukić
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

        //test napisao Faris Hrvo
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

        //test napisao Sadik Jukić
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeuspjesnePromjeneKapaciteta()
        {
            Soba soba = new Soba(1, 4);
            soba.PromjenaBrojaSobe(525);
        }
    }
}
