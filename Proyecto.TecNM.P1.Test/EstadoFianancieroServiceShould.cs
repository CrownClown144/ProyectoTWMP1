using Proyecto.TecNM.P1.Core.Entities;
using Proyecto.TecNM.P1.Core.Services;

namespace Proyecto.TecNM.P1.Test;

public class EstadoFianancieroServiceShould
{
    [Fact]
    public void
        ProcesoEstadoFinancieroDebeRegistrarTransaccionConMontoDe_500_Y_DevolverGastoDe_0_IngresoDe_500_SaldoDe_500()
    {
        //Arrange
        var saldoExpected = 500.0;
        var ingresoExpected = 500.0;
        var GastoExpected = 0.0;
        var service = new EstadoFinancieroService();
        var transaccion = new Transaccion {Monto = 500, Tipo = "Ingreso", Categoria = "Prueba", Concepto = "PagoPrueba"};
        
        //Act
        var resultado = service.processEstadoFinanciero(transaccion);
        
        //Assert
        Assert.Equal(saldoExpected, resultado.Saldo);
        Assert.Equal(ingresoExpected, resultado.Ingresos);
        Assert.Equal(GastoExpected, resultado.Gastos);
    }
    
    [Fact]
    public void ActualizarResumenDebeCalcularCorrectamenteSaldoAlIngresar_200_YRetirar_100()
    {
        // Arrange
        var expected = 100.0f;
        var service = new EstadoFinancieroService();
        var transaccion = new Transaccion {Monto = 200, Tipo = "Ingreso", Categoria = "Prueba", Concepto = "PagoPrueba"};
        var transaccion2 = new Transaccion {Monto = 100, Tipo = "Retiro", Categoria = "Prueba", Concepto = "PagoPrueba"};

        // Act
        service.processEstadoFinanciero(transaccion);
        service.processEstadoFinanciero(transaccion2);
        var result = service.obtenerSaldo();

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void ObtenerPresupuestoMensualDebeRetornarElPresupuestoMensualCorrectoSiSeEstableceEn_1000()
    {
        // Arrange
        var expected = 1000.0f;
        var service = new EstadoFinancieroService();
        service.establecerPresupuestoMensual(1000.0f);

        // Act
        var resultado = service.obtenerPresupuestoMensual();

        // Assert
        Assert.Equal(expected, resultado);
    }

    [Fact]
    public void ObtenerMetaFinancieraDebeRetornar_50000_AlLlamarEstablecerMetaFinancieraCon_50000()
    {
        // Arrange
        var expected = 50000.0f;
        var service = new EstadoFinancieroService();
        service.establecerMetaFinanciera(50000.0f);

        // Act
        var resultado = service.obtenerMetaFinanciera();

        // Assert
        Assert.Equal(expected, resultado);
    }
    
    [Fact]
    public void EliminarIngresoDebeEstablecerEstadoPresupuestoEnCero()
    {
        // Arrange
        var expected = 0.0f;
        var service = new EstadoFinancieroService();
        service.agregarIngreso(200.0f);

        // Act
        service.eliminarIngreso();
        var result = service.obtenerMedidorDeIngreso();

        // Assert
        Assert.Equal(expected, result);
    }
}
