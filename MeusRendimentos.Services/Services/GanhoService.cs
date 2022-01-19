using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.Interfaces;
using MeusRendimentos.Services.Models;
using QueroBilhete.Infra.Utilities.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MeusRendimentos.Services.Services
{
    public class GanhoService : BaseService, IGanhoService
    {
        #region Propriedades Privadas
        private readonly IMapper _mapper;
        private readonly IGanhoRepository _repositorio;
        #endregion

        #region Construtor
        public GanhoService(IGanhoRepository repositorio, IMapper mapper)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public List<GanhoModel> GetAll()
        {
            var dadosGanho = _repositorio.BuscarTodosPorQueryGerador<Ganho>("").ToList();

            return (dadosGanho.Count == 0 ? new List<GanhoModel>() : _mapper.Map<List<GanhoModel>>(dadosGanho));
        }

        public GanhoModel GetById(string id)
        {
            if (!id.IsNumeric() || string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Código inválido");

            return _repositorio.BuscarPorId<Ganho>(int.Parse(id)) == null ? null : _mapper.Map<GanhoModel>(_repositorio.BuscarPorId<Ganho>(int.Parse(id)));
        }

        public bool Post(GanhoModel GanhoModel)
        {
            if (GanhoModel.Codigo != 0 && GanhoModel.Codigo != null)
                throw new ArgumentException("O Código deve ser nulo");

            //verificar se existe o codigo da empresa informada

            Validator.ValidateObject(GanhoModel, new ValidationContext(GanhoModel), true);

            return (_repositorio.Adicionar(_mapper.Map<Ganho>(GanhoModel)) > 0);
        }

        public bool Put(GanhoModel GanhoModel)
        {
            if (GanhoModel.Codigo == 0)
                throw new ArgumentException("Código inválido");

            return (_repositorio.Atualizar(GanhoModel.Codigo ?? 0, _mapper.Map<Ganho>(GanhoModel)) > 0);
        }
        public bool Delete(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código não informado.");

            return (_repositorio.Excluir<Ganho>(int.Parse(id)) > 0);
        }
        #endregion
    }
}
