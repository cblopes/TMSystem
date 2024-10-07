using TMS.Business.Entities;

namespace TMS.Business.Interfaces;

public interface IOcorrenciaRepository : IRepository<Ocorrencia>
{
    Task<IEnumerable<Ocorrencia>> ObterOcorrenciasPorPedido(int pedidoId);
    Task<Ocorrencia> ObterOcorrenciaPedido(int id);
}
