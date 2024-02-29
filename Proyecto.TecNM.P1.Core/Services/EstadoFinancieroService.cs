using Proyecto.TecNM.P1.Core.Entities;
using Proyecto.TecNM.P1.Core.Services.Interfaces;

namespace Proyecto.TecNM.P1.Core.Services;

public class EstadoFinancieroService: IEstadoFinancieroService
{
    private static float metaMensual = 0.0f;
    private static float metaFinanciera = 0.0f;
    public static List<Transaccion> transacciones = new List<Transaccion>();

    public void obtenerEstadoFinanciero()
    {
        var saldo = 0.0f;
        var gastos = 0.0f;
        var ingresos = 0.0f;
        foreach (var transaccion in transacciones)
        {
            if (transaccion.Tipo.Equals("Ingreso"))
            {
                saldo += transaccion.Monto;
                ingresos += transaccion.Monto;
            }
            else
            {
                saldo -= transaccion.Monto;
                gastos += transaccion.Monto;
            }
        }
        Console.WriteLine("");
        Console.WriteLine("================ Resumen Financiero =======================");
        Console.WriteLine("Tu saldo actual es: " + saldo);
        Console.WriteLine("Tus ingresos son: " + ingresos);
        Console.WriteLine("Tus gastos son: " + gastos);
        Console.WriteLine("");
        Console.WriteLine("************* Ultimos movimientos *************");
        foreach (var transaccion in transacciones)
        {
            Console.WriteLine($"Tipo de movimieto: {transaccion.Tipo} - Monto: {transaccion.Monto} - Categoria: {transaccion.Categoria} - Concepto: {transaccion.Concepto}");
        }
        Console.WriteLine("");
    }

    public void establecerMetaMensual(float meta)
    {
        metaMensual = meta;
    }

    public void establecerMetaFinanciera(float meta)
    {
        metaFinanciera = meta;
    }

    public float obtenerMetaMensual()
    {
        return metaMensual;
    } 
    
    public float obtenerMetaFinanciera()
    {
        return metaFinanciera;
    } 
    
    public void obtenerEstadoMetaMensual()
    {
        var saldo = 0.0f;
        foreach (var transaccion in transacciones)
        {
            if (transaccion.Tipo.Equals("Ingreso"))
            {
                saldo += transaccion.Monto;
            }
            else
            {
                saldo -= transaccion.Monto;
            }
        }

        var porcentajeMensual = saldo / metaMensual * 100;
        
        Console.WriteLine("");
        Console.WriteLine("================ Progreso de meta mensual =======================");
        if (porcentajeMensual < 100)
        {
            Console.WriteLine($"Haz recaudado un total de ${saldo} de ${metaMensual}");
            Console.WriteLine($"Total alcanzado: {porcentajeMensual}%");
        }
        else
        {
            Console.WriteLine($"Haz logrado tu meta Mensual con un total de ${saldo} de ${metaMensual}!");
            Console.WriteLine($"Total alcanzado: {porcentajeMensual}%");
        }
        Console.WriteLine("");
    }
    
    public void obtenerEstadoMetaFinanciera()
    {
        var saldo = 0.0f;
        foreach (var transaccion in transacciones)
        {
            if (transaccion.Tipo.Equals("Ingreso"))
            {
                saldo += transaccion.Monto;
            }
            else
            {
                saldo -= transaccion.Monto;
            }
        }

        var porcentajeFinanciera = saldo / metaFinanciera * 100;
        
        Console.WriteLine("");
        Console.WriteLine("================ Progreso de meta financiera =======================");
        if (porcentajeFinanciera < 100)
        {
            Console.WriteLine($"Haz recaudado un total de ${saldo} de ${metaFinanciera}");
            Console.WriteLine($"Total alcanzado: {porcentajeFinanciera}%");
        }
        else
        {
            Console.WriteLine($"Haz logrado tu meta Mensual con un total de ${saldo} de ${metaFinanciera}!");
            Console.WriteLine($"Total alcanzado: {porcentajeFinanciera}%");
        }
        Console.WriteLine("");
    }

    public float obtenerSaldo()
    {
        var saldo = 0.0f;
        
        foreach (var transaccion in transacciones)
        {
            if (transaccion.Tipo.Equals("Ingreso"))
            {
                saldo += transaccion.Monto;
            }
            else
            {
                saldo -= transaccion.Monto;
            }
        }

        return saldo;
    }
    public EstadoFinanciero processEstadoFinanciero(Transaccion transaccion)
    {
        var estado = new EstadoFinanciero();
        var saldoAux = obtenerSaldo();
        if (transaccion.Tipo.Equals("Retiro") && transaccion.Monto > saldoAux)
        {
            Console.WriteLine("No tienes fondos suficientes!");
        }
        else
        {
            transacciones.Add(new Transaccion
            {
                Monto = transaccion.Monto, Categoria = transaccion.Categoria, Concepto = transaccion.Concepto,
                Tipo = transaccion.Tipo
            });
            if (transaccion.Tipo.Equals("Ingreso"))
            {
                estado.Saldo += transaccion.Monto;
                estado.Ingresos += transaccion.Monto;
            }
            else if (transaccion.Equals("Retiro"))
            {
                estado.Saldo -= transaccion.Monto;
                estado.Gastos += transaccion.Monto;
            }
            
            Console.WriteLine("Transaccion registrada correctamente!");
            Console.WriteLine("");
            return estado;
        }

        return estado;
    }
}