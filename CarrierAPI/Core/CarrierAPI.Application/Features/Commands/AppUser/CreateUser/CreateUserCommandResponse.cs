namespace CarrierAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public CreateUserCommandResponse(bool succeeded)
        {
            Succeeded = succeeded;
            Message = succeeded ? "Kullanıcı başarıyla eklendi" : "Kullanıcı ekleme işlemi başarısız oldu";
        }

      
    }
}