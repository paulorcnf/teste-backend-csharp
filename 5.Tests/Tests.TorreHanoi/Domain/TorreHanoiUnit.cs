using System;
using Infrastructure.TorreHanoi.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.TorreHanoi.Domain
{
    [TestClass]
    public class TorreHanoiUnit
    {
        private const string CategoriaTeste = "Domain/TorreHanoi";

        private Mock<ILogger> _mockLogger;

        [TestInitialize]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
            _mockLogger.Setup(s => s.Logar(It.IsAny<string>(), It.IsAny<TipoLog>()));
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Construtor_Deve_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(4, _mockLogger.Object);

            Assert.IsNotNull(torre);
            Assert.IsNotNull(torre.Id);
            Assert.IsNotNull(torre.Discos);
            Assert.AreEqual(torre.Discos.Count, 4);
            Assert.IsNotNull(torre.Destino);
            Assert.IsNotNull(torre.Intermediario);
            Assert.IsNotNull(torre.Origem);
            Assert.AreEqual(torre.Discos.Count, torre.Origem.Discos.Count);
            Assert.IsNotNull(torre.DataCriacao);
            Assert.IsTrue(torre.DataCriacao > DateTime.MinValue);
            Assert.AreEqual(torre.Status, global::Domain.TorreHanoi.TipoStatus.Pendente);
            Assert.IsNotNull(torre.PassoAPasso);
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Processar_Deverar_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3, _mockLogger.Object);

            torre.Processar();

            Assert.AreEqual(torre.Status, global::Domain.TorreHanoi.TipoStatus.FinalizadoSucesso);
        }
    }
}
