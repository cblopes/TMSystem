using TMS.Business.Entities;
using TMS.Business.Interfaces;

namespace TMS.Business.Services;

public class OcorrenciaService : BaseService, IOcorrenciaService
{
    private readonly IOcorrenciaRepository _ocorrenciaRepository;
    private readonly IPedidoRepository _pedidoRepository;

    public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository,
                             IPedidoRepository pedidoRepository,
                             INotificador notificador) : base(notificador)
    {
        _ocorrenciaRepository = ocorrenciaRepository;
        _pedidoRepository = pedidoRepository;
    }

    public async Task Adicionar(Ocorrencia ocorrencia)
    {
        // TODO: verificar se o pedido existe
        var pedido = _pedidoRepository.ObterPedidoOcorrencias(ocorrencia.IdPedido).Result;
        if (pedido is null) 
        {
            Notificar("Pedido informado não existe.");
            return;
        }

        // TODO: verificar se o pedido já foi concluído
        if (pedido.IndCancelado || pedido.IndConcluido)
        {
            Notificar("Pedido concluído ou cancelado. Inclusão inválida.");
            return;
        }

        // TODO: verificar tipo da última ocorrência e se foi cadastrada há mais de 10 minutos
        var ultimaOcorrencia = pedido.Ocorrencias?.OrderByDescending(x => x.HoraOcorrencia).FirstOrDefault();

        if (ultimaOcorrencia?.TipoOcorrencia == ocorrencia.TipoOcorrencia)
        {
            var diferenca = ocorrencia.HoraOcorrencia.Subtract(ultimaOcorrencia.HoraOcorrencia);
            if (diferenca.TotalMinutes <= 10)
            {
                Notificar("Ocorrência cadastrada há menos de 10 minutos.");
                return;
            }
        }

        if (ocorrencia.TipoOcorrencia == TipoOcorrencia.Entregue)
        {
            ocorrencia.IndFinalizadora = true;
            pedido.IndConcluido = true;
        }

        if (ocorrencia.TipoOcorrencia == TipoOcorrencia.AvariaProduto ||
            ocorrencia.TipoOcorrencia == TipoOcorrencia.Cancelado)
        {
            ocorrencia.IndFinalizadora = true;
            pedido.IndCancelado = true;
        }

        if (ocorrencia.TipoOcorrencia == TipoOcorrencia.ClienteAusente)
        {
            var tentativas = pedido.Ocorrencias?
                .Select(x => x.TipoOcorrencia == TipoOcorrencia.ClienteAusente).ToList().Count() + 1;

            if (tentativas == 3)
            {
                ocorrencia.IndFinalizadora = true;
                pedido.IndCancelado = true;
            }
        }

        await _ocorrenciaRepository.Adicionar(ocorrencia);
        await _pedidoRepository.Atualizar(pedido);
    }

    public Task Atualizar(Ocorrencia ocorrencia)
    {
        throw new NotImplementedException();
    }

    public async Task Remover(int id)
    {
        // TODO: verificar se a ocorrência existe
        var ocorrencia = _ocorrenciaRepository.ObterOcorrenciaPedido(id).Result;
        if (ocorrencia is null)
        {
            Notificar("Ocorrência informada não existe.");
            return;
        }

        // TODO: verificar se o pedido já foi concluído ou cancelado
        if (ocorrencia.Pedido.IndCancelado || ocorrencia.Pedido.IndConcluido)
        {
            Notificar("Pedido concluído ou cancelado. Exclusão inválida.");
            return;
        }

        // TODO: verificar se o tipo permite que seja excluída
        if (ocorrencia.TipoOcorrencia != TipoOcorrencia.ClienteAusente &&
            ocorrencia.TipoOcorrencia != TipoOcorrencia.RotaEntrega)
        {
            Notificar("Não é permitido excluir este tipo de ocorrência.");
            return;
        }

        await _ocorrenciaRepository.Remover(id);
    }

    public void Dispose()
    {
        _ocorrenciaRepository?.Dispose();
    }
}
