using System.ComponentModel.DataAnnotations;
using TMS.Business.Entities;

namespace TMS.Api.DTOs;

public class OcorrenciaPostDTO
{
    [Required]
    public int IdPedido { get; set; }
    [Required]
    public string? TipoOcorrencia { get; set; }
}
