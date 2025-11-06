using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace AvailableProductsInput
{
    public class MusicContrats
    {
        private String _artist;

        private String _title;
        private String _usages;
        private DateTime? _startDate;
        private DateTime? _endDate;

        public string Artist { get => _artist; set => _artist = value; }
        public string Title { get => _title; set => _title = value; }
        public string Usages { get => _usages; set => _usages = value; }
        public DateTime? StartDate { get => _startDate; set => _startDate = value; }
        public DateTime? EndDate { get => _endDate; set => _endDate = value; }
    }


}
