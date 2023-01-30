using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using PhoneOperator.Infra.Context;
using PhoneOperator.Domain.Models;
using PhoneOperator.Infra.Repositories;
using PhoneOperator.Domain.Interfaces;
using System;

namespace PhoneOperator.Test.Infra.Repositories
{
    public class PhoneOperatorRepositoryTest
    {
        [Fact]
        public void Should_Return_Success_GetAllPhoneOperators()
        {
            // Arrange
            var mockContextOptions = new DbContextOptionsBuilder<DatabaseContext>();
            var mockContext = new Mock<DatabaseContext>(mockContextOptions.Options);
            var mockSet = new Mock<DbSet<Operator>>();
            var data = new List<Operator> { new Operator {
                Id = 12321,
                Name = "ASfasdfasdf",
                OperatorCode = 312
             } }.AsQueryable();

            mockSet.As<IQueryable<Operator>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockContext.Setup(m => m.Operators).Returns(mockSet.Object);

            // Act
            var repository = new PhoneOperatorRepository(mockContext.Object);
            // repository.Setup(m => m.GetAllOperators()).Returns(data.ToList());
            var phoneOperators = repository.GetAllOperators();

            // Assert
            Assert.NotNull(phoneOperators);
        }

        [Fact]
        public void Should_Return_Error_GetAllPhoneOperators()
        {
            // Arrange
            var mockContextOptions = new DbContextOptionsBuilder<DatabaseContext>();
            var mockContext = new Mock<DatabaseContext>(mockContextOptions.Options);
            var mockSet = new Mock<DbSet<Operator>>();
            var data = new List<Operator>().AsQueryable();

            mockSet.As<IQueryable<Operator>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockContext.Setup(m => m.Operators).Returns(mockSet.Object);

            // Act
            var phoneRepository = new PhoneOperatorRepository(mockContext.Object);
            var phoneOperators = phoneRepository.GetAllOperators();

            // Assert
            Assert.Empty(phoneOperators);
        }

        [Theory]
        [InlineData(21)]
        public void Should_Return_Success_GetPhoneOperatorById(int id)
        {
            // Arrange
            var data = new Operator()
            {
                Id = 12321,
                Name = "ASfasdfasdf",
                OperatorCode = 312
            };

            // Act
            var repository = new Mock<IPhoneOperatorRepository>();
            repository.Setup(r => r.GetOperatorById(id)).Returns(data);
            var phoneOperators = repository.Object.GetOperatorById(id);

            // Assert
            Assert.NotNull(phoneOperators);
        }

        [Theory]
        [InlineData(21)]
        public void Should_Return_Error_GetPhoneOperatorById(int id)
        {
            // Arrange
            var data = new Operator();

            // Act
            var repository = new Mock<IPhoneOperatorRepository>();
            repository.Setup(r => r.GetOperatorById(id)).Returns(data);
            var phoneOperator = repository.Object.GetOperatorById(id);

            // Assert
            Assert.Equal(0, phoneOperator.Id);
        }

        [Fact]
        public void Should_Return_Success_InsertPhoneOperator()
        {
            // Arrange
            var contextOptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            var mockContext = new Mock<DatabaseContext>(contextOptionsBuilder.Options);
            var mockSet = new Mock<DbSet<Operator>>();
            var data = new List<Operator>
            { new Operator() {
                Id = 21,
                Name = "asdfasdfasdf",
                OperatorCode = 12334,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }}.AsQueryable();

            mockSet.As<IQueryable<Operator>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Operator>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockContext.Setup(m => m.Operators).Returns(mockSet.Object);

            // Act
            var newData = new Operator()
            {
                Id = 22,
                Name = "asdfasdfasdf",
                OperatorCode = 12634,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var repository = new PhoneOperatorRepository(mockContext.Object);
            repository.InsertOperator(newData);

            // Assert
            mockSet.Verify(p => p.Add(It.Is<Operator>(m => m == newData)));
        }
    }
}