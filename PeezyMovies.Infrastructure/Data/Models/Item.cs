namespace PeezyMovies.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Item
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Movie Movie { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
