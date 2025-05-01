using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {

        public decimal LimiteDeDescubierto { get; set; }

        public decimal Comision { get; set; }

        public CuentaCorriente(string numero, decimal saldo)
            : base(numero, saldo)
        {
        }
        public override void Depositar(decimal monto)
        {
            monto -= monto * Comision;
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
            if (Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
            }

            if (Saldo - monto <= -LimiteDeDescubierto)
            {
                Estado = Estado.Suspendida;
                throw new Exceptions.SaldoInsuficiente();
            }


            if (monto<=0)
            {
                throw new Exceptions.MontoNoValido();
            }

            if (Estado != Estado.Activa)
            {
                throw new Exceptions.CuentaNoActiva(Estado.ToString());
            }

       
        }

    }
}
