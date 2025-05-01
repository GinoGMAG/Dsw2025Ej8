
namespace Dsw2025Ej8.Domain
{
        public class CajaDeAhorro : CuentaBancaria 
        {


            public decimal TasaDeInteres { get; set; }

            public CajaDeAhorro(string numero, decimal saldo)
                : base(numero, saldo)
            {
            }
            public override void Depositar(decimal monto)
            {
                Saldo += monto;
                if (monto <= 0)
            {
                throw new Exceptions.MontoNoValido();
            }
                if (Estado != Estado.Activa)
            {
                throw new Exceptions.CuentaNoActiva(Estado.ToString());
            }
            }
            public override void Retirar(decimal monto)
            {
                
                Saldo -= monto;
                if (monto <= 0)
                 {
                       throw new Exceptions.MontoNoValido();
                 }
                if (Estado != Estado.Activa)
                 {
                     throw new Exceptions.CuentaNoActiva(Estado.ToString());
                 }

                if (monto > Saldo)
                {
                    Estado = Estado.Suspendida;
                    throw new Exceptions.SaldoInsuficiente();
                }
            }
            public void AplicarInteres()
            {
                Saldo += Saldo * TasaDeInteres;
            }
        }
    
}

