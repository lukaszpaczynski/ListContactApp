namespace ListContactApp.Aplication.Contact.Queries.GetAllContacts
{
	public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactDto>>
	{
		private readonly IContactRepository _contactRepository;

        public GetAllContactsQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
		{
			var contacts = await _contactRepository.GetAll();
			return contacts.Adapt<IEnumerable<ContactDto>>();
		}
	}
}
