using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domari;
using System;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class Zadatak3
    {
        #region Skolovanje
        [TestMethod]
        public void SkolovanjeIndeks()
        {
            Skolovanje skolovanje = new Skolovanje();
            skolovanje.BrojIndeksa = "123";
            Assert.AreEqual(skolovanje.BrojIndeksa, "123");
        }
        #endregion

        #region Stanar

        [TestMethod]
        public void BrojSobe()
        {
            Soba soba = new Soba(123, 2);
            Assert.AreEqual(soba.BrojSobe, 123);
        }

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
        #endregion

        #region LicniPodaci
        [TestMethod]
        public void ProvjeraKadaJeKonstruktorKlaseLicniPodaciPrazan()
        {
            LicniPodaci licniPodaci = new LicniPodaci();
            Assert.AreEqual(licniPodaci.Ime, null);
            Assert.AreEqual(licniPodaci.Spol, Spol.Muško);
        }

        [TestMethod]
        public void ProvjeraKadaJeKonstruktorKlaseLicniPodaciSaParametrima()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Sadik", "Jukic", "Sarajevo", "sjukic1@etf.unsa.ba", "postoji","1205998123321", Spol.Muško, DateTime.Parse("30.11.2020."));
            Assert.AreEqual(licniPodaci.Ime, "Sadik");
            Assert.AreEqual(licniPodaci.Prezime, "Jukic");
            Assert.AreEqual(licniPodaci.MjestoRodjenja, "Sarajevo");
            Assert.AreEqual(licniPodaci.Email, "sjukic1@etf.unsa.ba");
            Assert.AreEqual(licniPodaci.Slika, "postoji");
            Assert.AreEqual(licniPodaci.JMBG, "1205998123321");
            Assert.AreEqual(licniPodaci.Spol, Spol.Muško);
            Assert.AreEqual(licniPodaci.DatumRodjenja.ToString(), "30. 11. 2020. 00:00:00"); //pada zbog space
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaImena()
        {
            LicniPodaci licniPodaci = new LicniPodaci("  ", "Jukic", "Sarajevo", "sjukic1@etf.unsa.ba", "postoji", "1205998123321", Spol.Muško, DateTime.Parse("30.11.2020."));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaPrezimena()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Sadik", "juKic", "Sarajevo", "sjukic1@etf.unsa.ba", "postoji", "1205998123321", Spol.Muško, DateTime.Parse("30.11.2020."));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaMjestRodjenja()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Sadik", "Jukic", "", "sjukic1@etf.unsa.ba", "postoji", "1205998123321", Spol.Muško, DateTime.Parse("30.11.2020."));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaEmaila()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Sadik", "Jukic", "Sarajevo", "", "postoji", "1205998123321", Spol.Muško, DateTime.Parse("30.11.2020."));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaJMBGa()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Sadik", "Jukic", "Sarajevo", "sjukic1@etf.unsa.ba", "postoji", "1205998123321125", Spol.Muško, DateTime.Parse("30.11.2020."));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaDatuma()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Sadik", "Jukic", "Sarajevo", "sjukic1@etf.unsa.ba", "postoji", "1205998123321", Spol.Muško, DateTime.Parse("30.12.2020."));
        }
        #endregion

        #region StudenskiDom
        [TestMethod]
        public void RadSaStudentomNoviStudent()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 0);
            Assert.AreEqual(studentskiDom.Studenti.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void RadSaStudentomIstiStudent()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 0);
            studentskiDom.RadSaStudentom(student, 0);
        }

        [TestMethod]
        public void RadSaStudentomIzbaciStanar()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            Soba soba = studentskiDom.Sobe[0];
            soba.Stanari.Add(student);
            Assert.AreEqual(soba.Stanari.Count, 1);
            studentskiDom.RadSaStudentom(student, 1);
            Assert.AreEqual(soba.Stanari.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RadSaStudentomIzbaciNijeStanar()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 1);
        }

        [TestMethod]
        public void RadSaStudentomIzbrisi()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 0);
            Assert.AreEqual(studentskiDom.Studenti.Count, 1);
            studentskiDom.RadSaStudentom(student, 2);
            Assert.AreEqual(studentskiDom.Studenti.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void RadSaStudentomIzbrisiDrugog()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpisDomNemaSobe()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.UpisUDom(student, 5, false);
        }

        [TestMethod]
        public void UpisDomSlobodna()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.UpisUDom(student, 2, false);
            Soba soba = studentskiDom.Sobe[0];
            Assert.AreEqual(soba.Stanari.Count, 1);
        }

        [TestMethod]
        public void UpisDomZauzeta()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student student = new Student();
            studentskiDom.UpisUDom(student, 2, false);
            Soba soba = studentskiDom.Sobe[0];
            Assert.AreEqual(soba.Stanari.Count, 1);
            Student student2 = new Student();
            studentskiDom.UpisUDom(student2, 2, false);
            Assert.AreEqual(soba.Stanari.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void UpisDomZauzeteSveSobe()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student student = new Student();
            studentskiDom.UpisUDom(student, 2, true);
            Soba soba = studentskiDom.Sobe[0];
            Assert.AreEqual(soba.Stanari.Count, 1);
            Student student2 = new Student();
            studentskiDom.UpisUDom(student2, 2, true);
            Assert.AreEqual(soba.Stanari.Count, 2);
            Student student3 = new Student();
            studentskiDom.UpisUDom(student3, 2, true);
        }
        #endregion

        #region Student
        [TestMethod]
        public void StudentTest()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Sadik", "Jukic", "Sarajevo", 
                "sjukic1@etf.unsa.ba", "postoji", "1205998123321", Spol.Muško, DateTime.Parse("30.11.2020."));
            Skolovanje skolovanje = new Skolovanje();
            List<string> prebivaliste = new List<string>();
            Student student = new Student("sjukic1", "Sadik123", licniPodaci, prebivaliste, skolovanje);
            Assert.AreEqual(student.Podaci, licniPodaci);
            Assert.AreEqual(student.Prebivaliste, prebivaliste);
            Assert.AreEqual(student.StanjeRacuna, 1000.00);
        }

        [TestMethod]
        public void AzurirajStanje()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Sadik", "Jukic", "Sarajevo",
                "sjukic1@etf.unsa.ba", "postoji", "1205998123321", Spol.Muško, DateTime.Parse("30.11.2020."));
            Skolovanje skolovanje = new Skolovanje();
            List<string> prebivaliste = new List<string>();
            Student student = new Student("sjukic1", "Sadik123", licniPodaci, prebivaliste, skolovanje);
            Assert.AreEqual(student.StanjeRacuna, 1000.00);
            student.AzurirajStanjeRacuna(200.00);
            Assert.AreEqual(student.StanjeRacuna, 1200.00);
        }
        #endregion
    }
}
