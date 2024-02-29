using Proyecto.TecNM.P1.Core.Entities;

namespace Proyecto.TecNM.P1.Core.Services.Interfaces;

public interface IEstadoFinancieroService
{
    EstadoFinanciero processEstadoFinanciero(Transaccion transaccion);
}