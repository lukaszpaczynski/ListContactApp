namespace ListContactApp.Aplication.Contact.Queries.GetContactByEmail
{
	public class GetContactByEmailQueryHandler : IRequestHandler<GetContactByEmailQuery, ContactDto>
	{
		private readonly IContactRepository _contactRepository;

        public GetContactByEmailQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactDto> Handle(GetContactByEmailQuery request, CancellationToken cancellationToken)
		{
			var contact = await _contactRepository.GetByEmail(request.email);
			return contact.Adapt<ContactDto>();
		}
	}
}
