namespace SampleApp.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Continent
    {
        public Continent()
        {
            Countries = new HashSet<Country>();
        }


        // Achtung Nameskonvetion
        public Guid Id { get; set; } //CodeFirst -> Neue Tabelle -> muss die Property Id beinhalten (feste Regel) 

        [StringLength(50)] // DataAnnotation
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
