using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using projekt_IO.SubSystem;
using projekt_IO.SubSystem.Documents;

namespace OpinionTest
{
    [TestClass]
    public class OpinionTest
    {
        //moq tests
        //przy uruchomieniu tych testow nalezy zmienic kod w klasie Opinion w metodzie IsOpinionCorrect()

        //test czy dziala funkcja IsOpinionCorrect
        [TestMethod]
        public void IsOpinionCorrectDummyMoq()
        {
            var mock = new Mock<IValidator>();

            var TestClass = new Opinion(mock.Object);

            bool actual = TestClass.IsOpinionCorrect("123", 0);

            Assert.AreEqual(false, actual);

        }

        //test czy funkcja jest wywolywana
        [TestMethod]
        public void IsOpinionCorrectMockMoq()
        {
            var mock = new Mock<IValidator>();

            var TestClass = new Opinion(mock.Object);

            bool actual = TestClass.IsOpinionCorrect("123", 2.5);

            mock.Verify(x => x.IsCorrectMark(2.5), Times.Once);
            mock.Verify(x => x.IsCorrectMark(It.IsAny<double>()), Times.Once);

        }

        //test co zwroci funkcja, jesli IsCorrectMark zwraca true
        [TestMethod]
        public void IsOpinionCorrectStubMoq()
        {
            var mock = new Mock<IValidator>();
            mock.Setup(x => x.IsCorrectMark(It.IsAny<double>())).Returns(true);

            var TestClass = new Opinion(mock.Object);

            bool actual = TestClass.IsOpinionCorrect("123", 2.5);

            Assert.AreEqual(true, actual);

        }

        //test co zwroci funkcja, jesli IsCorrectMark zwraca false
        [TestMethod]
        public void IsOpinionCorrectStubMoq2()
        {
            var mock = new Mock<IValidator>();
            mock.Setup(x => x.IsCorrectMark(It.IsAny<double>())).Returns(false);

            var TestClass = new Opinion(mock.Object);

            bool actual = TestClass.IsOpinionCorrect("123", 2.5);

            Assert.AreEqual(false, actual);

        }

        //test co zwroci funkcja, jesli IsCorrectMark zwraca true, ale zostal przekazany parametr null
        [TestMethod]
        public void IsOpinionCorrectStubMoq3()
        {
            var mock = new Mock<IValidator>();
            mock.Setup(x => x.IsCorrectMark(It.IsAny<double>())).Returns(true);

            var TestClass = new Opinion(mock.Object);

            bool actual = TestClass.IsOpinionCorrect(null, 2.5);

            Assert.AreEqual(false, actual);

        }
    }
}
