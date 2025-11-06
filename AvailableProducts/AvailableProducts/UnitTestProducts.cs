

using AvailableProductsInput;

namespace AvailableProducts
{
    public class UnitTestProducts
    {       
        [Theory]
        [InlineData("Itunes", "03-01-2012")]
        [InlineData("YouTube", "12-27-2012")]
        [InlineData("YouTube", "04-01-2012")]
        public void Test1(String DeliveryPartner,String EffectiveDate)
        {

            List<MusicContrats> ListOfContratsOutTest;          

           AvailableProductsInput.AvailableProductsHandler availableProductsHandler = new AvailableProductsInput.AvailableProductsHandler();
            availableProductsHandler.loadfile();

            ListOfContratsOutTest=availableProductsHandler.getActiveContrats(DeliveryPartner, EffectiveDate);

            Assert.NotEmpty(ListOfContratsOutTest);

        }
    }

        
}