using TMS.Business.Entities;

namespace TMS.Api.DTOs;

public class OcorrenciaDTO
{
    public int IdOcorrencia { get; set; }
    public int IdPedido { get; set; }
    public string? TipoOcorrencia { get; set; }
    public DateTime HoraOcorrencia { get; set; }
    public bool IndFinalizadora { get; set; }
}
