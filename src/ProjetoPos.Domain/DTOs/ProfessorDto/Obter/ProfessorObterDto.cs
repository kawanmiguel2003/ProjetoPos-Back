﻿using System;

namespace ProjetoPos.Domain.DTOs.ProfessorDto.Obter
{
    public class ProfessorObterDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public string? Biografia { get; set; }
    }
}
