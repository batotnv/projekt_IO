using Microsoft.VisualStudio.TestTools.UnitTesting;
using projekt_IO.SubSystem;

namespace MarkValidatorTest
{
    [TestClass]
    public class MarkValidatorTest
    {

        //testowanie w poblizu granic
        [DataRow(1.5, false)]

        [DataRow(2, true)]

        [DataRow(2.5, true)]

        [DataRow(4.5, true)]

        [DataRow(5.0, true)]

        [DataRow(5.5, false)]

        [DataTestMethod]

        public void IsCorrectMarkTest(double mark, bool expected)
        {

            IValidator validator = new MarkValidator();
            bool actual = validator.IsCorrectMark(mark);

            Assert.AreEqual(actual, expected);
        }

        //klasy rownowaznosci

        // k1 : 1.5, 2, 2.5, 3.5, 4, 4.5, 5
        // k2: liczby wszystkie inne niz powyzsze
       
        [DataRow(1.5, false)]

        [DataRow(2, true)]

        [DataRow(3, true)]

        [DataRow(15, false)]

        [DataRow(70, false)]


        [DataTestMethod]

        public void IsCorrectMarkTest2(double mark, bool expected)
        {

            IValidator validator = new MarkValidator();
            bool actual = validator.IsCorrectMark(mark);

            Assert.AreEqual(actual, expected);
        }
    }
}
