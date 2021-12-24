using MovieAPI;
using MovieAPI.Models;

public class JobRecommendService : IJobRecommendService
{
    private readonly MovieContext _dbContext;
    private readonly IEmailServiceManager _emailServiceManager;
    public JobRecommendService(MovieContext dbContext, IEmailServiceManager emailServiceManager)
    {
        _dbContext=dbContext; 
        _emailServiceManager = emailServiceManager;
    }
    public void ReccuringJob()
    {
        var users = _dbContext.Users.ToList();
        _emailServiceManager.SendEmail("akizhan@gmail.com", "test", "hello!!!!");
    }
}