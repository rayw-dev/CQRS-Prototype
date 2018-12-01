using CQRS.Prototype.Country.Domain.Commands;
using FluentValidation;

namespace CQRS.Prototype.Country.Domain.Validators
{
    public abstract class CountryValidation<T> : AbstractValidator<T> where T : CountryCommand
    {
        protected void ValidateEnglishName()
        {
            RuleFor(c => c.EnglishName)
                .NotEmpty().WithMessage("Please ensure you have entered the English Name")
                .Length(2, 150).WithMessage("The English Name must have between 2 and 150 characters");
        }

        protected void ValidateLocalName()
        {
            RuleFor(c => c.LocalName)
                .NotEmpty().WithMessage("Please ensure you have entered the Local Name")
                .Length(2, 150).WithMessage("The Local Name must have between 2 and 150 characters");
        }

        protected void ValidateAlpha2()
        {
            RuleFor(c => c.Alpha2Code)
                .NotEmpty().WithMessage("Please ensure you have entered the Alpha 2 Code")
                .Length(2, 2).WithMessage("The Alpha 2 Code must have 2 characters");
        }

        protected void ValidateAlpha3()
        {
            RuleFor(c => c.Alpha3Code)
                .NotEmpty().WithMessage("Please ensure you have entered the Alpha 3 Code")
                .Length(3, 3).WithMessage("The Alpha 3 Code must have 3 characters");
        }

        protected void ValidateNumericCode()
        {
            RuleFor(c => c.NumericCode)
                .GreaterThan(0).WithMessage("Please ensure you have entered a Numeric Code greater than 0");
        }

        protected void FullValidation()
        {
            ValidateEnglishName();
            ValidateLocalName();
            ValidateAlpha2();
            ValidateAlpha3();
            ValidateNumericCode();
        }

        protected void DeleteValidation()
        {
            ValidateEnglishName();
            ValidateAlpha3();
        }
    }
}
