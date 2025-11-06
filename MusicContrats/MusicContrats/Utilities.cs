using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicContrats
{
    public static class Utilities
    {
        static List<MusicContract> LoadMusicContracts(string filePath)
        {
            var list = new List<MusicContract>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1)) // saltar encabezado si existe
            {
                var parts = line.Split('|');
                if (parts.Length < 5) continue;

                list.Add(new MusicContract
                {
                    Artist = parts[0].Trim(),
                    Title = parts[1].Trim(),
                    Usage = parts[2].Trim(),
                    StartDate = DateTime.ParseExact(parts[3].Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture),
                    EndDate = string.IsNullOrWhiteSpace(parts[4]) ? (DateTime?)null :
                              DateTime.ParseExact(parts[4].Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture)
                });
            }

            return list;
        }

        static List<Partner> LoadPartners(string filePath)
        {
            var list = new List<Partner>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1)) // saltar encabezado si existe
            {
                var parts = line.Split('|');
                if (parts.Length < 2) continue;

                list.Add(new Partner
                {
                    PartnerName = parts[0].Trim(),
                    Usage = parts[1].Trim()
                });
            }

            return list;
        }

        public static void HandlerProccessQuery(String inputPartner, String validDate) {
         
            string musicContractsFile = "../../../../MusicContracts.txt";
            string partnersFile = "../../../../Partners.txt";

 
            DateTime inputDate;
            //String validDate = "04-01-2012";
            Boolean dateValid = DateTime.TryParseExact(validDate, "MM-dd-yyyy",
                                   System.Globalization.CultureInfo.InvariantCulture,
                                   System.Globalization.DateTimeStyles.None,
                                   out inputDate);

            //string inputPartner = "YouTube";

            // Cargar listas
            var musicContracts = LoadMusicContracts(musicContractsFile);
            var partners = LoadPartners(partnersFile);

            // LINQ: Unión por Usage + filtros
            var query = from m in musicContracts
                        from p in partners
                        where p.PartnerName.Equals(inputPartner, StringComparison.OrdinalIgnoreCase)
                              && m.Usage.IndexOf(p.Usage, StringComparison.OrdinalIgnoreCase) >= 0
                              && (
                                  (m.EndDate != null && inputDate >= m.StartDate && inputDate <= m.EndDate.Value)
                                  || (m.EndDate == null && inputDate >= m.StartDate)
                                 )
                        select new
                        {
                            Artist = m.Artist,
                            Title = m.Title,
                            Usage = m.Usage,
                            Partner = p.PartnerName,
                            StartDate = m.StartDate.ToString("yyyy-MM-dd"),
                            EndDate = m.EndDate?.ToString("yyyy-MM-dd") ?? "N/A"
                        };

            Console.WriteLine($"Resultados para el Partner: {inputPartner}, Fecha: {inputDate:yyyy-MM-dd}");
            Console.WriteLine("---------------------------------------------------------");

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Artist} | {item.Title} | {item.Usage} | {item.Partner} | {item.StartDate} - {item.EndDate}");
            }
        }
    }

    
}

