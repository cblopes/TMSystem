namespace TMS.Business.Entities;

public class Pedido
{
    public Pedido(int id, int numeroPedido, DateTime horaPedido, List<Ocorrencia> ocorrencias, bool cancelado, bool concluido)
    {
        IdPedido = id;
        NumeroPedido = numeroPedido;
        HoraPedido = horaPedido;
        Ocorrencias = ocorrencias;
        IndCancelado = cancelado;
        IndConcluido = concluido;
    }

    public Pedido()
    {
        Ocorrencias = new List<Ocorrencia>();
        HoraPedido = DateTime.Now;
        IndCancelado = false;
        IndConcluido = false;
    }

    public int IdPedido { get; set; }
    public int NumeroPedido { get; set; }
    public List<Ocorrencia>? Ocorrencias { get; set; }
    public DateTime HoraPedido { get; set; }
    public bool IndCancelado { get; set; }
    public bool IndConcluido { get; set; }
}
