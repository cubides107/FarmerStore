using FarmerStore.Models.Products;
using FluentValidation;

namespace FarmerStore.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Esta mal perra escriba bien"); ;
            RuleFor(x => x.Name).Length(0, 10).WithMessage("Esta mal perra escriba bien");
        }
    }
}
