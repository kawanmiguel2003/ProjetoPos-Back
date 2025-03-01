using ProjetoPos.Domain.DTOs.Common;
using ProjetoPos.Domain.DTOs.ProfessorDto.Adicionar;
using ProjetoPos.Domain.DTOs.ProfessorDto.Atualizar;
using ProjetoPos.Domain.DTOs.ProfessorDto.Listar;
using ProjetoPos.Domain.DTOs.ProfessorDto.Obter;

namespace ProjetoPos.Domain.Interfaces.Services
{
    public interface IServiceProfessor
    {
        ServiceResponse<IEnumerable<ProfessorListarDto>> Listar();
        ServiceResponse<ProfessorObterDto> Obter(Guid id);
        ServiceResponse<BaseResponse> Adicionar(ProfessorAdicionarDto professorDto);
        ServiceResponse<BaseResponse> Atualizar(ProfessorAtualizarDto professorDto);
        ServiceResponse<BaseResponse> Remover(Guid id);
    }
}
