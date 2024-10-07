namespace TMS.Business.Entities;

public class Ocorrencia
{
    public Ocorrencia(int id, int idPedido, TipoOcorrencia tipo, bool indFinalizadora)
    {
        IdOcorrencia = id;
        IdPedido = idPedido;
        TipoOcorrencia = tipo;
        HoraOcorrencia = DateTime.Now;
        IndFinalizadora = indFinalizadora;
    }

    public Ocorrencia()
    {
        TipoOcorrencia = TipoOcorrencia.Preparando;
        HoraOcorrencia = DateTime.Now;
        IndFinalizadora = false;
    }

    public int IdOcorrencia { get; set; }
    public int IdPedido { get; set; }
    public TipoOcorrencia TipoOcorrencia { get; set; }
    public DateTime HoraOcorrencia { get; set; }
    public bool IndFinalizadora { get; set; }

    /* EF Relation */
    public Pedido? Pedido { get; set; }
}
