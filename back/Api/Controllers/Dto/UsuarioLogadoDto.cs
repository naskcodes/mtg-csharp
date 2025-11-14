namespace mtg.Api.Controllers.Dto;

public class UsuarioLogadoDto
{
    public UsuarioLogadoDto(string nome, string email, string token)
    {
        Nome = nome;
        Email = email;
        Token = token;
    }

    public string Nome { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }   
}

