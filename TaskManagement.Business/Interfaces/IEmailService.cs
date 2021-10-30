namespace TaskManagement.Business.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(string email, string role, string message);
    }
}
