using TMS.Business.Interfaces;

namespace TMS.Business.Notificacoes;

public class Notificador : INotificador
{
    private List<Notificacao>? _notificacoes;

    public Notificador()
    {
        _notificacoes = new List<Notificacao>();
    }

    public List<Notificacao> ObterNotificacoes()
    {
        return _notificacoes ?? new List<Notificacao>();
    }

    public bool TemNotificacao()
    {
        return _notificacoes.Any();
    }

    public void Handle(Notificacao notificacao)
    {
        _notificacoes?.Add(notificacao);
    }
}
