using System.ComponentModel.DataAnnotations;

namespace PeezyMovies
{
    public static class GlobalConstants
    {
        public static class Movie
        {
            public const int TitleMaxLength = 40;
            public const int DirectorMaxLength = 40;

            public const double PriceMinLength = 20.0;
            public const double PriceMaxLength = 200.0;

            public const int DescriptionMaxLength = 500;

        }

        public static class Actor
        {
            public const int FullNameMaxLength = 50;
            public const int BioMaxLength = 100;
        }

        public static class Category
        {
            public const int NameMaxLength = 50;
        }

        public static class Cinema
        {
            public const int NameMaxLength = 25;
            public const int DescriptionMaxLength = 100;
        }

        public static class Conntact
        {
            public const int NameMaxLength = 60;
            public const int NameMinLength = 3;

            public const int SubjectMaxLength = 200;

            public const int MessageMaxLength = 500;

        }
        public static class Genre
        {
            public const int GenreMaxLength = 50;
        }

        public static class Producer
        {
            public const int ProducerMaxLength = 50;    
        }
    }
    
}
