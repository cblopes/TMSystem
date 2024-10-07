using TMS.Business.Entities;

namespace TMS.Api.DTOs;

public class PedidoDTO
{
    public int IdPedido { get; set; }
    public int NumeroPedido { get; set; }
    public DateTime HoraPedido { get; set; }
    public bool IndCancelado { get; set; }
    public bool IndConcluido { get; set; }
}
