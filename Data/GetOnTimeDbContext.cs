using GetOnTime.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GetOnTime.Data
{
    public class GetOnTimeDbContext : IdentityDbContext
    {
        public GetOnTimeDbContext
            (DbContextOptions<GetOnTimeDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<Transport> Transports { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<TravellRoute> TravellRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Transport>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transports)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Transport>()
                .HasOne(t => t.Agent)
                .WithMany()
                .HasForeignKey(t => t.AgentId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .Entity<Transport>()
                .HasMany(t => t.Routes)
                .WithOne(r => r.Transport)
                .HasForeignKey(t => t.TransportId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder.Entity<IdentityUser>()
                .HasData(this.AgentUser1,
                         this.AgentUser2);

            SeedAgents();
            builder.Entity<Agent>()
                .HasData(this.Agent1,
                         this.Agent2);

            SeedCategories();
            builder.Entity<Category>()
                .HasData(this.TrainCategory,
                         this.IntercityBusCateory);

            SeedTransports();
            builder.Entity<Transport>()
                .HasData(this.FirstTrain,
                         this.SecondTrain,
                         this.FirstIntercityBus,
                         this.SecondIntercityBus);  

            base.OnModelCreating(builder);
        }

        private IdentityUser AgentUser1 { get; set; }
        private IdentityUser AgentUser2 { get; set; }

        private Agent Agent1 { get; set; }
        private Agent Agent2 { get; set; }

        private Category TrainCategory { get; set; }

        private Category IntercityBusCateory { get; set; }

        private Transport FirstTrain { get; set; }

        private Transport SecondTrain { get; set; }

        private Transport FirstIntercityBus { get; set; }

        private Transport SecondIntercityBus { get; set; }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            this.AgentUser1 = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent1@mail.com",
                NormalizedEmail = "agent1@mail.com"
            };

            this.AgentUser1.PasswordHash = hasher.HashPassword(this.AgentUser1, "agent1123");

            this.AgentUser2 = new IdentityUser()
            {
                Id = "dea22456-c198-4119-b3f3-a893d8325082",
                UserName = "agent2@mail.com",
                NormalizedUserName = "agent2@mail.com",
                Email = "agent2@mail.com",
                NormalizedEmail = "agent2@mail.com"
            };

            this.AgentUser2.PasswordHash = hasher.HashPassword(this.AgentUser2, "agent2123");

        }

        private void SeedAgents()
        {
            this.Agent1 = new Agent()
            {
                Id = 1,
                UserId = this.AgentUser1.Id,
                PhoneNumber = "+359888888888"
            };

            this.Agent2 = new Agent()
            {
                Id = 2,
                UserId = this.AgentUser2.Id,
                PhoneNumber = "+359812331288"
            };
        }

        private void SeedCategories()
        {
            this.TrainCategory = new Category()
            {
                Id = 1,
                Name = "Train"
            };
            
            this.IntercityBusCateory = new Category()
            {
                Id = 2,
                Name = "Intercity-Bus"
            };
        }

        private void SeedTransports()
        {
            this.FirstTrain = new Transport()
            {
                Id = 1,
                Title = "Train 868",
                CategoryId = this.TrainCategory.Id,
                AgentId = this.Agent1.Id
            };

            this.SecondTrain = new Transport()
            {
                Id = 2,
                Title = "Train 21",
                CategoryId = this.TrainCategory.Id,
                AgentId = this.Agent1.Id
            };

            this.FirstIntercityBus = new Transport()
            {
                Id = 3,
                Title = "Avtobus Cveti",
                CategoryId = this.IntercityBusCateory.Id,
                AgentId = this.Agent2.Id
            };

            this.SecondIntercityBus = new Transport()
            {
                Id = 4,
                Title = "Avtobus zalez",
                CategoryId = this.IntercityBusCateory.Id,
                AgentId = this.Agent2.Id
            };
        }
    }
}
