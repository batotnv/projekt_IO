﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using projekt_IO.SubSystem.Documents;
using projekt_IO.SubSystem.Users;
using projekt_IO.SubSystem;
using System;

namespace ReviewTest
{
    [TestClass]
    public class ReviewTest
    {

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ReviewConstructorNullTest()
        {
            //arrange

            var StudentTestClass = new Student("Janina", "Bobrowska", "jb@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var SupervisorTestClass = new UniversityEmployee("Pan", "Paweł", "ppawel@agh.edu.pl", "123", "dr hab", "WZ");
            var ThesisTestClass = new Thesis("Analiza krajow UE", StudentTestClass);
            
            var TestClass = new Review(null, SupervisorTestClass, ThesisTestClass, 5);

        }

        //moq tests
        //przy uruchomieniu tych testow nalezy zmienic kod w klasie review w metodzie IsReviewCorrect()

        //test czy dziala funkcja IsReviewCorrect
        [TestMethod]
        public void IsReviewCorrectDummyMoq()
        {
            var mock = new Mock<IValidator>();

            var TestClass = new Review(mock.Object);

            bool actual = TestClass.IsReviewCorrect("123", 0);

            Assert.AreEqual(false, actual);

        }

        //test czy funkcja jest wywolywana
        [TestMethod]
        public void IsReviewCorrectMockMoq()
        {
            var mock = new Mock<IValidator>();

            var TestClass = new Review(mock.Object);

            bool actual = TestClass.IsReviewCorrect("123", 2.5);

            mock.Verify(x => x.IsCorrectMark(2.5), Times.Once);
            mock.Verify(x => x.IsCorrectMark(It.IsAny<double>()), Times.Once);

        }

        //test co zwroci funkcja, jesli IsCorrectMark zwraca true
        [TestMethod]
        public void IsReviewCorrectStubMoq()
        {
            var mock = new Mock<IValidator>();
            mock.Setup(x => x.IsCorrectMark(It.IsAny<double>())).Returns(true);

            var TestClass = new Review(mock.Object);

            bool actual = TestClass.IsReviewCorrect("123", 2.5);

            Assert.AreEqual(true, actual);

        }

        //test co zwroci funkcja, jesli IsCorrectMark zwraca false
        [TestMethod]
        public void IsReviewCorrectStubMoq2()
        {
            var mock = new Mock<IValidator>();
            mock.Setup(x => x.IsCorrectMark(It.IsAny<double>())).Returns(false);

            var TestClass = new Review(mock.Object);

            bool actual = TestClass.IsReviewCorrect("123", 2.5);

            Assert.AreEqual(false, actual);

        }

        //test co zwroci funkcja, jesli IsCorrectMark zwraca true, ale zostal przekazany parametr null
        [TestMethod]
        public void IsReviewCorrectStubMoq3()
        {
            var mock = new Mock<IValidator>();
            mock.Setup(x => x.IsCorrectMark(It.IsAny<double>())).Returns(true);

            var TestClass = new Review(mock.Object);

            bool actual = TestClass.IsReviewCorrect(null, 2.5);

            Assert.AreEqual(false, actual);

        }

        
        [TestMethod]
        public void IsReviewCorrectTimesNeverMoq()
        {
            var mock = new Mock<IValidator>();

            var TestClass = new Review(mock.Object);

            //bool actual = TestClass.IsReviewCorrect("123", 2.5);

            mock.Verify(x => x.IsCorrectMark(2.5), Times.Never);
            mock.Verify(x => x.IsCorrectMark(It.IsAny<double>()), Times.Never);

        }
    }
}
