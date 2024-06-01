namespace CSharpCleanArch.Domain;
public class Endereco
{
    public string Complemento { get; private set; }
    public string CEP { get; private set; }
    public string Numero { get; private set; }

    public Endereco(string cep, string numero, string complemento)
    {
        this.Complemento = complemento;
        this.Numero = numero;
        this.CEP = cep;
    }
}