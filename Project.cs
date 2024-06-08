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
            movieManager.AddMovie("Pirates of the Caribbean", "Adventure", 2003, "Gore Verbinski", 8.1);

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

            movieManager.RemoveMovie("Pirates of the Caribbean");

            Console.WriteLine("\nUpdated Movie List:");
            movieManager.PrintAllMovies();
        }
    }

    class MovieManager
    {
        private Queue<Movie> movies;

        class Movie
        {
            public string Title { get; }
            public string Genre { get; }
            public int Year { get; }
            public string Director { get; }
            public double Rating { get; set; }

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
            movies = new Queue<Movie>();
        }

        public void AddMovie(string title, string genre, int year, string director, double rating)
        {
            movies.Enqueue(new Movie(title, genre, year, director, rating));
        }

        public void RemoveMovie(string title)
        {
            int initialCount = movies.Count;
            bool found = false;
            for (int i = 0; i < initialCount; i++)
            {
                var currentMovie = movies.Dequeue();
                if (currentMovie.Title != title)
                {
                    movies.Enqueue(currentMovie);
                }
                else
                {
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Movie not found.");
            }
        }

        public void PrintAllMovies()
        {
            var tempQueue = new Queue<Movie>(movies);
            if (tempQueue.Count == 0)
            {
                Console.WriteLine("No movies available.");
                return;
            }
            while (tempQueue.Count > 0)
            {
                Console.WriteLine(tempQueue.Dequeue());
            }
        }

        public void ListMoviesByGenre(string genre)
        {
            var tempQueue = new Queue<Movie>(movies);
            bool found = false;
            while (tempQueue.Count > 0)
            {
                var currentMovie = tempQueue.Dequeue();
                if (currentMovie.Genre == genre)
                {
                    Console.WriteLine(currentMovie);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No movies found in this genre.");
            }
        }

        public void ListMoviesByYear(int year)
        {
            var tempQueue = new Queue<Movie>(movies);
            bool found = false;
            while (tempQueue.Count > 0)
            {
                var currentMovie = tempQueue.Dequeue();
                if (currentMovie.Year == year)
                {
                    Console.WriteLine(currentMovie);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No movies found from this year.");
            }
        }

        public void ListMoviesByDirector(string director)
        {
            var tempQueue = new Queue<Movie>(movies);
            bool found = false;
            while (tempQueue.Count > 0)
            {
                var currentMovie = tempQueue.Dequeue();
                if (currentMovie.Director == director)
                {
                    Console.WriteLine(currentMovie);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No movies found by this director.");
            }
        }

        public double GetAverageRating(string title)
        {
            var tempQueue = new Queue<Movie>(movies);
            double totalRating = 0;
            int count = 0;
            while (tempQueue.Count > 0)
            {
                var currentMovie = tempQueue.Dequeue();
                if (currentMovie.Title == title)
                {
                    totalRating += currentMovie.Rating;
                    count++;
                }
            }
            if (count > 0)
            {
                return totalRating / count;
            }
            else
            {
                Console.WriteLine("Movie not found.");
                return 0;
            }
        }

        public string GetMovieDetails(string title)
        {
            var tempQueue = new Queue<Movie>(movies);
            while (tempQueue.Count > 0)
            {
                var currentMovie = tempQueue.Dequeue();
                if (currentMovie.Title == title)
                {
                    return currentMovie.ToString();
                }
            }
            return "Movie not found.";
        }

        public void UpdateMovieRating(string title, double newRating)
        {
            int initialCount = movies.Count;
            bool updated = false;
            for (int i = 0; i < initialCount; i++)
            {
                var currentMovie = movies.Dequeue();
                if (currentMovie.Title == title)
                {
                    currentMovie.Rating = newRating;
                    updated = true;
                }
                movies.Enqueue(currentMovie);
            }
            if (!updated)
            {
                Console.WriteLine("Movie not found.");
            }
        }
    }
}
