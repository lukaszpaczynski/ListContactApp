namespace ListContactApp.Aplication.Contact.Queries.GetAllContacts
{
	public record GetAllContactsQuery : IRequest<IEnumerable<ContactDto>>;
}
