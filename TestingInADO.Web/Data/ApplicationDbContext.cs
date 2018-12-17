using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestingInADO.Models;

namespace TestingInADO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MovieModel> Movies { get; set; }

        public DbSet<RatingComponent> Ratings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if (DEBUG)
            optionsBuilder.EnableSensitiveDataLogging();
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var movies = modelBuilder.Entity<MovieModel>();
            movies.Property(e => e.Title)
                .IsRequired().HasMaxLength(100);
            //movies.OwnsMany(e => e.Ratings, o =>
            //{
            //    o.HasKey(e => e.Id);
            //    o.ToTable(nameof(MovieModel.Ratings));
            //});
            movies.HasIndex(e => e.Title);
            movies.HasIndex(e => e.Year);

            var ratings = modelBuilder.Entity<RatingComponent>();

            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected virtual void Seed(ModelBuilder modelBuilder)
        {
            Random rnd = new Random(0);

            List<MovieModel> movies = new List<MovieModel> {
                new MovieModel { Id = 1, Year = 2015, Title = "Minions" },
                new MovieModel { Id = 2, Year = 2014, Title = "Big Hero 6" },
                new MovieModel { Id = 3, Year = 2014, Title = "Rio 2 - Missione Amazzonia" },
                new MovieModel { Id = 4, Year = 2013, Title = "Frozen - Il Regno di Ghiaccio" },
                new MovieModel { Id = 5, Year = 2013, Title = "Monsters University" },
                new MovieModel { Id = 6, Year = 2013, Title = "Cattivissimo Me 2" },
                new MovieModel { Id = 7, Year = 2013, Title = "I Croodz" },
                new MovieModel { Id = 8, Year = 2013, Title = "Epic - Il mondo segreto" },
                new MovieModel { Id = 9, Year = 2013, Title = "Planes" },
                new MovieModel { Id = 10, Year = 2013, Title = "Si alza il vento" },
                new MovieModel { Id = 11, Year = 2012, Title = "Ribelle - The Brave" },
                new MovieModel { Id = 12, Year = 2012, Title = "Le 5 leggende" },
                new MovieModel { Id = 13, Year = 2012, Title = "L'era glaciale 4 - Continenti alla deriva" },
                new MovieModel { Id = 14, Year = 2012, Title = "Madagascar 3: Ricercati in Europa" },
                new MovieModel { Id = 15, Year = 2011, Title = "Cars 2" },
                new MovieModel { Id = 16, Year = 2011, Title = "Kung Fu Panda 2" },
                new MovieModel { Id = 17, Year = 2011, Title = "Il gatto con gli stivali" },
                new MovieModel { Id = 18, Year = 2011, Title = "Rio" },
                new MovieModel { Id = 19, Year = 2010, Title = "Cattivissimo Me" },
                new MovieModel { Id = 20, Year = 2010, Title = "Toy Story 3 - La grande fuga" },
                new MovieModel { Id = 21, Year = 2010, Title = "Rapunzel - L'Intreccio della Torre" },
                new MovieModel { Id = 22, Year = 2010, Title = "Shrek e vissero felici e contenti" },
                new MovieModel { Id = 23, Year = 2010, Title = "Le avventure di Sammy" },
                new MovieModel { Id = 24, Year = 2010, Title = "Arrietty" },
                new MovieModel { Id = 25, Year = 2009, Title = "L'era glaciale 3 - L'alba dei dinosauri" },
                new MovieModel { Id = 26, Year = 2009, Title = "La Principessa e il Ranocchio" },
                new MovieModel { Id = 27, Year = 2009, Title = "Piovono gnocchi" },
                new MovieModel { Id = 28, Year = 2008, Title = "Kung Fu Panda" },
                new MovieModel { Id = 29, Year = 2008, Title = "Madagascar 2" },
                new MovieModel { Id = 30, Year = 2008, Title = "Ponyo sulla scogliera" },
                new MovieModel { Id = 31, Year = 2007, Title = "Ratatouille" },
                new MovieModel { Id = 32, Year = 2007, Title = "Shrek terzo" },
                new MovieModel { Id = 33, Year = 2015, Title = "Il viaggio di Arlo" },
                new MovieModel { Id = 34, Year = 2016, Title = "Zootropolis" },
                new MovieModel { Id = 35, Year = 2016, Title = "Oceania" },
                new MovieModel { Id = 36, Year = 2016, Title = "Your Name" },
                new MovieModel { Id = 37, Year = 2016, Title = "Ballerina" },
                new MovieModel { Id = 38, Year = 2017, Title = "Coco" },
                new MovieModel { Id = 39, Year = 2017, Title = "Cars 3" },
                new MovieModel { Id = 40, Year = 2017, Title = "Cattivissimo Me 3" },
                new MovieModel { Id = 41, Year = 2018, Title = "Sherlock Gnomes" },
                new MovieModel { Id = 42, Year = 2018, Title = "Il Grinch" },
                new MovieModel { Id = 43, Year = 2018, Title = "I Primitivi" }
            };
            modelBuilder.Entity<MovieModel>().HasData(
                movies.ToArray()
            );

            int count = 0;
            List<RatingComponent> ratings = new List<RatingComponent>();
            foreach (MovieModel movie in movies)
            {
                int max = count + rnd.Next(3, 5);
                while (count < max)
                {
                    count++;
                    ratings.Add(
                        new RatingComponent { Id = count, MovieId = movie.Id, Value = rnd.Next(1, 6) }
                    );
                }
            }
            modelBuilder.Entity<RatingComponent>().HasData(
                ratings.ToArray()
            );
        }
    }
}
