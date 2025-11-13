namespace mtg.Api.Controllers.Dto
{
    public record RegistrarUsuarioDto
    {
        public string Nome { get; set; } = string.Empty;    
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

    }
}
