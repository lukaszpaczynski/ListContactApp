namespace ListContactApp.Domain.Interfaces
{
	public interface IContactRepository
	{
		Task<IEnumerable<Contact>> GetAll();
		Task<Contact> GetByEmail(string email);
		Task Create(Contact contact);
		Task Delete(Contact contact);
		Task Commit();
	}
}
