using Microsoft.VisualStudio.TestTools.UnitTesting;
using projekt_IO.SubSystem.Users;
using System;

namespace UniversityEmployeeTest
{
    [TestClass]
    public class UniversityEmployeeTest
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void UniversityEmployeeConstructorFirstNameNullTest()
        {
            //arrange
            var TestClass = new UniversityEmployee(null, "Paweł", "ppawel@student.agh.edu.pl", "123", "dr hab", "WZ");  

        }
        [TestMethod]
        public void UniversityEmployeeConstructorFirstNameTest()
        {
            //arrange
            var TestClass = new UniversityEmployee("Pan", "Paweł", "ppawel@student.agh.edu.pl", "123", "dr hab", "WZ");
            var expected = "Pan";

            var actual = TestClass.FirstName;

            Assert.AreEqual(expected, actual);

        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void UniversityEmployeeLastNameNullTest()
        {
            //arrange
            var TestClass = new UniversityEmployee("Paweł", null, "ppawel@student.agh.edu.pl", "123", "dr hab", "WZ");

        }

        [TestMethod]
        public void UniversityEmployeeConstructorLastNameTest()
        {
            //arrange
            var TestClass = new UniversityEmployee("Pan", "Paweł", "ppawel@student.agh.edu.pl", "123", "dr hab", "WZ");
            var expected = "Paweł";

            var actual = TestClass.LastName;

            Assert.AreEqual(expected, actual);

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void UniversityEmployeeConstructorEmailNullTest()
        {
            //arrange
            var TestClass = new UniversityEmployee("Pan", "Paweł", null, "123", "dr hab", "WZ");

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void UniversityEmployeeConstructorEmailWithoutAtTest()
        {
            //arrange
            var TestClass = new UniversityEmployee("Pan", "Paweł", "ppawel.agh.edu.pl", "123", "dr hab", "WZ");

        }


        [TestMethod]
        public void UniversityEmployeeConstructorEmailAtTest2()
        {
            //arrange
            var TestClass = new UniversityEmployee("Pan", "Paweł", "ppawel@agh.edu.pl", "123", "dr hab", "WZ");
            var expected = "ppawel@agh.edu.pl";

            var actual = TestClass.Email;

            Assert.AreEqual(expected, actual);

        }
    }
}
