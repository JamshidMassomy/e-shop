using FluentValidation;


namespace Shop.Application.Features.Item.CreateItem
{
    public class CreateItemValidator: AbstractValidator<CreateItemRequest>
    {
        public CreateItemValidator()
        {
            
            RuleLevelCascadeMode = ClassLevelCascadeMode;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.Description)
                .MaximumLength(255);

        }
    }
}
