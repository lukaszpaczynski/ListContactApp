namespace ListContactApp.Aplication.Contact.Queries.GetContactByEmail
{
	public record GetContactByEmailQuery(string email) : IRequest<ContactDto>;
}
