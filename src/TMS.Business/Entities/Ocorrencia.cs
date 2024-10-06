namespace TMS.Business.Entities;

public class Ocorrencia
{
    public int IdOcorrencia { get; set; }
    public int IdPedido { get; set; }
    public TipoOcorrencia TipoOcorrencia { get; set; }
    public DateTime HoraOcorrencia { get; set; }
    public bool IndFinalizadora { get; set; }

    /* EF Relation */
    public Pedido? Pedido { get; set; }
}
