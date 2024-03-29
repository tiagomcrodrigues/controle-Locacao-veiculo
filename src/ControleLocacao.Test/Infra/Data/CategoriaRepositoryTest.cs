﻿using AutoFixture;
using ControleLocacao.Domain.Ports;
using ControleLocacao.Infra.Data;
using ControleLocacao.Infra.Data.Repositories;
using tb = ControleLocacao.Infra.Data.Tables;
using dm = ControleLocacao.Domain.Entities;
using ControleLocacao.Test.Mocks;

namespace ControleLocacao.Test.Infra.Data
{

    public class CategoriaRepositoryTest
    {

        private ICategoriaRepository _repository;
        private Fixture _fixture = new Fixture();
        private DbLocacao _context;

        private int _idCategoria_1;
        private int _idCategoria_2;
        private string _nomeCategoria_1 = "CATEGORIA TEST 1";
        private string _nomeCategoria_2 = "CATEGORIA TEST 2";

        public CategoriaRepositoryTest()
        {
            
            // Criando banco de teste/mockado
            _context = new DbLocacaoTest();
            _repository = new CategoriaRepository(_context);

            // Populando dados para teste
            tb.Categoria categoria1 = new() { Nome = _nomeCategoria_1 };
            _context.Categorias.Add(categoria1);

            tb.Categoria categoria2 = new() { Nome = _nomeCategoria_2 };
            _context.Categorias.Add(categoria2);
            _context.SaveChanges();

            _idCategoria_1 = categoria1.Id;
            _idCategoria_2 = categoria2.Id;

        }

        [Fact]
        public void GetById_RetornaRegistroOk()
        {

            dm.Categoria? resp = _repository.GetById(_idCategoria_1);
            Assert.NotNull(resp);
            Assert.True(resp.Id == _idCategoria_1);

        }

        [Fact]
        public void GetById_RetornaRegistroNull()
        {
            dm.Categoria? res = _repository.GetById(55);
            Assert.Null(res);
        }

        [Fact]
        public void GetAll()
        {
            var result = _repository.GetAll();

            Assert.True(result.Any());
        }

        [Fact]
        public void Add()
        {
            var categoriaTest =  new dm.Categoria() { Nome = "ttttt" };
            int id = _repository.Add(categoriaTest);
            Assert.True(id > 0);
        }

        [Fact]
        public void Update()
        {
            dm.Categoria? categoriaEditada = new(_idCategoria_2)
            {
                Nome = "CATEGORIA_EDITADA"
            };
            _repository.Update(categoriaEditada);

            dm.Categoria? categoriaGravada = _repository.GetById(_idCategoria_2);
            Assert.NotNull(categoriaGravada);
            Assert.Equal(categoriaGravada.Nome, categoriaEditada.Nome);

        }

        [Fact(DisplayName = "Deve excluir categoria")]
        public void Delete()
        {
            var categoriaTest = new dm.Categoria() { Nome = "CATEGORIA CONDENADA" };
            int id = _repository.Add(categoriaTest);
            _repository.Delete(id);

            dm.Categoria? res = _repository.GetById(id);
            Assert.Null(res);
        }


    }
}
