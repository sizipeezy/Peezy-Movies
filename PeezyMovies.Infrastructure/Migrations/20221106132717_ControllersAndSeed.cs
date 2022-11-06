using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeezyMovies.Infrastructure.Migrations
{
    public partial class ControllersAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "FullName", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "is an American actor and rapper.", "Will Smith", "https://parade.com/.image/ar_4:3%2Cc_fill%2Ccs_srgb%2Cq_auto:good%2Cw_1200/MTkwNTgwODMyOTMzNzE3ODg0/will-smith-net-worth.png" },
                    { 2, "Austrian-American actor, bodybuilder and politician", "Arnold Schwarzenegger", "https://upload.wikimedia.org/wikipedia/commons/a/af/Arnold_Schwarzenegger_by_Gage_Skidmore_4.jpg" },
                    { 3, "American actor and musician. He is the recipient of multiple accolades,", "Johnny Depp", "https://nationaltoday.com/wp-content/uploads/2022/05/107-Johnny-Depp.jpg" },
                    { 4, "American actor and film producer. He is the recipient of various accolades", "Brad Pitt", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Brad_Pitt_Fury_2014.jpg/800px-Brad_Pitt_Fury_2014.jpg" },
                    { 5, "Dwayne Douglas Johnson, also known by his ring name The Rock", "Dwayne Johnson", "https://hips.hearstapps.com/hmg-prod/images/dwayne-johnson-attends-the-jumanji-the-next-level-uk-film-news-photo-1575726701.jpg" },
                    { 6, "Angelina Jolie DCMG is an American actress, filmmaker, and humanitarian", "Angelina Jolie", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/Angelina_Jolie_2_June_2014_%28cropped%29.jpg/800px-Angelina_Jolie_2_June_2014_%28cropped%29.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Description", "Logo", "Name" },
                values: new object[,]
                {
                    { 1, "Mall of Sofia", "http://dotnethow.net/images/cinemas/cinema-2.jpeg", "Cinema City" },
                    { 2, "Movie Theatre located in Sofia", "https://s.inyourpocket.com/gallery/274666.jpg", "CineGrand" },
                    { 3, "Description of Movie 4", "http://dotnethow.net/images/cinemas/cinema-4.jpeg", "Kino Odeaon" },
                    { 4, "Cinema 4 Description", "http://dotnethow.net/images/cinemas/cinema-3.jpeg", "Imaxx Cinema" },
                    { 5, "Cinmea 5 Descirpiton", "http://dotnethow.net/images/cinemas/cinema-5.jpeg", "Cinema 5" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Action" },
                    { 3, "Drama" },
                    { 4, "Fantasy" },
                    { 5, "Thriller" },
                    { 6, "Mystery" },
                    { 7, "Romantic" }
                });

            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "Id", "FullName", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "Producer 1", "http://dotnethow.net/images/producers/producer-1.jpeg" },
                    { 2, "Producer 2", "http://dotnethow.net/images/producers/producer-2.jpeg" },
                    { 3, "Producer 3", "http://dotnethow.net/images/producers/producer-3.jpeg" },
                    { 4, "Producer 4", "http://dotnethow.net/images/producers/producer-4.jpeg" },
                    { 5, "Producer 5", "http://dotnethow.net/images/producers/producer-5.jpeg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
