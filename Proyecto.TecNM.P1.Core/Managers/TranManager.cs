using MyCompany.Intranet.Core.Entities;
using MyCompany.Intranet.Core.Managers.Interfaces;
using MyCompany.Intranet.Core.Services.Interfaces;

namespace MyCompany.Intranet.Core.Managers;

public class TranManager : ITranManager {

    private readonly ITranService _service;

    public TranManager(ITranService service){
        _service = service;
    }

    public List<Transaccion> GetTran(Usuarios usuarios, List<Transaccion> list){
        return _service.TransaccionLog(usuarios, list);
    }
    
}