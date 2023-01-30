using Moq;
using Xunit;
using System.Collections.Generic;
using PhoneOperator.Domain.Models;
using PhoneOperator.Domain.Services;
using PhoneOperator.Domain.Interfaces;
using System.Linq;
using System;

namespace PhoneOperator.Test.Domain.Services
{
    public class PhoneOperatorServiceTest
    {
        [Fact]
        public void Should_Return_Success_GetAllPhoneOperators()
        {
            // Arrange
            var mockRepository = new Mock<IPhoneOperatorRepository>();
            var data = new List<Operator> { new Operator {
                Id = 12321,
                Name = "ASfasdfasdf",
                OperatorCode = 312
             } }.AsQueryable();

            mockRepository.Setup(r => r.GetAllOperators()).Returns(data.ToList());

            // Act
            var service = new Mock<IPhoneOperatorService>();
            service.Setup(s => s.GetAllPhoneOperators()).Returns(mockRepository.Object.GetAllOperators());
            var phoneOperators = service.Object.GetAllPhoneOperators();

            // Assert
            Assert.NotNull(phoneOperators);
        }

        [Theory]
        [InlineData(13)]
        public void Should_Return_Success_GetPhoneOperatorById(int id)
        {
            // Arrange
            var mockPhoneOperatorRepository = new Mock<IPhoneOperatorRepository>();
            var data = new Operator()
            {
                Id = 12321,
                Name = "ASfasdfasdf",
                OperatorCode = 312,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            mockPhoneOperatorRepository.Setup(r => r.GetOperatorById(id)).Returns(data);

            // Act
            var phoneOperatorService = new Mock<IPhoneOperatorService>();
            phoneOperatorService.Setup(s => s.GetOperatorById(id)).Returns(mockPhoneOperatorRepository.Object.GetOperatorById(id));
            var phoneOperator = phoneOperatorService.Object.GetOperatorById(id);

            // Assert
            Assert.NotNull(phoneOperator);
        }

        [Fact]
        public void Should_Return_Success_InsertPhoneOperator()
        {
            // Arrange
            var data = new Operator()
            {
                Id = 12321,
                Name = "ASfasdfasdf",
                OperatorCode = 312,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            // Act
            var phoneOperatorService = new Mock<IPhoneOperatorService>();
            phoneOperatorService.Setup(s => s.InsertOperator(data));

            // Act
        }
    }
}