using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TMS.Api.DTOs;
using TMS.Business.Interfaces;

namespace TMS.Api.Controllers;

[Route("api/pedidos")]
public class PedidosController : MainController
{
    private readonly IPedidoService _pedidoService;
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IMapper _mapper;

    public PedidosController(IPedidoRepository pedidoRepository,
                             IMapper mapper,
                             IPedidoService pedidoService,
                             INotificador notificador) : base(notificador)
    {
        _pedidoService = pedidoService;
        _pedidoRepository = pedidoRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PedidoDTO>> ObterTodos()
    {
        return _mapper.Map<IEnumerable<PedidoDTO>>(await _pedidoRepository.ObterTodos());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PedidoDTO>> ObterPorId(int id)
    {
        var pedido = await ObterPedido(id);

        if (pedido == null) return CustomResponse(HttpStatusCode.NotFound);

        return CustomResponse(HttpStatusCode.OK, pedido);
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar()
    {
        await _pedidoService.Adicionar();

        return CustomResponse(HttpStatusCode.Created);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<PedidoDTO>> Excluir(int id)
    {
        var pedido = ObterPedido(id);

        if (pedido == null) return CustomResponse(HttpStatusCode.NotFound);

        await _pedidoService.Remover(id);

        return CustomResponse(HttpStatusCode.NoContent);
    }

    private async Task<PedidoDTO> ObterPedido(int id)
        => _mapper.Map<PedidoDTO>(await _pedidoRepository.ObterPorId(id));
}
