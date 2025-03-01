﻿namespace ProjetoPos.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
    }
}
