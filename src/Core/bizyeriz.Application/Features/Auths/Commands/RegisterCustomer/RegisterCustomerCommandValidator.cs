using FluentValidation;

namespace bizyeriz.Application.Features.Auths.Commands.RegisterUser;

public class RegisterCustomerCommandValidator : AbstractValidator<RegisterCustomerCommand>
{
    public RegisterCustomerCommandValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("Email Formatı hatalı!");

        RuleFor(x => x.Gsm)
            .Matches(@"^\+?[1-9]\d{1,14}$").When(x => !string.IsNullOrEmpty(x.Gsm))
            .WithMessage("GSM Formatı hatalı!");

        RuleFor(x => x)
            .Must(x => !string.IsNullOrEmpty(x.Email) || !string.IsNullOrEmpty(x.Gsm))
            .WithMessage("GSM veya email alanlarından birini doldurun lütfen!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre zorunlu alandır!")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalıdır.")
            .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
            .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
            .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");
    }
}