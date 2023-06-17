﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Entities
{
    public class UserMovie
    {        
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set;} = null!;
    }
}
