using PTR.Mongo.WebApp.Models.Dtos.Requests;
using FluentValidation;

namespace PTR.Mongo.WebApp.Models.Validators
{
    public class CreateProductRequestDtoValidator : AbstractValidator<CreateProductRequestDto>
    {
        public CreateProductRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0")
                .LessThanOrEqualTo(1_000_000).WithMessage("El precio no puede superar 1.000.000");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Debe indicar una categoría válida");

            RuleFor(x => x.Label)
                .IsInEnum().WithMessage("El label no es válido");

            RuleFor(x => x.Size)
                .IsInEnum().WithMessage("El tamaño no es válido");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("La descripción no puede superar 500 caracteres")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.Discount)
                .InclusiveBetween(0, 100).WithMessage("El descuento debe estar entre 0 y 100")
                .When(x => x.Discount.HasValue);

            RuleFor(x => x.RecommendedFor)
                .GreaterThan(0).WithMessage("El campo 'RecommendedFor' debe ser mayor a 0")
                .When(x => x.RecommendedFor.HasValue);

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("El usuario debe ser válido")
                .When(x => x.UserId.HasValue);
        }
    }
}
