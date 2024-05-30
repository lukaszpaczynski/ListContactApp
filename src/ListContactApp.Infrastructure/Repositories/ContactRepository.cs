namespace ListContactApp.Infrastructure.Repositories
{
	public class ContactRepository : IContactRepository
	{
		private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
			_context = context;
        }

        public async Task Create(Contact contact)
		{
			_context.Add(contact);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Contact contact)
		{
			_context.Remove(contact);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Contact>> GetAll()
		{
			return await _context.Contacts.ToListAsync();
		}

		public async Task<Contact> GetByEmail(string email)
		{
			return await _context.Contacts.FirstOrDefaultAsync(x => x.Email == email);
		}

		public async Task Commit()
		{
			await _context.SaveChangesAsync();
		}
	}
}
