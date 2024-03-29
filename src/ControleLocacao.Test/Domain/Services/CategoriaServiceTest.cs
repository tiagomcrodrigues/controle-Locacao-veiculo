﻿using AutoFixture;
using ControleLocacao.Domain.Entities;
using ControleLocacao.Domain.Ports;
using ControleLocacao.Domain.Services;
using Moq;

namespace ControleLocacao.Test.Domain.Services
{
    public class CategoriaServiceTest
    {
        private Mock<ICategoriaRepository> _repositorio = new();
        private CategoriaService _categoriaService;
        private Fixture _fixture = new Fixture();
        private const int ID_ = 1;

        public CategoriaServiceTest()
        {
            _categoriaService = new(_repositorio.Object);
        }
        [Fact]
        public void AddSucess()
        {

            _repositorio
                .Setup(p => p.Add(It.IsAny<Categoria>()))
                .Returns(ID_);

            var categoria = _fixture.Create<Categoria>();
            var result = _categoriaService.Add(categoria);

            Assert.True(result.Success);
            Assert.Equal(ID_, result.Data);

        }

        [Fact]
        public void AddError()
        {

            const int ID_CATETORIA = 1;

            _repositorio
                .Setup(p => p.Add(It.IsAny<Categoria>()))
                .Returns(ID_CATETORIA);

            var categoria = new Categoria();
            var resut = _categoriaService.Add(categoria);

            Assert.False(resut.Success);
            Assert.Equal(3, resut.Errors.Count());

        }

        [Fact]
        public void ListAllOk()
        {
            IEnumerable<Categoria> categorias = _fixture.Create<IEnumerable<Categoria>>();
            _repositorio
                .Setup(p => p.GetAll())
                .Returns(categorias);

            var result = _categoriaService.GetAll();

            Assert.True(result.Any());

        }

        [Fact]
        public void GetIdOk()
        {
            Categoria categoria = _fixture.Create<Categoria>();
            _repositorio
                .Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(categoria);

            var result = _categoriaService.GetById(ID_);

            Assert.NotNull(result);

        }


        [Fact]
        public void UpdateOk()
        {

            _repositorio
                .Setup(p => p.Update(It.IsAny<Categoria>()));

            var categoria = new Categoria(ID_) { Nome = "CATEGORIA TEST",ValorDiaria=1,ValorSeguro=1 };
            var resut = _categoriaService.Update(categoria);

            Assert.True(resut.Success);

        }


        [Fact]
        public void UpdateError()
        {

            _repositorio
                .Setup(p => p.Update(It.IsAny<Categoria>()));

            var categoria = new Categoria();
            var resut = _categoriaService.Update(categoria);

            Assert.False(resut.Success);

        }

        

    }
}
