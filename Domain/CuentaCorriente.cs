using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {

        public decimal LimiteDeDescubierto { get; init; }

        public decimal Comision { get; set; }

        public CuentaCorriente(string numero, decimal saldo)
            : base(numero, saldo)
        {
        }
        public override void Depositar(decimal monto)
        {
            if (monto <= 0)
            {
                throw new Exceptions.MontoNoValido();
            }else if (Estado != Estado.Activa)
            {
                throw new Exceptions.CuentaNoActiva(Estado.ToString());
            }else
            {
                monto -= monto * Comision;
                Saldo += monto;
            }

        }
        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
            {
                throw new Exceptions.MontoNoValido();
            }else if (Saldo - monto <= -LimiteDeDescubierto)
            {
                Estado = Estado.Suspendida;
                throw new Exceptions.SaldoInsuficiente();
            }else if (Estado != Estado.Activa)
            {
                throw new Exceptions.CuentaNoActiva(Estado.ToString());
            }else
            {
                Saldo -= monto;
            }
       
        }

    }
}
