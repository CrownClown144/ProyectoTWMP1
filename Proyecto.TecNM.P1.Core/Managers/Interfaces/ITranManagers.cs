using MyCompany.Intranet.Core.Entities;

namespace MyCompany.Intranet.Core.Managers.Interfaces;

public interface ITranManager{
    
    List<Transaccion> GetTran(Usuarios usuarios, List<Transaccion> list);
    
}
    
