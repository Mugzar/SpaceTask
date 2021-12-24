namespace MovieAPI
{
    public interface IEmailServiceManager
    {
        void SendEmail(string receipent, string subject, string text);
    }
}