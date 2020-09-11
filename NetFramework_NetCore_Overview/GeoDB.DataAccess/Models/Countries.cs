using System;
using System.Collections.Generic;

namespace GeoDB.SharedLibrary.Models
{
    public partial class Countries
    {
        public Guid Id { get; set; }
        public Guid? ContinentId { get; set; }
        public string Name { get; set; }

        public virtual Continents Continent { get; set; }
    }
}
