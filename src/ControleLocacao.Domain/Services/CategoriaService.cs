﻿using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Entities;
using ControleLocacao.Domain.Ports;
using Flunt.Notifications;

namespace ControleLocacao.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IResult<int> Add(Categoria categoria)
        {
            categoria.Validate();
            if (!categoria.IsValid)
            {
                //comum
                /*string criticas = string.Join(',', categoria.Notifications);
                throw new Exception(criticas);*/

                return new Result<int>(categoria.Notifications);

            }

            try
            {
                var id = _categoriaRepository.Add(categoria);
                return new Result<int>(id);
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains($"UK_{nameof(Categoria)}"))
                    return new Result<int>(new Notification(nameof(Categoria), "Categoria já cadastrada"));
                throw; 
            }

        }

        public IEnumerable<Categoria> GetAll()
            => _categoriaRepository.GetAll();


        public Categoria? GetById(int id)
            => _categoriaRepository.GetById(id);


        public IResult<bool> Update(Categoria categoria)
        {

            categoria.Validate();

            if (categoria.Id <= 0)
                categoria.AddNotification(nameof(Categoria.Id), "Id informado é inválido");

            if (!categoria.IsValid)
                return new Result<bool>(categoria.Notifications);

            try
            {
                _categoriaRepository.Update(categoria);
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains($"UK_{nameof(Categoria)}"))
                    return new Result<bool>(new Notification(nameof(Categoria), "Já existe uma categoria cadastrada com esse nome"));
                throw;
            }
        }


        public void Delete(int id)
            => _categoriaRepository.Delete(id);


    }
}

