using Microsoft.VisualStudio.TestTools.UnitTesting;
using projekt_IO.SubSystem.Users;
using System;

namespace StudentTest
{
    [TestClass]
    public class StudentTest
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void StudentConstructorFirstNameNullTest()
        {
            //arrange
            var TestClass = new Student(null, "Chełmikowska", "fifiq@student.agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");

        }
        [TestMethod]
        public void StudentConstructorFirstNameTest()
        {
            //arrange
            var TestClass = new Student("Fifi", "Chełmikowska", "fifiqstudent@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var expected = "Fifi";

            var actual = TestClass.FirstName;

            Assert.AreEqual(expected, actual);

        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void StudentConstructorLastNameNullTest()
        {
            //arrange
            var TestClass = new Student("Fifi", null, "fifiq@student.agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");

        }

        [TestMethod]
        public void StudentConstructorLastNameTest()
        {
            //arrange
            var TestClass = new Student("Fifi", "Chełmikowska", "fifiqstudent@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var expected = "Chełmikowska";

            var actual = TestClass.LastName;

            Assert.AreEqual(expected, actual);

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void StudentConstructorEmailNullTest()
        {
            //arrange
            var TestClass = new Student("Fifi", "Chełmikowska", null, "fifi123", "Informatyka i Ekonometria", "WZ");

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void StudentConstructorEmailWithoutAtTest()
        {
            //arrange
            var TestClass = new Student("Fifi", "Chełmikowska", "fifiqstudent.agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");

        }

        
        [TestMethod]
        public void StudentConstructorEmailAtTest2()
        {
            //arrange
            var TestClass = new Student("Fifi", "Chełmikowska", "fifiqstudent@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var expected = "fifiqstudent@agh.edu.pl";

            var actual = TestClass.Email;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddSupervisorTest()
        {
            //arrange
            var StudentTestClass = new Student("Fifi", "Chełmikowska", "fifiqstudent@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var SupervisorTestClass = new UniversityEmployee("Pan", "Paweł", "ppawel@agh.edu.pl", "123", "dr hab", "WZ");
            var expected = SupervisorTestClass;

            
            StudentTestClass.AddSupervisor(SupervisorTestClass);
            var actual = StudentTestClass.Supervisor;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddReviewerrTest()
        {
            //arrange
            var StudentTestClass = new Student("Fifi", "Chełmikowska", "fifiqstudent@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var ReviewerTestClass = new UniversityEmployee("Pan", "Paweł", "ppawel@agh.edu.pl", "123", "dr hab", "WZ");
            var expected = ReviewerTestClass;


            StudentTestClass.AddReviewer(ReviewerTestClass);
            var actual = StudentTestClass.Reviewer;
            Assert.AreEqual(expected, actual);

        }

        //klasy rownowaznosci
        // Oceny O:
        // O1: oceny 2 i 2.5
        // O2: ocena 3
        // O3: ocena 3.5
        // O4: ocena 4
        // O5: ocena 4.5
        // O6: ocena 5
        // O7: liczby wszystkie inne niz powyzsze

        //O1
        [DataRow(2 , "Niezaliczone")]

        //O2
        [DataRow(3, "Dostateczny")]

        //O3
        [DataRow(3.5, "Dostateczny plus")]

        //O4
        [DataRow(4.0, "Dobry")]

        //O5
        [DataRow(4.5, "Dobry plus")]

        //O6
        [DataRow(5.0, "Bardzo dobry")]

        //O7
        [DataRow(7.0, "Brak oceny")]

        [DataTestMethod]
        public void StudentGetStudiesResultTest(double mark, string expected)
        {
            //arrange
            var TestClass = new Student("Fifi", "Chełmikowska", "fifiqstudent@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");

            //act
            TestClass.GetStudiesResult(mark);
            var actual = TestClass.StudiesResult;

            Assert.AreEqual(expected, actual);

        }

        //koncepcja testowania w poblizu granic

        
        [DataRow(1.5, "Brak oceny")]
        
        [DataRow(2.0, "Niezaliczone")]

        [DataRow(5.0, "Bardzo dobry")]

        [DataRow(5.5, "Brak oceny")]

        [DataTestMethod]
        public void StudentGetStudiesResultTest2(double mark, string expected)
        {
            //arrange
            var TestClass = new Student("Fifi", "Chełmikowska", "fifiqstudent@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");

            //act
            TestClass.GetStudiesResult(mark);
            var actual = TestClass.StudiesResult;

            Assert.AreEqual(expected, actual);

        }

        //testy pokrycia wszystkich instrukcji, galezi, warunkow
        
        [DataRow(2, "Niezaliczone")]

        [DataRow(2.5, "Niezaliczone")]

        [DataRow(3, "Dostateczny")]

        [DataRow(3.5, "Dostateczny plus")]

        [DataRow(4.0, "Dobry")]

        [DataRow(4.5, "Dobry plus")]

        [DataRow(5.0, "Bardzo dobry")]

        [DataRow(7.0, "Brak oceny")]

        [DataTestMethod]
        public void StudentGetStudiesResultAllInstructionsTest(double mark, string expected)
        {
            //arrange
            var TestClass = new Student("Fifi", "Chełmikowska", "fifiqstudent@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");

            //act
            TestClass.GetStudiesResult(mark);
            var actual = TestClass.StudiesResult;

            Assert.AreEqual(expected, actual);

        }

    }
}
