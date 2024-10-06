using TMS.Business.Entities;
using TMS.Business.Interfaces;

namespace TMS.Business.Services;

public class PedidoService : BaseService, IPedidoService
{
    private readonly IPedidoRepository _pedidoRespository;
    private readonly IOcorrenciaRepository _ocorrenciaRepository;

    public PedidoService(IPedidoRepository pedidoRepository, IOcorrenciaRepository ocorrenciaRepository)
    {
        _pedidoRespository = pedidoRepository;
        _ocorrenciaRepository = ocorrenciaRepository;
    }

    public async Task Adicionar()
    {
        var pedido = new Pedido();
        await _pedidoRespository.Adicionar(pedido);
    }

    public async Task Remover(int id)
    {
        var pedido = _pedidoRespository.ObterPedidoOcorrencias(id).Result;
        if (pedido is null)
        {
            Notificar("O pedido informado não existe.");
            return;
        }

        if (pedido.IndCancelado || pedido.IndConcluido)
        {
            Notificar("Não é permitido remover pedidos que já foram cancelados ou concluídos");
            return;
        }

        if (pedido.Ocorrencias?.Count > 0)
        {
            foreach (var ocorrencia in pedido.Ocorrencias)
            {
                await _ocorrenciaRepository.Remover(ocorrencia.IdOcorrencia);
            }
        }

        await _pedidoRespository.Remover(id);
    }

    public void Dispose()
    {
        _pedidoRespository?.Dispose();
    }
}
