using TMS.Business.Entities;

namespace TMS.Business.Interfaces;

public interface IOcorrenciaService : IDisposable
{
    Task Adicionar(Ocorrencia ocorrencia);
    Task Atualizar(Ocorrencia ocorrencia);
    Task Remover(int id);
}
