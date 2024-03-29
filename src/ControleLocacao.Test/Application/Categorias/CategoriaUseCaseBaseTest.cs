﻿using AutoFixture;
using ControleLocacao.Domain.Ports;
using Moq;

namespace ControleLocacao.Test.Application.UseCases.Categorias
{
    public abstract class CategoriaUseCaseBaseTest<TUseCase>
    {
        protected Mock<ICategoriaService> _service = new();
        protected TUseCase _useCase;
        protected Fixture _fixture = new();
        protected const int ID_CATETORIA = 1;

        public CategoriaUseCaseBaseTest()
        {
            Setup();
        }

        protected abstract void Setup();

    }
}
