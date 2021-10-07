namespace FleetApi.Repositories.Abstracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAccountRepository AccountRepository { get; }

        IVehiclesRepository VehiclesRepository { get; }
    }
}
