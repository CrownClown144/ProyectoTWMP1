using Proyecto.TecNM.P1.Core.Entities;
using Proyecto.TecNM.P1.Core.Managers.Interfaces;
using Proyecto.TecNM.P1.Core.Services.Interfaces;

namespace Proyecto.TecNM.P1.Core.Managers;

public class EstadoFinancieroManager: IEstadoFinancieroManager
{
    private readonly IEstadoFinancieroService _service;

    public EstadoFinancieroManager(IEstadoFinancieroService service)
    {
        _service = service;
    }

    public EstadoFinanciero GetEstadoFinanciero(Transaccion transaccion)
    {
        return _service.processEstadoFinanciero(transaccion);
    }
}