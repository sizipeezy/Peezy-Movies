namespace PeezyMovies.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;

    public class ProducersConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasData(SeedProducers());
        }

        private List<Producer> SeedProducers()
        {
            var producers = new List<Producer>();

            producers.AddRange(new Producer[]
            {
                new Producer()
                {

                    Id = 1,
                    FullName = "Producer 1",
                    ImageUrl = "http://dotnethow.net/images/producers/producer-1.jpeg",


                },
                 new Producer()
                 {
                     Id = 2,
                     FullName = "Producer 2",
                     ImageUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                 },
                 new Producer()
                 {
                     Id = 3,
                     FullName = "Producer 3",
                     ImageUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                 },
                 new Producer()
                 {
                     Id = 4,
                     FullName = "Producer 4",
                     ImageUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                 },
               new Producer()
               {
                   Id = 5,
                   FullName = "Producer 5",
                   ImageUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"

               }
            });

            return producers;
        }

    }
}
