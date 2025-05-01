namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{   
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public List<Titular> Titulares { get; set; }



    protected CuentaBancaria(string numero, decimal saldo)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
    }
    public abstract void Depositar(decimal monto); 
    public abstract void Retirar(decimal monto);
}
