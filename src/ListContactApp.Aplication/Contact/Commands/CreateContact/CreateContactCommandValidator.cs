namespace ListContactApp.Aplication.Contact.Commands.CreateContact
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator(IContactRepository repository)
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .MinimumLength(2).WithMessage("First name should have at least 2 characters")
                .MaximumLength(20).WithMessage("First name should have a maximum of 20 characters");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Last name should have at least 2 characters")
                .MaximumLength(20).WithMessage("Last name should have a maximum of 20 characters");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress()
                .Custom((value, context) =>
                {
                    var existingEmail = repository.GetByEmail(value.ToString()).Result;
                    if (existingEmail != null)
                    {
                        context.AddFailure($"{value} already exists!");
                    }
                });

            RuleFor(c => c.Phone)
                .MinimumLength(2).WithMessage("Phone should have at least 2 characters")
                .MaximumLength(12).WithMessage("Phone should have a maximum of 12 characters")
                .Matches(@"^\d+$").WithMessage("Phone should contain only digits");

            RuleFor(c => c.DateOfBirth)
                .NotEmpty()
                .Custom((value, context) =>
                {
                    string dateString = value.ToString("yyyy-MM-dd");
                    if (!DateOnly.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    {
                        context.AddFailure($"{value} is not correct format for date of birth. Use yyyy-MM-dd");
                    }
                });
        }
    }
}
