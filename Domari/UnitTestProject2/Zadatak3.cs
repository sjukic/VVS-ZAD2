using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domari;
using System;

namespace UnitTestProject2
{
    [TestClass]
    public class Zadatak3
    {
        #region Stanar
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
            Assert.AreEqual(licniPodaci.DatumRodjenja.ToString(), "30.11.2020. 00:00:00");
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
    }
}
