using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.Interfaces;
using MeusRendimentos.Services.Models;
using MeusRendimentos.Infra.Utilities.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MeusRendimentos.Services.Services
{
    public class DespesaService : BaseService, IDespesaService
    {
        #region Propriedades Privadas
        private readonly IMapper _mapper;
        private readonly IDespesaRepository _repositorio;

        #endregion

        #region Construtor
        public DespesaService(IDespesaRepository repositorio, IMapper mapper)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public List<DespesaModel> GetAll()
        {
            var dadosDespesa = _repositorio.BuscarTodosPorQueryGerador<Despesa>("").ToList();

            return (dadosDespesa.Count == 0 ? new List<DespesaModel>() : _mapper.Map<List<DespesaModel>>(dadosDespesa));
        }

        public DespesaModel GetById(string id)
        {
            if (!id.IsNumeric() || string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Código inválido");

            return _repositorio.BuscarPorId<Despesa>(int.Parse(id)) == null ? null : _mapper.Map<DespesaModel>(_repositorio.BuscarPorId<Despesa>(int.Parse(id)));
        }

        public bool Post(DespesaModel DespesaModel)
        {
            if (DespesaModel.Codigo != 0 && DespesaModel.Codigo != null)
                throw new ArgumentException("O Código deve ser nulo");

            //verificar se existe o codigo da empresa informada

            Validator.ValidateObject(DespesaModel, new ValidationContext(DespesaModel), true);

            return (_repositorio.Adicionar(_mapper.Map<Despesa>(DespesaModel)) > 0);
        }

        public bool Put(DespesaModel DespesaModel)
        {
            if (DespesaModel.Codigo == 0)
                throw new ArgumentException("Código inválido");

            return (_repositorio.Atualizar(DespesaModel.Codigo ?? 0, _mapper.Map<Despesa>(DespesaModel)) > 0);
        }
        public bool Delete(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código não informado.");

            return (_repositorio.Excluir<Despesa>(int.Parse(id)) > 0);
        }
        #endregion
    }
}
