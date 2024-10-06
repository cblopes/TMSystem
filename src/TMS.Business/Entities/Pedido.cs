namespace TMS.Business.Entities;

public class Pedido
{
    private int _numeroPedido = 1000;

    public int IdPedido { get; set; }
    public int NumeroPedido { get; set; }
    public ICollection<Ocorrencia>? Ocorrencias { get; set; }
    public DateTime HoraPedido { get; set; }
    public bool IndCancelado { get; set; }
    public bool IndConcluido { get; set; }
}
