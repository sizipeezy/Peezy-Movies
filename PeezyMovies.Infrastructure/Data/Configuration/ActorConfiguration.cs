
namespace PeezyMovies.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;

    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasData(SeedActors());
        }

        private List<Actor> SeedActors()
        {
            var actors = new List<Actor>();

            actors.AddRange(new Actor[]
            {
                new Actor{ Id = 1, FullName = "Will Smith", Bio = "is an American actor and rapper.", ImageUrl = "https://parade.com/.image/ar_4:3%2Cc_fill%2Ccs_srgb%2Cq_auto:good%2Cw_1200/MTkwNTgwODMyOTMzNzE3ODg0/will-smith-net-worth.png"},
                new Actor{ Id = 2, FullName = "Arnold Schwarzenegger", Bio = "Austrian-American actor, bodybuilder and politician", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/af/Arnold_Schwarzenegger_by_Gage_Skidmore_4.jpg"},
                new Actor{ Id = 3, FullName = "Johnny Depp", Bio = "American actor and musician. He is the recipient of multiple accolades,", ImageUrl = "https://nationaltoday.com/wp-content/uploads/2022/05/107-Johnny-Depp.jpg"},
                new Actor{ Id = 4, FullName = "Brad Pitt", Bio = "American actor and film producer. He is the recipient of various accolades", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Brad_Pitt_Fury_2014.jpg/800px-Brad_Pitt_Fury_2014.jpg"},
                new Actor{ Id = 5, FullName = "Dwayne Johnson", Bio = "Dwayne Douglas Johnson, also known by his ring name The Rock", ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/dwayne-johnson-attends-the-jumanji-the-next-level-uk-film-news-photo-1575726701.jpg"},
                new Actor{ Id = 6, FullName = "Angelina Jolie", Bio = "Angelina Jolie DCMG is an American actress, filmmaker, and humanitarian", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/Angelina_Jolie_2_June_2014_%28cropped%29.jpg/800px-Angelina_Jolie_2_June_2014_%28cropped%29.jpg"},
            });


            return actors;
        }
    }
}
