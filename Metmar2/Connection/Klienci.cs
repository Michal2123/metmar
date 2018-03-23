namespace Metmar2.Connection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klienci")]
    public partial class Klienci
    {
        public int Id { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string Pesel { get; set; }

        public string Telefon { get; set; }

        public string Adres { get; set; }

        public bool? IsActive { get; set; }
    }
}
