using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoPos.Domain.Entities.Base;
using ProjetoPos.Domain.Interfaces.Repositories.Base;
using ProjetoPos.Infra.Data.Context;

namespace ProjetoPos.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly ProjetoPosContext Context;

        public RepositoryBase(ProjetoPosContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Listar()
        {
            return DbSet.AsEnumerable();
        }

        public TEntity? Obter(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Remover(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
