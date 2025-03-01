using ProjetoPos.Domain.Entities;
using ProjetoPos.Domain.Interfaces.Repositories;
using ProjetoPos.Infra.Data.Context;
using ProjetoPos.Infra.Data.Repositories.Base;

namespace ProjetoPos.Infra.Data.Repositories
{
    public class RepositoryProfessor : RepositoryBase<Professor>, IRepositoryProfessor
    {
        public RepositoryProfessor(ProjetoPosContext context) : base(context)
        {
        }
    }
}
