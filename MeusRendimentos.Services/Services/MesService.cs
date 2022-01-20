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
    public class MesService : BaseService, IMesService
    {
        #region Propriedades Privadas
        private readonly IMapper _mapper;
        private readonly IMesRepository _repositorio;

        #endregion

        #region Construtor
        public MesService(IMesRepository repositorio, IMapper mapper)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public List<MesModel> GetAll()
        {
            var dadosMes = _repositorio.BuscarTodosPorQueryGerador<Mes>("").ToList();

            return (dadosMes.Count == 0 ? new List<MesModel>() : _mapper.Map<List<MesModel>>(dadosMes));
        }

        public MesModel GetById(string id)
        {
            if (!id.IsNumeric() || string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Código inválido");

            return _repositorio.BuscarPorId<Mes>(int.Parse(id)) == null ? null : _mapper.Map<MesModel>(_repositorio.BuscarPorId<Mes>(int.Parse(id)));
        }

        public bool Post(MesModel MesModel)
        {
            if (MesModel.Codigo != 0 && MesModel.Codigo != null)
                throw new ArgumentException("O Código deve ser nulo");

            //verificar se existe o codigo da empresa informada

            Validator.ValidateObject(MesModel, new ValidationContext(MesModel), true);

            return (_repositorio.Adicionar(_mapper.Map<Mes>(MesModel)) > 0);
        }

        public bool Put(MesModel MesModel)
        {
            if (MesModel.Codigo == 0)
                throw new ArgumentException("Código inválido");

            return (_repositorio.Atualizar(MesModel.Codigo ?? 0, _mapper.Map<Mes>(MesModel)) > 0);
        }
        public bool Delete(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código não informado.");

            return (_repositorio.Excluir<Mes>(int.Parse(id)) > 0);
        }
        #endregion
    }
}
