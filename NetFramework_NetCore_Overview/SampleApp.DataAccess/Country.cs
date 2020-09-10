namespace SampleApp.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        public Guid Id { get; set; }

        public Guid? ContinentId { get; set; } //Foreign Key ben�tigt ContinentId (Tabellenspalte) 

        [StringLength(60)]
        public string Name { get; set; }

        public virtual Continent Continent { get; set; } // Foreign Key in EF wird zus�tzlich ein Object des 'Parent' Angegeben 
    }
}
