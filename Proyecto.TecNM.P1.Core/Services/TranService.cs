using System.Diagnostics;
using MyCompany.Intranet.Core.Entities;
using MyCompany.Intranet.Core.Services.Interfaces;

namespace MyCompany.Intranet.Core.Services;

public class TranService : ITranService
{
    public List<Transaccion> TransaccionLog(Usuarios usuario, List<Transaccion> listtransacciones)
    {
        int opcion = 0;
        int categoria;
        decimal Cantidad;
        do
        {
            Transaccion Trans = new Transaccion();
            Console.WriteLine("MENU");
            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("1. Realizar Ingreso");
            Console.WriteLine("2. Realizar Retiro");
            Console.WriteLine("3. Volver a mostrar opciones");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Esa opcion no es correcta");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Trans.Movimiento = "Ingreso";
                    Console.WriteLine("Categorias Disponibles: ");
                    Console.WriteLine("1. Alimentacion");
                    Console.WriteLine("2. Transporte");
                    Console.WriteLine("3. Vivienda");
                    Console.WriteLine("4. Entretamiento");
                    Console.WriteLine("5. Vestimenta");
                    Console.WriteLine("6. Cuidado y salud");
                    if (!int.TryParse(Console.ReadLine(), out categoria))
                    {
                        Console.WriteLine("Esa opcion no es correcta");
                        continue;
                    }

                    switch (categoria)
                    {
                        case 1:
                            Trans.Categoria = "Alimentacion";
                            break;
                        case 2:
                            Trans.Categoria = "Transporte";
                            break;
                        case 3:
                            Trans.Categoria = "Vivienda";
                            break;
                        case 4:
                            Trans.Categoria = "Entretemimiento";
                            break;
                        case 5:
                            Trans.Categoria = "Vestimenta";
                            break;
                        case 6:
                            Trans.Categoria = "Cuidado y salud";
                            break;
                    }
                    
                    do
                    {
                        Console.WriteLine("Ingresa el monto a ingresar: ");
                        if (!decimal.TryParse(Console.ReadLine(), out Cantidad) || Cantidad < 0)
                        {
                            Console.WriteLine("Esa cantidad no es correcta");
                            continue;
                        }
                    } while (Cantidad < 0);

                    Trans.cantidad = Cantidad;
                    Console.WriteLine("Ingresa el concepto de tu movimiento: ");
                    Trans.Concepto = Console.ReadLine();
                    break;
                
                case 2:
                    Trans.Movimiento = "Retiro";
                    decimal TotalIn = listtransacciones.Where(Trans => Trans.Movimiento == "Ingreso")
                        .Sum(Trans => Trans.cantidad);
                    decimal TotalRe = listtransacciones.Where(Trans => Trans.Movimiento == "Retiro")
                        .Sum(Trans => Trans.cantidad);
                    Console.WriteLine("Categorias Disponibles: ");
                    Console.WriteLine("1. Alimentacion");
                    Console.WriteLine("2. Transporte");
                    Console.WriteLine("3. Vivienda");
                    Console.WriteLine("4. Entretamiento");
                    Console.WriteLine("5. Vestimenta");
                    Console.WriteLine("6. Cuidado y salud");
                    if (!int.TryParse(Console.ReadLine(), out categoria))
                    {
                        Console.WriteLine("Esa opcion no es correcta");
                        continue;
                    }

                    switch (categoria)
                    {
                        case 1:
                            Trans.Categoria = "Alimentacion";
                            break;
                        case 2:
                            Trans.Categoria = "Transporte";
                            break;
                        case 3:
                            Trans.Categoria = "Vivienda";
                            break;
                        case 4:
                            Trans.Categoria = "Entretemimiento";
                            break;
                        case 5:
                            Trans.Categoria = "Vestimenta";
                            break;
                        case 6:
                            Trans.Categoria = "Cuidado y salud";
                            break;
                    }

                    do
                    {
                        Console.WriteLine("Ingresa el monto a retirar: ");
                        if (!decimal.TryParse(Console.ReadLine(), out Cantidad) || Cantidad < 0 || Cantidad > (TotalIn - TotalRe))
                        {
                            Console.WriteLine("Esa cantidad no es correcta");
                            continue;
                        }
                    } while (Cantidad < 0);

                    Trans.cantidad = Cantidad;
                    Console.WriteLine("Ingresa el concepto de tu movimiento: ");
                    Trans.Concepto = Console.ReadLine();
                    break;

            }
            listtransacciones.Add(Trans);
        } while (opcion > 2);

        return listtransacciones;
    }
}