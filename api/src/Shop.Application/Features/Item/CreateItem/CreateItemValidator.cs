using FluentValidation;


namespace Shop.Application.Features.Item.CreateItem
{
    public class CreateItemValidator: AbstractValidator<CreateItemRequest>
    {
        public CreateItemValidator()
        {
            /*
            RuleLevelCascadeMode = ClassLevelCascadeMode;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.Max);

            RuleFor(x => x.HeroType)
                .IsInEnum();

            RuleFor(x => x.Age)
                .GreaterThan(0);

            RuleFor(x => x.Nickname)
                .MaximumLength(StringSizes.Max);

            RuleFor(x => x.Team)
                .MaximumLength(StringSizes.Max);
            */
        }
    }
}
