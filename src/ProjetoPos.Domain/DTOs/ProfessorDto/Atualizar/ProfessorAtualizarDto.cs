using System;

namespace ProjetoPos.Domain.DTOs.ProfessorDto.Atualizar
{
    public class ProfessorAtualizarDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Biografia { get; set; }
    }
}
