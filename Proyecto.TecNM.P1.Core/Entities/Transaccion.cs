namespace MyCompany.Intranet.Core.Entities;

public class Transaccion {
    
    public string Movimiento { get; set; }
    public string Categoria { get; set; }
    public string Concepto { get; set; }
    public decimal cantidad { get; set; }
}