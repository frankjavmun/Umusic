internal class Program
{
    static void Main(string[] args)
    {
       AvailableProductsInput.AvailableProductsHandler availableProductsHandler = new AvailableProductsInput.AvailableProductsHandler();
       availableProductsHandler.loadfile();

        availableProductsHandler.getActiveContrats("digital","06-01-2012");

    }

}