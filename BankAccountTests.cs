using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;

namespace BankTest
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            BankAccount account = new BankAccount("Test", beginningBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;

            Assert.AreEqual(expected, actual, 0.001);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Debit_WhenAccountIsFrozen_ShouldThrowException()
        {
            double beginningBalance = 11.99;
            double debitAmount = 100.00;

            BankAccount account = new BankAccount("Test", beginningBalance);

            account.FreezeAccount();

            account.Debit(debitAmount);
        }
        [TestMethod]
        public void Jugador_Constructor_Con_Nombre_InicializaCorrectamente()
        {
            Jugador jugador = new Jugador("Ana");

            Assert.AreEqual("Ana", jugador.Nombre);
            Assert.AreEqual(100, jugador.Vida);
            Assert.AreEqual(0, jugador.Oro);
            Assert.AreEqual(false, jugador.Npc);
            Assert.AreEqual(50, jugador.Resistencia);
        }
        [TestMethod]
        public void Jugador_Constructor_Vacio_InicializaValoresPorDefecto()
        {
            Jugador jugador = new Jugador();

            Assert.AreEqual(null, jugador.Nombre);
            Assert.AreEqual(0, jugador.Vida);
            Assert.AreEqual(0, jugador.Oro);
            Assert.AreEqual(false, jugador.Npc);
            Assert.AreEqual(0, jugador.Resistencia);
        }
        [TestMethod]
        public void Jugador_CambiarNombre_ActualizaCorrectamente()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.CambiarNombre("Luis");

            Assert.AreEqual("Luis", jugador.Nombre);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Jugador_CambiarNombre_Null_LanzaExcepcion()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.CambiarNombre(null);
        }
        [TestMethod]
        public void Jugador_AnadirOro_IncrementaCorrectamente()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.AnadirOro(50);

            Assert.AreEqual(50, jugador.Oro);
        }
        [TestMethod]
        public void Jugador_QuitarOro_ReduceCorrectamente()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.AnadirOro(100);
            jugador.QuitarOro(40);

            Assert.AreEqual(60, jugador.Oro);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Jugador_QuitarOro_MayorQueDisponible_LanzaExcepcion()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.AnadirOro(50);
            jugador.QuitarOro(100);
        }
        [TestMethod]
        public void Jugador_AsignarNPC_CambiaATrue()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.AsignarNPC();

            Assert.AreEqual(true, jugador.Npc);
        }
        [TestMethod]
        public void Jugador_DesasignarNPC_CambiaAFalse()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.AsignarNPC();
            jugador.DesasignarNPC();

            Assert.AreEqual(false, jugador.Npc);
        }
        [TestMethod]
        public void Jugador_AnadirResistencia_AumentaCorrectamente()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.AnadirResistencia();

            Assert.AreEqual(60, jugador.Resistencia);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Jugador_AnadirResistencia_SiendoNPC_LanzaExcepcion()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.AsignarNPC();
            jugador.AnadirResistencia();
        }
        [TestMethod]
        public void Jugador_QuitarResistencia_ReduceCorrectamente()
        {
            Jugador jugador = new Jugador("Ana");

            jugador.QuitarResistencia();

            Assert.AreEqual(40, jugador.Resistencia);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Jugador_QuitarResistencia_ValorInvalido_LanzaExcepcion()
        {
            Jugador jugador = new Jugador();

            jugador.QuitarResistencia();
        }
    }
}