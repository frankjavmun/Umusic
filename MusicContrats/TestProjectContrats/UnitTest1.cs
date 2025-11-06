using MusicContrats;

namespace TestProjectContrats
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodItunes1()
        {
            Utilities.HandlerProccessQuery("Itunes", "03-01-2012");
        }

        [TestMethod]
        public void TestMethodYouTube()
        {
            Utilities.HandlerProccessQuery("YouTube", "12-27-2012");
        }

        [TestMethod]
        public void TestMethodYouTube2()
        {
            Utilities.HandlerProccessQuery("YouTube", "04-01-2012");
        }

    }
}