using GeoDB.SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoDBWebAPI.Data
{
    public static class DataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (GeoDBContext ctx = new GeoDBContext(serviceProvider.GetRequiredService<DbContextOptions<GeoDBContext>>()))
            {
                if (ctx.Continents.Any())
                    return;

                ctx.Continents.AddRange(
                    new Continents
                    {
                        Id = Guid.NewGuid(),
                        Name = "Asien",
                    },
                    new Continents
                    {
                        Id = Guid.NewGuid(),
                        Name = "Afrika",
                    }
                );

                ctx.SaveChanges();
            }
        }
    }
}
