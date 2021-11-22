using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_047_C.Models
{
    public partial class DataObat
    {
        public int IdObat { get; set; }
        public string NamaObat { get; set; }
        public string TanggalKadaluarsa { get; set; }
        public string Harga { get; set; }
        public string Komposisi { get; set; }
    }
}
