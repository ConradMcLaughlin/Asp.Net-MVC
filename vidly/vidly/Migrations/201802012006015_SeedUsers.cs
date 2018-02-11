namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'70c355ba-78ef-45ce-ad0b-0a688c27e90c', N'admin@vidly.com', 0, N'AMQnbABbb0Jrv7QRJ4F6yqHmSxsOTagLlZZckGwlhGvFMH4upDUy/9/D36sKCG648g==', N'0bfe1903-6ca7-42e1-9c7e-ade38fc23bbc', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c5909282-50ed-45ac-88ef-cfd7d7e9a1d9', N'guest@domain.com', 0, N'AE7BuK7fH3MDwXVR6JCT+3xFrfp7HSVZFgCUEN7lDDjH65ODRo2zvPgPQn69V3NH7Q==', N'3492bd57-419e-4ee0-831f-9b3d580fb38e', NULL, 0, 0, NULL, 1, 0, N'guest@domain.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5f0ab886-575c-45a2-a5cf-1488f596425c', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'70c355ba-78ef-45ce-ad0b-0a688c27e90c', N'5f0ab886-575c-45a2-a5cf-1488f596425c')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
