using AvailableProductsInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailableProducts
{
    internal class TestMsDos
    {
        static void Main(string[] args)
        {

            
            Console.Write("Delivery Partner: ");
            string DeliveryPartner = Console.ReadLine();

            Console.Write("Effective Date:");
            string EffectiveDate = Console.ReadLine();


            AvailableProductsInput.AvailableProductsHandler availableProductsHandler = new AvailableProductsInput.AvailableProductsHandler();
            availableProductsHandler.loadfile();

            List<MusicContrats> ListOfContratsOutTest;


            ListOfContratsOutTest=availableProductsHandler.getActiveContrats(DeliveryPartner, EffectiveDate);



        }

    }
}
