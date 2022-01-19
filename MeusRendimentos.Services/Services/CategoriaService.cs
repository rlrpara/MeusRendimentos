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
    public class CategoriaService : BaseService, ICategoriaService
    {
        #region Propriedades Privadas
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _repositorio;

        #endregion

        #region Construtor
        public CategoriaService(ICategoriaRepository repositorio, IMapper mapper)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public List<CategoriaModel> GetAll()
        {
            var dadosCategoria = _repositorio.BuscarTodosPorQueryGerador<Categoria>("").ToList();

            return (dadosCategoria.Count == 0 ? new List<CategoriaModel>() : _mapper.Map<List<CategoriaModel>>(dadosCategoria));
        }

        public CategoriaModel GetById(string id)
        {
            if (!id.IsNumeric() || string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Código inválido");

            return _repositorio.BuscarPorId<Categoria>(int.Parse(id)) == null ? null : _mapper.Map<CategoriaModel>(_repositorio.BuscarPorId<Categoria>(int.Parse(id)));
        }

        public bool Post(CategoriaModel CategoriaModel)
        {
            if (CategoriaModel.Codigo != 0 && CategoriaModel.Codigo != null)
                throw new ArgumentException("O Código deve ser nulo");

            //verificar se existe o codigo da empresa informada

            Validator.ValidateObject(CategoriaModel, new ValidationContext(CategoriaModel), true);

            return (_repositorio.Adicionar(_mapper.Map<Categoria>(CategoriaModel)) > 0);
        }

        public bool Put(CategoriaModel CategoriaModel)
        {
            if (CategoriaModel.Codigo == 0)
                throw new ArgumentException("Código inválido");

            return (_repositorio.Atualizar(CategoriaModel.Codigo ?? 0, _mapper.Map<Categoria>(CategoriaModel)) > 0);
        }
        public bool Delete(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código não informado.");

            return (_repositorio.Excluir<Categoria>(int.Parse(id)) > 0);
        }
        #endregion
    }
}
