using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domari;
using System;

namespace UnitTestProject3
{
    [TestClass]
    public class StudenskiDomTest
    {
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

        //treba upis u dom
    }
}
