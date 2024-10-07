using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using TMS.Business.Interfaces;
using TMS.Business.Notificacoes;

namespace TMS.Api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotificador _notificador;

    protected MainController(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected bool OperacaoValida() 
    {
        return !_notificador.TemNotificacao();
    }

    protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
    {
        if (OperacaoValida())
        {
            return new ObjectResult(result)
            {
                StatusCode = Convert.ToInt32(statusCode),
            };
        }

        return BadRequest(new
        {
            errors = _notificador.ObterNotificacoes().Select(x => x.Mensagem)
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!ModelState.IsValid) 
            NotificarModelStateInvalida(modelState);

        return CustomResponse();
    }

    protected void NotificarModelStateInvalida(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(x => x.Errors);
        foreach (var erro in erros)
        {
            var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotificarErro(erroMsg);
        }
    }
    protected void NotificarErro(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }
}
