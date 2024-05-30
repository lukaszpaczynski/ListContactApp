namespace ListContactApp.Aplication.Contact.Commands.DeleteContact
{
	public record DeleteContactCommand(string email) : IRequest;
}
