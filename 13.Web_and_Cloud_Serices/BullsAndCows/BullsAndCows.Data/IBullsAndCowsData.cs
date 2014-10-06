namespace BullsAndCows.Data
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IBullsAndCowsData
    {
        IRepository<ApplicationUser> Players { get; }
        IRepository<Game> Games { get; }
        IRepository<Guess> Guesses { get; }
        IRepository<Notification> Notifications { get; }
        int SaveChanges();
    }
}