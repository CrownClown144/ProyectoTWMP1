using System.Reflection.Metadata.Ecma335;
using Proyecto.TecNM.P1.Core.Entities;
using Proyecto.TecNM.P1.Core.Managers;
using Proyecto.TecNM.P1.Core.Services;

namespace Proyecto.TecNM.P1.App;

public static class Program
{
    public static void Main(String[] args)
    {
        Program.Menu();
    }

    static void Menu()
    {
        int opcion = 0;
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("=====================================");
            Console.WriteLine("Opciones: ");
            Console.WriteLine("1- Realizar una transacción");
            Console.WriteLine("2- Ver mi resumen financiero");
            Console.WriteLine("3- Mis metas");
            Console.WriteLine("4- salir");
            Console.WriteLine("=====================================");
            Console.Write("Ingresa una opcción: ");

            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    agregarTransaccion();
                    break;
                case 2:
                    verEstadoFinanciero();
                    break;
                case 3:
                    menuMetas();
                    break;
                case 4:
                    Console.WriteLine("Gracias por usar el sistema de finanzas personales. ;)");
                    break;
                default:
                    Console.WriteLine("Ingrese una opccion valida!");
                    return;
            }
        }
    }

    static void agregarTransaccion()
    {
        int opcionTipo = 0;
        string tipo = "";
        float monto = 0.0f;
        var service = new EstadoFinancieroService();
        var manager = new EstadoFinancieroManager(service);
        
        Console.Write("Que tipo de transaccion que vas a realizar? 1.- Ingreso | 2.- Retiro: ");
        int.TryParse(Console.ReadLine(), out opcionTipo);
        
        switch(opcionTipo){
            case 1:
                tipo="Ingreso";
                break;
            case 2:
                tipo="Retiro";
                break;
            default:
                Console.WriteLine("Tipo de transacción incorrecta");
                return;
        }
        
        Console.Write("Ingrese la categoría de la transacción:");
        string categoria = Console.ReadLine();
        if (categoria == null || categoria.Equals("")){
            Console.WriteLine("Debes indicar una categoría para tu transacción");
            return;
        }

        Console.Write("Ingrese el concepto de la transacción:");
        string concepto = Console.ReadLine();
        if (concepto.Equals("") || concepto == null){
            Console.WriteLine("Debes indicar un concepto para tu transacción");
            return;
        }

        try{
            Console.Write("Ingrese el monto de la transacción: ");
            Single.TryParse(Console.ReadLine(), out monto);
            if(monto == null || monto <=  0) {
                Console.WriteLine("Monto invalido");
                return;
            }
        }catch(Exception e){
            Console.WriteLine("Ingrese un valor numerico para el monto");
            return;
        }

        var transaccion = new Transaccion { Monto = monto, Categoria = categoria, Tipo = tipo, Concepto = concepto };
        var estadoFinanciero = manager.GetEstadoFinanciero(transaccion);
        if(service.obtenerPresupuestoMensual() != 0.0 && tipo.Equals("Retiro"))
        {
            service.agregarIngreso(monto);
        }
        Console.WriteLine("");
    }

    static void verEstadoFinanciero()
    {
        var service = new EstadoFinancieroService();

        service.obtenerEstadoFinanciero();
    }

    static void menuMetas()
    {
        int opcion = 0;
        Console.WriteLine("Opciones: ");
        Console.WriteLine("1- Establecer un presupuesto mensual");
        Console.WriteLine("2- Establecer una meta financiera");
        Console.WriteLine("3- Ver el estado de mis metas");
        Console.WriteLine("4- salir");
        Console.Write("Ingresa una opcción: ");

        int.TryParse(Console.ReadLine(), out opcion);

        switch (opcion) {
            case 1:
                establecerPresupuestoMensual();
                break;
            case 2:
                establecerMetaFinanciera();
                break;
            case 3:
                mostrarEstadoMetas();
                break;
            case  4:
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                break;
        }
    }

    static void establecerPresupuestoMensual()
    {
        var service = new EstadoFinancieroService();
        var presupuesto = service.obtenerPresupuestoMensual();
        var nuevoPresupuesto = 0.0f;

        if (presupuesto == 0.0)
        {
            try{
                Console.WriteLine("Digite su presupuesto mensual: ");
                Single.TryParse(Console.ReadLine(), out nuevoPresupuesto);
                if(nuevoPresupuesto == null || nuevoPresupuesto <=  0) {
                    Console.WriteLine("Presupuesto invalido");
                    return;
                }
                service.establecerPresupuestoMensual(nuevoPresupuesto);
            }catch(Exception e){
                Console.WriteLine("Ingrese un valor numerico para su presupuesto");
                return;
            }
        }
        else
        {
            int opccion = 0;
            Console.WriteLine("Ya tienes un presupeusto mensual registrado. ¿Quieres cambiarlo? 1.- si | 2.- No");
            int.TryParse(Console.ReadLine(), out opccion);

            if (opccion == 1)
            {
                float nuevoPresupuestoP = 0.0f;
                Console.WriteLine("Digita tu nuevo presupuesto mensual:");
                Single.TryParse(Console.ReadLine(), out nuevoPresupuestoP);
                if (nuevoPresupuestoP == null || nuevoPresupuestoP < 0)
                {
                    Console.WriteLine("Valor ingresado invalido!");
                    return;
                }
                service.establecerPresupuestoMensual(nuevoPresupuestoP);
                service.eliminarIngreso();
            }
            else if (opccion == 2)
            {
                return;
            }
            else
            {
                Console.WriteLine("Opccion no valida");
                return;
            }
        }
    }
    
    static void establecerMetaFinanciera()
    {
        var service = new EstadoFinancieroService();
        var meta = service.obtenerMetaFinanciera();
        var nuevaMeta = 0.0f;

        if (meta == 0.0)
        {
            try{
                Console.WriteLine("Digite su meta financiera: ");
                Single.TryParse(Console.ReadLine(), out nuevaMeta);
                if(nuevaMeta == null || nuevaMeta <=  0) {
                    Console.WriteLine("Meta invalido");
                    return;
                }
                service.establecerMetaFinanciera(nuevaMeta);
            }catch(Exception e){
                Console.WriteLine("Ingrese un valor numerico para la meta");
                return;
            }
        }
        else
        {
            int opccion = 0;
            Console.WriteLine("Ya tienes una meta financiera registrada. ¿Quieres cambiarla? 1.- si | 2.- No");
            int.TryParse(Console.ReadLine(), out opccion);

            if (opccion == 1)
            {
                float nuevaMetaM = 0.0f;
                Console.WriteLine("Digita tu nueva meta financiera:");
                Single.TryParse(Console.ReadLine(), out nuevaMetaM);
                if (nuevaMetaM == null || nuevaMetaM < 0)
                {
                    Console.WriteLine("Valor ingresado invalido!");
                    return;
                }
                service.establecerMetaFinanciera(nuevaMetaM);
            }
            else if (opccion == 2)
            {
                return;
            }
            else
            {
                Console.WriteLine("Opccion no valida");
                return;
            }
        }
        
    }

    static void mostrarEstadoMetas()
    {
        var service = new EstadoFinancieroService();
        service.obtenerEstadoPresupuestoMensual();
        service.obtenerEstadoMetaFinanciera();
    }
}    