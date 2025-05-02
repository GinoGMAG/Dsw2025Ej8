
namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {


        public decimal TasaDeInteres { get; init; }

            public CajaDeAhorro(string numero, decimal saldo)
                : base(numero, saldo)
            {
            }

            public override void Depositar(decimal monto)
            {
                if (Estado != Estado.Activa)
                {
                    throw new Exceptions.CuentaNoActiva(Estado.ToString());
                }else if(monto <= 0)
                {
                    throw new Exceptions.MontoNoValido();
                }
                else
                {
                        Saldo += monto;
                }
            }

            public override void Retirar(decimal monto)
            {
                if (monto <= 0)
                {
                    throw new Exceptions.MontoNoValido();
                }else if (Estado != Estado.Activa)
                {
                    throw new Exceptions.CuentaNoActiva(Estado.ToString());
                }else if (monto > Saldo)
                {
                    Estado = Estado.Suspendida;
                    throw new Exceptions.SaldoInsuficiente();
                }else
                {
                    Saldo -= monto;
                }

            }

            public void AplicarInteres()
            {
                Saldo += Saldo * TasaDeInteres;
            }
        }
    
}

