namespace ListContactApp.Aplication.Contact.Commands.DeleteContact
{
	public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
	{
		private readonly IContactRepository _contactRepository;

        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(DeleteContactCommand command, CancellationToken cancellationToken)
		{
            var contact = await _contactRepository.GetByEmail(command.email);
            await _contactRepository.Delete(contact);
		}
	}
}
