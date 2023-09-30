using FluentValidation;


namespace Shop.Application.Features.Item.UpdateItem
{
    public class UpdateItemValidator: AbstractValidator<UpdateItemRequest>
    {

        public UpdateItemValidator()
        {
            RuleLevelCascadeMode = ClassLevelCascadeMode;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(25);

            RuleFor(x => x.Price)
                     .NotEmpty() 
                    .GreaterThan(0);

            RuleFor(x => x.Description)
                    .NotEmpty().MinimumLength(3)
                    .MaximumLength(255);

        }

           
    }
}
