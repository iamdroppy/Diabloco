namespace Diabloco;

public interface ILanguage
{
    string UnableToResolveHost { get; }
    string UnableToRewriteHost { get; }

    string Enable { get; }
    string Enabled { get; }
 
    string Disable { get; }
    string Disabled { get; }

    string Warning { get; }
}
public class PortugueseLanguage : ILanguage
{
    public string UnableToResolveHost => "Não foi possível encontrar o servidor D3. Por favor, verifique seu DNS ou internet.";

    public string UnableToRewriteHost => "Não foi possível remover antigos dados do Battle.NET. Verifique se está executando Diabloco como Administrador.";

    public string Enable => "Habilitar";

    public string Enabled => "Habilitado";

    public string Disable => "Desabilitar";

    public string Disabled => "Desabilitado";

    public string Warning => "AVISO: Enquanto habilitado, o Battle.NET não funcionará. Você pode desabilitar o Diabloco para voltar a usar o Battle.NET normalmente.";
}
public class EnglishLanguage : ILanguage
{
    public string UnableToResolveHost => "Could not find the D3 Private Server. Please check your DNS or Internet Connection.";

    public string UnableToRewriteHost => "Could not remove Battle.NET data. Check if you are executing Diabloco as Administrator.";

    public string Enable => "Enable";

    public string Enabled => "Enabled";

    public string Disable => "Disable";

    public string Disabled => "Disabled";

    public string Warning => "WARNING: While enabled, Battle.NET will not work. You can disable Diabloco to use Battle.NET normally.";
}