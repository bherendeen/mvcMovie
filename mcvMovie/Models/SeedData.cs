using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Joseph Smith: The Prophet of the Restoration",
                    ReleaseDate = DateTime.Parse("2005-12-17"),
                    Genre = "Historical",
                    Price = 0.00M,
                    Rating = "PG",
                    Image = "https://image.tmdb.org/t/p/w500/c1HZoNSDxICuRIvq1TnUkol4D2F.jpg"
                },
                new Movie
                {
                    Title = "Finding Faith in Christ",
                    ReleaseDate = DateTime.Parse("2003-01-01"),
                    Genre = "Short",
                    Price = 0.00M,
                    Rating = "PG",
                    Image = "https://www.mormoninfo.org/sitedata/mormoninfo-org/EditorItem_11883_5_3815.jpg"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Price = 0.00M,
                    Rating = "PG",
                    Image = "http://images.moviepostershop.com/meet-the-mormons-movie-poster-2014-1020770793.jpg"
                },
                new Movie
                {
                    Title = "Only a Stonecutter",
                    ReleaseDate = DateTime.Parse("2008-12-16"),
                    Genre = "Short",
                    Price = 0.00M,
                    Rating = "PG",
                    Image = "https://d2jc79253juilm.cloudfront.net/product-images/000/305/051/detail/Stonecutter.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}