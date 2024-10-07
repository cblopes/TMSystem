using TMS.Business.Interfaces;
using TMS.Business.Notificacoes;

namespace TMS.Business.Services;

public abstract class BaseService
{
    private readonly INotificador _notificador;

    public BaseService(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }
}
