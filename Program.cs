using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Domain.Exceptions;
using System.Collections;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main()
        {
            List<Titular> listTitular = new List<Titular>();
            Titular titular = new Titular("Malica, Gino");
            listTitular.Add(titular);
            titular = new Titular("Anita, Rivadeo");
            listTitular.Add(titular);

            List<CuentaBancaria> cuentasBancarias = new List<CuentaBancaria>();
            CuentaBancaria cuentaBancaria = new CuentaCorriente("1", 1645561321) { Comision = 0.02M , LimiteDeDescubierto = 100000000, Titulares = listTitular };
            cuentasBancarias.Add(cuentaBancaria);
            listTitular.Clear();
            titular = new Titular("Diaz, Roberto");
            listTitular.Add(titular);
            cuentaBancaria = new CuentaCorriente("2", 16455611){ Comision = 0.07M , LimiteDeDescubierto = 6561000000, Titulares = listTitular};
            cuentasBancarias.Add(cuentaBancaria);
            listTitular.Clear();
            titular = new Titular("Matas, Mario");
            listTitular.Add(titular);
            titular = new Titular("Ramas, Romina");
            cuentaBancaria = new CajaDeAhorro("3", 697881611) { Titulares = listTitular , TasaDeInteres = 5 };
            cuentasBancarias.Add (cuentaBancaria);
            listTitular.Clear();
            titular = new Titular("Canto, Matias");
            listTitular .Add(titular);
            cuentaBancaria = new CajaDeAhorro("4", 2510) { Titulares = listTitular, TasaDeInteres = 2 };
            cuentasBancarias.Add(cuentaBancaria);

            foreach (CuentaBancaria cuentaBancaria1 in cuentasBancarias)
            {
                try
                {
                    cuentaBancaria1.Depositar(5616123);
                    //cuentaBancaria1.Depositar(0);
                    cuentaBancaria1.Retirar(6545451);
                    cuentaBancaria1.Retirar(665);
                    //cuentaBancaria1.Retirar(-5);
                    cuentaBancaria1.Retirar(0);
                    if (cuentaBancaria1 is CajaDeAhorro)
                    {
                        CajaDeAhorro? caja = cuentaBancaria1 as CajaDeAhorro;
                        caja?.AplicarInteres();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                finally
                {

                    var anonimo = new { numero = cuentaBancaria1.Numero, Tipo = cuentaBancaria1.GetType().Name, saldo = cuentaBancaria1.Saldo };
                    Console.WriteLine(anonimo);
                }
            }
        }
    }
}
