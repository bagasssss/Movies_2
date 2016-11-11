using System.Data.Entity;

namespace Movies.Infra
{
    public class Initializer : CreateDatabaseIfNotExists<MoviesDbSet>
    {
        protected override void Seed(MoviesDbSet context)
        {
            var movies = new[]
            {
                new Movie()
                {
                    title = "Доктор Хаус",
                    directorName = "Хер Знает",
                    category = "Сериал",
                    year = 2013
                },
                new Movie()
                {
                    title = "Супермен",
                    directorName = "Стен Ли",
                    category = "Фантастика",
                    year = 2007
                },
                new Movie()
                {
                    title = "Властелин Колец",
                    directorName = "Бог всех Гиков",
                    category = "Фэнтези",
                    year = 2002
                },
                new Movie()
                {
                    title = "Матрица",
                    directorName = "Братье Ебанько",
                    category = "Супер фантастика",
                    year = 2001
                }
            };

            foreach (var movie in movies)
            {
                context.Movies.Add(movie);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }

    public class MoviesDbSet: DbContext
    {
        public MoviesDbSet():
            base(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        static MoviesDbSet()
        {
            System.Data.Entity.Database.SetInitializer(new Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
    }
}