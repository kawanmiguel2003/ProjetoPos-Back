using FluentValidation;

namespace ProjetoPos.Domain.DTOs.ProfessorDto.Atualizar
{
    public class ProfessorAtualizarDtoValidator : AbstractValidator<ProfessorAtualizarDto>
    {
        public ProfessorAtualizarDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");

            RuleFor(x => x.Biografia)
                .NotEmpty().WithMessage("Biografia é obrigatória")
                .MaximumLength(1000).WithMessage("Biografia deve ter no máximo 1000 caracteres");
        }
    }
}
