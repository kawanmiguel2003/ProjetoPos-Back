using System;

namespace ProjetoPos.Domain.DTOs.ProfessorDto.Listar
{
    public class ProfessorListarDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public string? Biografia { get; set; }
    }
}
