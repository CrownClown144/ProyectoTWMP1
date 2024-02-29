using Proyecto.TecNM.P1.Core.Entities;

namespace Proyecto.TecNM.P1.Core.Managers.Interfaces;

public interface IEstadoFinancieroManager
{
    
    EstadoFinanciero GetEstadoFinanciero(Transaccion transaccion);
}