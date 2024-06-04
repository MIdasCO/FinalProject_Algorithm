using System;
using System.Collections.Generic;
 
namespace MovieManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var movieManager = new MovieManager();
 
            movieManager.AddMovie("Inception", "Sci-Fi", 2010, "Christopher Nolan", 8.8);
            movieManager.AddMovie("Interstellar", "Sci-Fi", 2014, "Christopher Nolan", 8.6);
            movieManager.AddMovie("The Dark Knight", "Action", 2008, "Christopher Nolan", 9.0);
            movieManager.AddMovie("Avatar", "Fantasy", 2009, "James Cameron", 7.8);
            movieManager.AddMovie("Poop", "Fantasy", 2006, "Abdel Rysbekov", 7.8);
 
            Console.WriteLine("All Movies:");
            movieManager.PrintAllMovies();
 
            Console.WriteLine("\nMovies by Genre 'Sci-Fi':");
            movieManager.ListMoviesByGenre("Sci-Fi");
 
            Console.WriteLine("\nMovies by Year 2010:");
            movieManager.ListMoviesByYear(2010);
 
            Console.WriteLine("\nMovies by Director 'Christopher Nolan':");
            movieManager.ListMoviesByDirector("Christopher Nolan");
 
            Console.WriteLine($"\nAverage Rating of 'Inception': {movieManager.GetAverageRating("Inception")}");
 
            Console.WriteLine("\nMovie Details for 'Avatar':");
            Console.WriteLine(movieManager.GetMovieDetails("Avatar"));
 
            movieManager.UpdateMovieRating("Avatar", 8.0);
            Console.WriteLine("\nUpdated Rating for 'Avatar':");
            Console.WriteLine(movieManager.GetMovieDetails("Avatar"));
 
            movieManager.RemoveMovie("Poop");
 
            Console.WriteLine("\nUpdated Movie List:");
            movieManager.PrintAllMovies();
        }
    }
 
    class MovieManager
    {
        private List<Movie> movies;
 
        class Movie
        {
            public string Title { get; }
            public string Genre { get; }
            public int Year { get; }
            public string Director { get; }
            public double Rating { get; set; } // Changed to set
 
            public Movie(string title, string genre, int year, string director, double rating)
            {
                Title = title;
                Genre = genre;
                Year = year;
                Director = director;
                Rating = rating;
            }
 
            public override string ToString()
            {
                return $"{Title} - {Genre}, {Year}, directed by {Director}, Rating: {Rating}";
            }
        }
 
        public MovieManager()
        {
            movies = new List<Movie>();
        }
 
        public void AddMovie(string title, string genre, int year, string director, double rating)
        {
            movies.Add(new Movie(title, genre, year, director, rating));
        }
 
        public void RemoveMovie(string title)
        {
            bool found = movies.RemoveAll(m => m.Title == title) > 0;
            if (!found)
            {
                Console.WriteLine("There is no such film.");
            }
        }
 
        public void PrintAllMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("There are no films.");
                return;
            }
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
 
        public void ListMoviesByGenre(string genre)
        {
            bool found = false;
            foreach (var movie in movies)
            {
                if (movie.Genre == genre)
                {
                    Console.WriteLine(movie);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("There are no films by this genre.");
            }
        }
 
        public void ListMoviesByYear(int year)
        {
            bool found = false;
            foreach (var movie in movies)
            {
                if (movie.Year == year)
                {
                    Console.WriteLine(movie);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("There are no films by this year.");
            }
        }
 
        public void ListMoviesByDirector(string director)
        {
            bool found = false;
            foreach (var movie in movies)
            {
                if (movie.Director == director)
                {
                    Console.WriteLine(movie);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("There are no films by this director.");
            }
        }
 
        public double GetAverageRating(string title)
        {
            double totalRating = 0;
            int count = 0;
            foreach (var movie in movies)
            {
                if (movie.Title == title)
                {
                    totalRating += movie.Rating;
                    count++;
                }
            }
 
            if (count > 0)
            {
                return totalRating / count;
            }
            else
            {
                return 0;
            }
        }
 
        public string GetMovieDetails(string title)
        {
            foreach (var movie in movies)
            {
                if (movie.Title == title)
                {
                    return movie.ToString();
                }
            }
            return "Movie not found.";
        }
 
        public void UpdateMovieRating(string title, double newRating)
        {
            foreach (var movie in movies)
            {
                if (movie.Title == title)
                {
                    movie.Rating = newRating;
                    return;
                }
            }
            Console.WriteLine("Movie not found.");
        }
    }
}