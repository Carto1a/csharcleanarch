namespace CSharpCleanArch.Domain;
public class Endereco
{
    public string complemento { get; private set; }
    public string cep { get; private set; }
    public string numero { get; private set; }

    public Endereco(string cep, string numero, string complemento)
    {
        this.complemento = complemento;
        this.numero = numero;
        this.cep = cep;
    }
}