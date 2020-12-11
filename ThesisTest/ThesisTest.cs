using Microsoft.VisualStudio.TestTools.UnitTesting;
using projekt_IO.SubSystem;
using projekt_IO.SubSystem.Documents;
using projekt_IO.SubSystem.Users;

namespace ThesisTest
{
    [TestClass]
    public class ThesisTest
    {
        [TestMethod]
        public void AttachTest()
        {
            var StudentTestClass = new Student("Janina", "Bobrowska", "jb@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var NotifierTestClass = new Notifier(StudentTestClass);

            var ThesisTestClass = new Thesis("Thesis", StudentTestClass);
            ThesisTestClass.Attach(NotifierTestClass);

            var expected = true;
            var actual = ThesisTestClass._observerList.Contains(NotifierTestClass);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void DetachTest()
        {
            var StudentTestClass = new Student("Janina", "Bobrowska", "jb@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var NotifierTestClass = new Notifier(StudentTestClass);

            var ThesisTestClass = new Thesis("Thesis", StudentTestClass);
            ThesisTestClass.Attach(NotifierTestClass);

            var expected = true;
            var actual = ThesisTestClass._observerList.Contains(NotifierTestClass);

            Assert.AreEqual(expected, actual);

            ThesisTestClass.Detach(NotifierTestClass);
            actual = !ThesisTestClass._observerList.Contains(NotifierTestClass);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void UploadTest()
        {
            var StudentTestClass = new Student("Janina", "Bobrowska", "jb@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var ThesisTestClass = new Thesis("Thesis", StudentTestClass);

            ThesisTestClass.Upload(StudentTestClass);

            var expected = ThesisStatus.UploadedByStudent;
            var actual = ThesisTestClass.Status;
            Assert.AreEqual(actual, expected);
        }

        //upload dokonywany przez innego studenta, niz do tego co jest przypisana praca nie zmieni statusu
        [TestMethod]
        public void UploadTest2()
        {
            var StudentTestClass = new Student("Janina", "Bobrowska", "jb@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var StudentTestClass2 = new Student("Fifi", "Chełmikowska", "fifi@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var ThesisTestClass = new Thesis("Thesis", StudentTestClass);

            ThesisTestClass.Upload(StudentTestClass2);

            var expected = ThesisStatus.NotUploaded;
            var actual = ThesisTestClass.Status;
            Assert.AreEqual(actual, expected);
        }

        
        [TestMethod]
        public void ModifyTest()
        {
            var StudentTestClass = new Student("Janina", "Bobrowska", "jb@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var ThesisTestClass = new Thesis("Thesis", StudentTestClass);

            ThesisTestClass.Modify(StudentTestClass);

            var expected = ThesisStatus.ModifiedByStudent;
            var actual = ThesisTestClass.Status;
            Assert.AreEqual(actual, expected);
        }


        [TestMethod]
        public void ToImproveTest()
        {
            var StudentTestClass = new Student("Janina", "Bobrowska", "jb@agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            var ThesisTestClass = new Thesis("Thesis", StudentTestClass);

            ThesisTestClass.ToImprove();

            var expected = ThesisStatus.ToImprove;
            var actual = ThesisTestClass.Status;
            Assert.AreEqual(actual, expected);
        }

    }
}
