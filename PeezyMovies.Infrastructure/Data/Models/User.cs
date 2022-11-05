namespace PeezyMovies.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;


    public class User : IdentityUser
    {
        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
