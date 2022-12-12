namespace PeezyMovies.Core.Exceptions
{
    using System;


    public class MoviesException : ApplicationException
    {
        public MoviesException()
        {

        }

        public MoviesException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
