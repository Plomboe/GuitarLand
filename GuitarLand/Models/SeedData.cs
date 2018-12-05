using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarLand.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Epiphone Les Paul Custom Pro", Description = "Solid body guitar with a Cherry Sunburst finish", Price = 899.00, GuitarType = "Electric, 6-String", BodyMaterial = "Mahogany", Pickups = "Probucker Humbuckers" },
                    new Product { Name = "Fender Telecaster", Description = "American Professional guitar with Maple fingerboard", Price = 1949.99, GuitarType = "Electric, 6-String", BodyMaterial = "Ash", Pickups = "V-Mod" },
                    new Product { Name = "Gibson Les Paul Standard", Description = "Solid body guitar with a Cobalt Burst finish", Price = 3649.00, GuitarType = "Electric, 6-String", BodyMaterial = "Mahogany", Pickups = "BurstBucker Humbuckers" },
                    new Product { Name = "D-28 Dreadnought", Description = "Acoustic guitar with massive bass response and articulate highs", Price = 2589.00, GuitarType = "Acoustic, 6-String", BodyMaterial = "East Indian Rosewood", Pickups = "" },
                    new Product { Name = "Denver Steel Acoustic", Description = "Acoustic guitar that delivers great tone and playability", Price = 199.99, GuitarType = "Acoustic, 12-String", BodyMaterial = "Mahogany", Pickups = "" },
                    new Product { Name = "Rickenbacker Unbound 4003 Series", Description = "Delivers solid bass tones with ringing sustain", Price = 2149.99, GuitarType = "Bass, 4-String", BodyMaterial = "Maple", Pickups = "Single Coil" },
                    new Product { Name = "Gretsch Junior Jet II", Description = "Quality entry-level bass that delivers good bass tones", Price = 399.99, GuitarType = "Bass, 4-String", BodyMaterial = "Basswood", Pickups = "Gretsch Mini Humbucking" }
                );
                context.SaveChanges();
            }
        }
    }
}
