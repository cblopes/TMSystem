using TMS.Business.Entities;

namespace TMS.Business.Interfaces;

public interface IPedidoService : IDisposable
{
    Task Adicionar();
    Task Remover(int id);
}
