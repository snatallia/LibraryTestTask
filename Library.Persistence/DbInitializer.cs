namespace Library.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext context)
        { 
            context.Database.EnsureCreated();
        }
    }
}
