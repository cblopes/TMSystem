using TMS.Business.Entities;
using TMS.Business.Interfaces;

namespace TMS.Business.Services;

public class OcorrenciaService : BaseService, IOcorrenciaService
{
    private readonly IOcorrenciaRepository _ocorrenciaRepository;

    public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository)
    {
        _ocorrenciaRepository = ocorrenciaRepository;
    }

    public async Task Adicionar(Ocorrencia ocorrencia)
    {
        // TODO: verificar se o pedido existe

        // TODO: verificar se o pedido já foi concluído

        // TODO: verificar tipo da última ocorrência e se foi cadastrada há mais de 10 minutos

        await _ocorrenciaRepository.Adicionar(ocorrencia);
    }

    public Task Atualizar(Ocorrencia ocorrencia)
    {
        throw new NotImplementedException();
    }

    public async Task Remover(int id)
    {
        // TODO: verificar se a ocorrência existe

        // TODO: verificar se o pedido já foi concluído ou cancelado

        // TODO: verificar se o tipo permite que seja excluída

        await _ocorrenciaRepository.Remover(id);
    }

    public void Dispose()
    {
        _ocorrenciaRepository?.Dispose();
    }
}
