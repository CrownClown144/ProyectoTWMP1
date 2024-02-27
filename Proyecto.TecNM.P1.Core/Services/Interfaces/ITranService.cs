using MyCompany.Intranet.Core.Entities;

namespace MyCompany.Intranet.Core.Services.Interfaces;


public interface ITranService {
    List<Transaccion> TransaccionLog(Usuarios usuario, List<Transaccion> listtransacciones);
}