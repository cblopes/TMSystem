using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TMS.Api.DTOs;
using TMS.Business.Entities;
using TMS.Business.Interfaces;

namespace TMS.Api.Controllers;

[Route("api/ocorrencias")]
public class OcorrenciasController : MainController
{
    private readonly IOcorrenciaService _ocorrenciaService;
    private readonly IOcorrenciaRepository _ocorrenciaRepository;
    private readonly IMapper _mapper;

    public OcorrenciasController(IOcorrenciaService ocorrenciaService,
                                 IOcorrenciaRepository ocorrenciaRepository,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
    {
        _ocorrenciaService = ocorrenciaService;
        _ocorrenciaRepository = ocorrenciaRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OcorrenciaDTO>>> ObterTodos()
        => _mapper.Map<IEnumerable<OcorrenciaDTO>>(await _ocorrenciaRepository.ObterTodos()).ToList();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OcorrenciaDTO>> ObterPorId(int id)
    {
        var ocorrencia = await ObterOcorrencia(id);

        if (ocorrencia == null) return CustomResponse(HttpStatusCode.NotFound);

        return CustomResponse(HttpStatusCode.OK, ocorrencia);
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(OcorrenciaPostDTO model)
    {
        if (!ModelState.IsValid) CustomResponse(HttpStatusCode.BadRequest, model);

        var ocorrencia = _mapper.Map<Ocorrencia>(model);
        await _ocorrenciaService.Adicionar(ocorrencia);

        return CustomResponse(HttpStatusCode.Created);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<OcorrenciaDTO>> Excluir(int id)
    {
        var ocorrencia = ObterOcorrencia(id);

        if (ocorrencia == null) return CustomResponse(HttpStatusCode.NotFound);

        await _ocorrenciaService.Remover(id);

        return CustomResponse(HttpStatusCode.NoContent);
    }

    private async Task<OcorrenciaDTO> ObterOcorrencia(int id)
        => _mapper.Map<OcorrenciaDTO>(await _ocorrenciaRepository.ObterPorId(id));
}
