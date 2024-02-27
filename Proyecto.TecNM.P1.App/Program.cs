using System;
using MyCompany.Intranet.Core.Entities;
using MyCompany.Intranet.Core.Managers;
using MyCompany.Intranet.Core.Services;


namespace MyCompany.Intranet.Console;

public static class Program {
    public static void Main(string[] args)
    {

        var usuario = new Usuarios();
        List<Transaccion> listtran = new List<Transaccion>();

        int opcion;
        do
        {
            System.Console.Write("Elige una opcion: ");
            System.Console.WriteLine("MENU");
            System.Console.WriteLine("1. Registro de Transacciones");
            System.Console.WriteLine("2. Seguimiento de Saldo y Estado Financiero");
            System.Console.WriteLine("3. Establecimiento de metas y presupuestos");
            System.Console.WriteLine("4. Salir");
            if (!int.TryParse(System.Console.ReadLine(), out opcion))
            {
                System.Console.WriteLine("No es corecto, intenta nuevamente.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    var service = new TranService();
                    var manager = new TranManager(service);
                    listtran = manager.GetTran(usuario, listtran);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;

            }
        } while (opcion != 4);

    }
}