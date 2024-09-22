namespace bizyeriz.Application.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Commit();
}
