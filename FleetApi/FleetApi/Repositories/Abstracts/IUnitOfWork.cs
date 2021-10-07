namespace FleetApi.Repositories.Abstracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
