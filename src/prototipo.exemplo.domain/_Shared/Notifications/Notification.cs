namespace Prototipo.Exemplo.Domain._Shared.Notifications;

public class Notification
{
    public Notification(string atriguto, string codigoErro, string mensagem)
    {
        Atributo = atriguto;
        CodigoErro = codigoErro;
        Mensagem = mensagem;
    }

    public string Atributo { get; }
    public string CodigoErro { get; }
    public string Mensagem { get; }
}