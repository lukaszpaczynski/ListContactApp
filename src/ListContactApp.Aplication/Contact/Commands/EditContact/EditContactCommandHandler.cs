namespace ListContactApp.Aplication.Contact.Commands.EditContact
{
	public class EditContactCommandHandler : IRequestHandler<EditContactCommand>
	{
		private readonly IContactRepository _contactRepository;

        public EditContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(EditContactCommand command, CancellationToken cancellationToken)
		{
            var contact = await _contactRepository.GetByEmail(command.Email);

            contact.FirstName = command.FirstName;
            contact.LastName = command.LastName;
            contact.Email = command.Email;
            contact.Phone = command.Phone;
            contact.DateOfBirth = command.DateOfBirth;
            contact.Category = command.Category;
            contact.SubCategory = command.SubCategory;
            contact.Password = command.Password;

            await _contactRepository.Commit();
		}
	}
}
