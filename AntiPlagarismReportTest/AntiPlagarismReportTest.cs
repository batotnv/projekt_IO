using Microsoft.VisualStudio.TestTools.UnitTesting;
using projekt_IO.SubSystem.Documents;

namespace AntiPlagarismReportTest
{
    [TestClass]
    public class AntiPlagarismReportTest
    {

        //testowanie w poblizu granic
        [DataRow(-1, false)]

        [DataRow(0, true)]

        [DataRow(1, true)]

        [DataRow(99, true)]

        [DataRow(100, true)]

        [DataRow(101, false)]

        [DataTestMethod]

        public void IsResultCorrectTest(int result, bool expected)
        {

            AntiPlagarismReport report = new AntiPlagarismReport("negatywny", 5);
            bool actual = report.IsResultCorrect(result);
            Assert.AreEqual(actual, expected);
        }
    }
}
