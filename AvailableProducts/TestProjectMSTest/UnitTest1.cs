using AvailableProductsInput;

namespace TestProjectMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodItunes1()
        {
            List<MusicContrats> ListOfContratsOutTest;

            AvailableProductsInput.AvailableProductsHandler availableProductsHandler = new AvailableProductsInput.AvailableProductsHandler();
            availableProductsHandler.loadfile();

            ListOfContratsOutTest = availableProductsHandler.getActiveContrats("Itunes", "03-01-2012");

            Assert.IsNotNull(ListOfContratsOutTest);
        }

        [TestMethod]
        public void TestMethodYouTube()
        {
            List<MusicContrats> ListOfContratsOutTest;

            AvailableProductsInput.AvailableProductsHandler availableProductsHandler = new AvailableProductsInput.AvailableProductsHandler();
            availableProductsHandler.loadfile();

            ListOfContratsOutTest = availableProductsHandler.getActiveContrats("YouTube", "12-27-2012");

            Assert.IsNotNull(ListOfContratsOutTest);
        }

        [TestMethod]
        public void TestMethodYouTube2()
        {
            List<MusicContrats> ListOfContratsOutTest;

            AvailableProductsInput.AvailableProductsHandler availableProductsHandler = new AvailableProductsInput.AvailableProductsHandler();
            availableProductsHandler.loadfile();

            ListOfContratsOutTest = availableProductsHandler.getActiveContrats("YouTube", "04-01-2012");

            Assert.IsNotNull(ListOfContratsOutTest);
        }

    }
}