using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WebApplicationSocialMediaApp.Models;

namespace WebApplicationSocialMediaApp.Data
{
    public class SocialMediaContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options, IConfiguration configuration)
        : base(options) 
        {
            _configuration = configuration;
        }

        public DbSet<Login> Login { get; set; }
    }
}
