﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data.Configuration
{
    internal class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            ICollection<Board> boards = GenerateBoards();

            builder.HasData(boards);
        }

        private ICollection<Board> GenerateBoards()
            => new HashSet<Board>()
                {
                    new Board()
                    {
                        Id = 1,
                        Name = "Open"
                    },
                    new Board()
                    {
                        Id = 2,
                        Name = "In Progress"
                    },
                    new Board()
                    {
                        Id = 3,
                        Name = "Done"
                    }
                };

    }
}
