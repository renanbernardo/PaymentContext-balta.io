using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Peter";
            command.LastName = "Parker";
            command.Document = "9999999999";
            command.Email = "hello@teste.com2";
            command.BarCode = "123456789";
            command.BoletoNumber = "123654789";
            command.PaymentNumber = "1254";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Aunt May";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "spiderman@marvel.com";
            command.Street = "wqeqew";
            command.Number = "12";
            command.Neighborhood = "qeqe";
            command.City = "qeqe";
            command.State = "qeeq";
            command.Country = "qeqe";
            command.ZipCode = "99999999";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}