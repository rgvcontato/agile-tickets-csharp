using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AgileTickets.Web.Models;

namespace Tests.Models
{
    [TestFixture]
    public class SessaoTest
    {
        private Sessao sessao;

        [SetUp]
        public void Inicializa()
        {
            sessao = new Sessao();
        }

        [Test]
        public void DeveVender1IngressoSeHa2Vagas()
        {
            sessao.TotalDeIngressos = 2;
            Assert.IsTrue(sessao.PodeReservar(1));
        }

        [Test]
        public void NaodeveVender3IngressoSeHa2Vagas()
        {
            sessao.TotalDeIngressos = 2;
            Assert.IsFalse(sessao.PodeReservar(3));
        }

        [Test]
        public void ReservarIngressosDeveDiminuirONumeroDeIngressosDisponiveis()
        {
            sessao.TotalDeIngressos = 5;
            sessao.Reserva(3);
            Assert.AreEqual(2, sessao.IngressosDisponiveis);
        }

        [Test]
        public void ReservarTodosOsIngressoDisponiveisEmUmaSesssao()
        {
            sessao.TotalDeIngressos = 1;
            Assert.IsTrue(sessao.PodeReservar(1));
        }

        [Test]
        public void Reservar90IngressoEmSesssaoCom100ReservaDisponivel()
        {
            sessao.TotalDeIngressos = 100;
            Assert.IsTrue(sessao.PodeReservar(90));
        }
    }
}
