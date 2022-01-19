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
    public class CartaoService : BaseService, ICartaoService
    {
        #region Propriedades Privadas
        private readonly IMapper _mapper;
        private readonly ICartaoRepository _repositorio;

        #endregion

        #region Construtor
        public CartaoService(ICartaoRepository repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Métodos Públicos
        public List<CartaoModel> GetAll()
        {
            var dadosCartao = _repositorio.BuscarTodosPorQueryGerador<Cartao>("").ToList();

            return (dadosCartao.Count == 0 ? new List<CartaoModel>() : _mapper.Map<List<CartaoModel>>(dadosCartao));
        }

        public CartaoModel GetById(string id)
        {
            if (!id.IsNumeric() || string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Código inválido");

            return _repositorio.BuscarPorId<Cartao>(int.Parse(id)) == null ? null : _mapper.Map<CartaoModel>(_repositorio.BuscarPorId<Cartao>(int.Parse(id)));
        }

        public bool Post(CartaoModel CartaoModel)
        {
            if (CartaoModel.Codigo != 0 && CartaoModel.Codigo != null)
                throw new ArgumentException("O Código deve ser nulo");

            //verificar se existe o codigo da empresa informada

            Validator.ValidateObject(CartaoModel, new ValidationContext(CartaoModel), true);

            return (_repositorio.Adicionar(_mapper.Map<Cartao>(CartaoModel)) > 0);
        }

        public bool Put(CartaoModel CartaoModel)
        {
            if (CartaoModel.Codigo == 0)
                throw new ArgumentException("Código inválido");

            return (_repositorio.Atualizar(CartaoModel.Codigo ?? 0, _mapper.Map<Cartao>(CartaoModel)) > 0);
        }
        public bool Delete(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código não informado.");

            return (_repositorio.Excluir<Cartao>(int.Parse(id)) > 0);
        }
        #endregion
    }
}
