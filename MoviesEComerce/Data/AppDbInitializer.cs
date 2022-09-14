/*using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data.Enums;
using MoviesEComerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesEComerce.Data
{
    public class AppDbInitializer
    {
        internal static void Initialize(MovieComerceContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            if (dbContext.Cinema.Any())
            {
                var Cinemas = new List<Cinema>()
                    {
                        new Cinema()
                        {
                            FullName = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            FullName = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            FullName = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            FullName = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            FullName = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    };
                dbContext.Cinema.AddRange(Cinemas);
                dbContext.SaveChanges();
            }

            if (dbContext.Actor.Any())
            {
                var Actors = new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    };
                dbContext.Actor.AddRange(Actors);
                dbContext.SaveChanges();
            }

            if (dbContext.Producer.Any())
            {
                var Producers = new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            PictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            PictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            PictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            PictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            PictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    };
                dbContext.Producer.AddRange(Producers);
                dbContext.SaveChanges();
            }

            if (dbContext.Movie.Any())
            {
                var Movies = new List<Movie>()
                    {
                        new Movie()
                        {
                            MovieName = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            MovieName = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            MovieName = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            MovieName = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            MovieName = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            MovieName = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    };
                dbContext.Movie.AddRange(Movies);
                dbContext.SaveChanges();
            }

            if (dbContext.MovieActor.Any())
            {
                var MovieActors = new List<MovieActor>()
                    {
                        new MovieActor()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new MovieActor()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new MovieActor()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new MovieActor()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new MovieActor()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new MovieActor()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new MovieActor()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new MovieActor()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new MovieActor()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new MovieActor()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new MovieActor()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new MovieActor()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new MovieActor()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new MovieActor()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new MovieActor()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new MovieActor()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new MovieActor()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    };
                dbContext.MovieActor.AddRange(MovieActors);
                dbContext.SaveChanges();
            }

            /*foreach (var user in users)
                dbContext.Users.Add(user);
             dbContext.SaveChanges();
             

        }
    }
}
*/