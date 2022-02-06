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
    public class UsuarioService : BaseService, IUsuarioService
    {
        #region Propriedades Privadas
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repositorio;

        #endregion

        #region Construtor
        public UsuarioService(IUsuarioRepository repositorio, IMapper mapper)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public List<UsuarioModel> GetAll()
        {
            var dadosUsuario = _repositorio.BuscarTodosPorQueryGerador<Usuario>("").ToList();

            return dadosUsuario.Count == 0 ? new List<UsuarioModel>() : _mapper.Map<List<UsuarioModel>>(dadosUsuario);
        }

        public UsuarioModel GetById(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código inválido");

            return _repositorio.BuscarPorId<Usuario>(int.Parse(id)) == null ? null : _mapper.Map<UsuarioModel>(_repositorio.BuscarPorId<Usuario>(int.Parse(id)));
        }

        public bool Post(UsuarioModel UsuarioModel)
        {
            Validator.ValidateObject(UsuarioModel, new ValidationContext(UsuarioModel), true);

            return (_repositorio.Adicionar(_mapper.Map<Usuario>(UsuarioModel)) > 0);
        }

        public bool Put(UsuarioModel UsuarioModel)
        {
            if (UsuarioModel.Codigo == 0)
                throw new ArgumentException("Código inválido");

            return (_repositorio.Atualizar(UsuarioModel.Codigo ?? 0, _mapper.Map<Usuario>(UsuarioModel)) > 0);
        }
        public bool Delete(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código não informado.");

            return (_repositorio.Excluir<Usuario>(int.Parse(id)) > 0);
        }
        #endregion
    }
}
