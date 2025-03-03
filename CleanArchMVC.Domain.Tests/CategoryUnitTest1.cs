﻿using CleanArchMVC.Domain.Entities;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With invalid State")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage("Id inválido");
        }

        [Fact]
        public void CreateCategory_ShortName_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage($"Nome Inválido. Mínimo de 3 Caracteres");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage($"Nome é requerido");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>();
        }
    }
}
