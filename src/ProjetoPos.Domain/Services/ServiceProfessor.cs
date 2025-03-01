using ProjetoPos.Domain.DTOs.Common;
using ProjetoPos.Domain.DTOs.ProfessorDto.Adicionar;
using ProjetoPos.Domain.DTOs.ProfessorDto.Atualizar;
using ProjetoPos.Domain.DTOs.ProfessorDto.Listar;
using ProjetoPos.Domain.DTOs.ProfessorDto.Obter;
using ProjetoPos.Domain.Entities;
using ProjetoPos.Domain.Interfaces.Repositories;
using ProjetoPos.Domain.Interfaces.Services;
using ProjetoPos.Infra.CrossCutting.NotificationPattern;
using ProjetoPos.Infra.CrossCutting.NotificationPattern.Interface;
using System.Collections.Generic;

namespace ProjetoPos.Domain.Services
{
    public class ServiceProfessor : Notifiable, IServiceProfessor
    {
        private readonly IRepositoryProfessor repositoryProfessor;

        public ServiceProfessor(IRepositoryProfessor repositoryProfessor)
        {
            this.repositoryProfessor = repositoryProfessor;
        }

        public ServiceResponse<IEnumerable<ProfessorListarDto>> Listar()
        {
            var professores = repositoryProfessor.Listar();
            var professoresDto = professores.Select(professor => new ProfessorListarDto
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Biografia = professor.Biografia
            });

            return new ServiceResponse<IEnumerable<ProfessorListarDto>>(professoresDto, this);
        }

        public ServiceResponse<ProfessorObterDto> Obter(Guid id)
        {
            var professor = repositoryProfessor.Obter(id);
            if (professor is null)
            {
                AddNotification("Professor", "Professor não encontrado");
                return new ServiceResponse<ProfessorObterDto>(this);
            }

            var professorDto = new ProfessorObterDto()
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Biografia = professor.Biografia
            };

            return new ServiceResponse<ProfessorObterDto>(professorDto, this);
        }

        public ServiceResponse<BaseResponse> Adicionar(ProfessorAdicionarDto professorDto)
        {
            var validation = new ProfessorAdicionarDtoValidator().Validate(professorDto);
            if (!validation.IsValid)
            {
                AddNotifications(validation.Errors);
                return new ServiceResponse<BaseResponse>(this);
            }

            var professor = new Professor(
                professorDto.Nome,
                professorDto.Biografia);

            repositoryProfessor.Adicionar(professor);
            repositoryProfessor.Commit();

            return new ServiceResponse<BaseResponse>(
                new BaseResponse(professor.Id, "Professor Adicionado com Sucesso."),
                this);
        }

        public ServiceResponse<BaseResponse> Atualizar(ProfessorAtualizarDto professorDto)
        {
            var validation = new ProfessorAtualizarDtoValidator().Validate(professorDto);
            if (!validation.IsValid)
            {
                AddNotifications(validation.Errors);
                return new ServiceResponse<BaseResponse>(this);
            }

            var professor = repositoryProfessor.Obter(professorDto.Id);
            if (professor is null)
            {
                AddNotification("Professor", "Professor não encontrado");
                return new ServiceResponse<BaseResponse>(this);
            }

            professor.Atualizar(
                professorDto.Nome,
                professorDto.Biografia
            );

            repositoryProfessor.Commit();

            return new ServiceResponse<BaseResponse>(new BaseResponse(professor.Id, "Professor Atualizado com Sucesso."), this);
        }

        public ServiceResponse<BaseResponse> Remover(Guid id)
        {
            var professor = repositoryProfessor.Obter(id);
            if (professor is null)
            {
                AddNotification("Professor", "Professor não encontrado");
                return new ServiceResponse<BaseResponse>(this);
            }

            repositoryProfessor.Remover(professor);
            repositoryProfessor.Commit();

            return new ServiceResponse<BaseResponse>(new BaseResponse(id, "Professor Removido com Sucesso."), this);
        }
    }
}
