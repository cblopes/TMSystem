using TMS.Business.Entities;

namespace TMS.Business.Interfaces;

public interface IPedidoService : IDisposable
{
    Task Adicionar(Pedido pedido);
    Task Remover(int id);
}
