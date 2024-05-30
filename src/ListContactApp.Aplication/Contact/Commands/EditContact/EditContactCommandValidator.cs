namespace ListContactApp.Aplication.Contact.Commands.EditContact
{
    public class EditContactCommandValidator : AbstractValidator<EditContactCommand>
    {
        public EditContactCommandValidator()
        {
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
