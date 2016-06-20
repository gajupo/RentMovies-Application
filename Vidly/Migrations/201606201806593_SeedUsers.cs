namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'19c6985c-5368-44e6-b587-636553141b68', N'admin@vidly.com', 0, N'AFKJQmLfV1lt1Zbnos0R9mbTEdd1jqWy10i2u0piyPiv9wXjlvbgiRB8EEnjmP9gBw==', N'6e01d8bd-41ad-468e-bb69-ed282e338cec', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ef8da80d-0374-439e-a1a8-93ab171cf3e7', N'gues@vidly.com', 0, N'AIeLFvTF77sD8/2uT+umSrJeAEmQTvPcO6YlsYFZt84g8WkOnfrSFEnyjnUF1AosJQ==', N'aa09495e-d949-4557-901d-d1630566bb5a', NULL, 0, 0, NULL, 1, 0, N'gues@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6b31aec4-12a6-420d-93ab-08e375e080f3', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'19c6985c-5368-44e6-b587-636553141b68', N'6b31aec4-12a6-420d-93ab-08e375e080f3')
");
        }
        
        public override void Down()
        {
        }
    }
}
