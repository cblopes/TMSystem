using TMS.Business.Interfaces;
using TMS.Business.Notificacoes;

namespace TMS.Business.Services;

public abstract class BaseService
{
    private readonly INotificador _notificador;

    protected BaseService(INotificador notificador)
    {
        notificador = _notificador;
    }

    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }
}
