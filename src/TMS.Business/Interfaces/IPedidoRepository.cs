using TMS.Business.Entities;

namespace TMS.Business.Interfaces;

public interface IPedidoRepository : IRepository<Pedido>
{
    Task<Pedido> ObterPedidoOcorrencias(int id);
}
