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
    public class TipoService : BaseService, ITipoService
    {
        #region Propriedades Privadas
        private readonly IMapper _mapper;
        private readonly ITipoRepository _repositorio;

        #endregion

        #region Construtor
        public TipoService(ITipoRepository repositorio, IMapper mapper)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public List<TipoModel> GetAll()
        {
            var dadosTipo = _repositorio.BuscarTodosPorQueryGerador<Tipo>("").ToList();

            return (dadosTipo.Count == 0 ? new List<TipoModel>() : _mapper.Map<List<TipoModel>>(dadosTipo));
        }

        public TipoModel GetById(string id)
        {
            if (!id.IsNumeric() || string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Código inválido");

            return _repositorio.BuscarPorId<Tipo>(int.Parse(id)) == null ? null : _mapper.Map<TipoModel>(_repositorio.BuscarPorId<Tipo>(int.Parse(id)));
        }

        public bool Post(TipoModel TipoModel)
        {
            if (TipoModel.Codigo != 0 && TipoModel.Codigo != null)
                throw new ArgumentException("O Código deve ser nulo");

            //verificar se existe o codigo da empresa informada

            Validator.ValidateObject(TipoModel, new ValidationContext(TipoModel), true);

            return (_repositorio.Adicionar(_mapper.Map<Tipo>(TipoModel)) > 0);
        }

        public bool Put(TipoModel TipoModel)
        {
            if (TipoModel.Codigo == 0)
                throw new ArgumentException("Código inválido");

            return (_repositorio.Atualizar(TipoModel.Codigo ?? 0, _mapper.Map<Tipo>(TipoModel)) > 0);
        }
        public bool Delete(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código não informado.");

            return (_repositorio.Excluir<Tipo>(int.Parse(id)) > 0);
        }
        #endregion
    }
}
