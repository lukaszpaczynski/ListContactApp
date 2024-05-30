namespace ListContactApp.Aplication.Contact.Commands.CreateContact
{
	public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
	{
		private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
			_contactRepository = contactRepository;

		}

        public async Task Handle(CreateContactCommand command, CancellationToken cancellationToken)
		{
			var contact = command.Adapt<ListContactApp.Domain.Entities.Contact>();
			await _contactRepository.Create(contact);
		}
	}
}
