﻿namespace Watchlist.Models.Movies
{
    public class MoviesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
                
        public string Director { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
                
        public decimal Rating { get; set; }

        public string Genre { get; set; } = null!;
    }
}
