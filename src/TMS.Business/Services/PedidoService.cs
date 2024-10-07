using TMS.Business.Entities;
using TMS.Business.Interfaces;

namespace TMS.Business.Services;

public class PedidoService : BaseService, IPedidoService
{
    private readonly IPedidoRepository _pedidoRespository;
    private readonly IOcorrenciaRepository _ocorrenciaRepository;

    public PedidoService(IPedidoRepository pedidoRepository, 
                         IOcorrenciaRepository ocorrenciaRepository,
                         INotificador notificador) : base (notificador)
    {
        _pedidoRespository = pedidoRepository;
        _ocorrenciaRepository = ocorrenciaRepository;
    }

    public async Task Adicionar()
    {
        var pedido = new Pedido();

        var ultimoPedido = _pedidoRespository.ObterTodos().Result
            .OrderByDescending(x => x.NumeroPedido)
            .FirstOrDefault();

        pedido.NumeroPedido = ultimoPedido is not null ? ultimoPedido.NumeroPedido + 1 : 1000;

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
            Notificar("Pedido concluído ou cancelado. Exclusão inválida.");
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
