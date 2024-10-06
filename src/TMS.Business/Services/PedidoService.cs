using TMS.Business.Entities;
using TMS.Business.Interfaces;

namespace TMS.Business.Services;

public class PedidoService : BaseService, IPedidoService
{
    private readonly IPedidoRepository _pedidoRespository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        _pedidoRespository = pedidoRepository;
    }

    public async Task Adicionar(Pedido pedido)
    {
        await _pedidoRespository.Adicionar(pedido);
    }

    public async Task Remover(int id)
    {
        // TODO: validar se o pedido existe
        // TODO: validar se o pedido não está concluído

        await _pedidoRespository.Remover(id);
    }

    public void Dispose()
    {
        _pedidoRespository?.Dispose();
    }
}
