namespace BlogAPI.Repositories;

public interface IUnitOfWork
{
	public Task CompleteAsync();
}
