using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TMS.Api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected bool OperacaoValida() 
    {
        return true;
    }

    protected ActionResult CustomResponse(object result = null)
    {
        if (OperacaoValida())
        {
            return new ObjectResult(result);
        }

        return BadRequest(new
        {

        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!ModelState.IsValid) { }
        return CustomResponse();
    }

    protected void NotificarErro(string mensagem)
    {

    }
}
