using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AvailableProductsInput
{
    public class AvailableProductsHandler
    {

        List<MusicContrats> ListOfContrats = new List<MusicContrats>();
        List<MusicContrats> ListOfContratsOut = new List<MusicContrats>();

        public List<MusicContrats> loadfile()
        {
            DateTime mydate;

            string[] headers = new string[5];
            string filePath = "C:/UmusicTestSolution/Products.txt"; // Reemplaza con la ruta real
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Lee el archivo línea por línea
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        MusicContrats c=new MusicContrats();
                        headers = line.Split("|");
                        if (headers.Length > 0)
                        {
                            c.Artist = headers[0].Trim();
                            c.Title = headers[1].Trim();
                            c.Usages=headers[2].Trim();



                            if (!string.IsNullOrEmpty(headers[3].Trim()))
                            {
                                if (DateTime.TryParseExact(headers[3].Trim(), "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None,
                                   out mydate))
                                    c.StartDate = mydate;
                                else
                                    c.StartDate = null;
                            }
                            else
                                c.StartDate = null;

                            if (!string.IsNullOrEmpty(headers[4].Trim()))
                            {
                                if (DateTime.TryParseExact(headers[4].Trim(), "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None,
                                   out mydate))
                                    c.EndDate = mydate;
                                else
                                    c.EndDate = null;
                            }
                            else
                                c.EndDate = null;

                        }
                        ListOfContrats.Add(c
                            );
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al leer el archivo: {e.Message}");
            }

            return ListOfContrats;
        }
        
        public List<MusicContrats> getActiveContrats(String strPartner,String validDate) {
            String strUsos = "";
            DateTime DateInRange;
            if (DateTime.TryParseExact(validDate, "MM-dd-yyyy",
                               System.Globalization.CultureInfo.InvariantCulture,
                               System.Globalization.DateTimeStyles.None,
                               out DateInRange))
            {
                //Console.WriteLine($"Conversión exitosa: {fecha}");
            }
            else
            {
                //Console.WriteLine("Error: La cadena no coincide con el formato esperado.");
            }

            if (String.Equals(strPartner,"Itunes", StringComparison.OrdinalIgnoreCase))
                strUsos = "digital";
            if (String.Equals(strPartner, "YouTube", StringComparison.OrdinalIgnoreCase))
                strUsos = "streaming";

            ListOfContratsOut.Clear();
            Boolean flaginclude = false;
            Console.WriteLine("Artist          | Title                  | Usages           | StartDate         |EndDate");
            foreach (MusicContrats item in ListOfContrats)
            {
                if (item.Usages.Contains(strUsos)) {
                    if (item.EndDate is not null)
                    {
                        if (item.StartDate <= DateInRange && DateInRange <= item.EndDate)
                            flaginclude = true;
                        else
                            flaginclude = false;
                    } else
                    {
                        if (item.StartDate <= DateInRange)
                            flaginclude = true;
                        else
                            flaginclude = false;
                    }

                    if (flaginclude)
                    {
                        ListOfContratsOut.Add(item);
                        
                        Console.WriteLine($"{item.Artist} | {item.Title} | {item.Usages} | {item.StartDate} | {item.EndDate}");
                    }
                }  
                //Console.WriteLine(item);
            }
            return ListOfContratsOut;
        }




    }
}
