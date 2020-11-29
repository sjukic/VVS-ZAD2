using Domari;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class NoviTestovi
    {
        #region Zamjenski Objekti
        public interface IPodaci
        {
            string DajImePaviljona();
        }

        public class Paviljon : IPodaci
        {
            int brojac = 0;
            public string DajImePaviljona()
            {
                brojac++;
                return "Paviljon" + brojac;
            }
        }

        [TestMethod]
        public void TestZamjenskiObjekat()
        {
            /*StudentskiDom dom = new StudentskiDom(15);

            Student s = new Student();
            s.Skolovanje = new Skolovanje();
            s.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s, 0);

            IPodaci paviljon = new Paviljon();

            List<Student> studenti = dom.DajStudenteIzPaviljona(paviljon);

            Assert.IsTrue(studenti.Find(student => student.IdentifikacioniBroj == s.IdentifikacioniBroj) != null);*/
        }

        #endregion

        #region TDD

        public class Skolovanje
        {
            #region Atributi

            string maticniFakultet, brojIndeksa;
            int godinaStudija, ciklusStudija;

            #endregion

            #region Properties

            public string MaticniFakultet
            {
                get => maticniFakultet;
                set => maticniFakultet = value;
            }
            public string BrojIndeksa
            {
                get => brojIndeksa;
                set => brojIndeksa = value;
            }
            public int GodinaStudija
            {
                get => godinaStudija;
                set => godinaStudija = value;
            }
            public int CiklusStudija
            {
                get => ciklusStudija;
                set => ciklusStudija = value;
            }

            #endregion

            #region Konstruktor

            public Skolovanje()
            {
                maticniFakultet = "Elektrotehnički fakultet";
                brojIndeksa = StudentskiDom.GenerišiSljedećiBroj();
                GodinaStudija = 1;
                CiklusStudija = 1;
            }

            #endregion

            #region Metode

            public double PromjenaGodineStudija(int godina, int ciklus)
            {
                if (ciklus == 1) return 1800;
                else if (ciklus == 2) return 2000;
                else throw new ArgumentException();
            }

            #endregion
        }

        [TestMethod]
        public void TestPrviCiklusStudija()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(1, 1);

            Assert.AreEqual(1800, skolarina);
        }

        [TestMethod]
        public void TestDrugiCiklusStudija()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(2, 2);

            Assert.AreEqual(2000, skolarina);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeispravniPodaci()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(7, 0);
        }

        #endregion
    }
}
