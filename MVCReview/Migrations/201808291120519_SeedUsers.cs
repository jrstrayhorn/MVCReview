namespace MVCReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6406082c-f0d1-488b-845c-3968c46d08e9', N'guest@vidly.com', 0, N'AHvCK4TZ7rR3bihYzZHpQVx5I/Z5bXwTYQeWanO8pBUFROQSXD/n/GWdHseK/D6/KA==', N'66159dd1-da47-49e7-9b27-967d520e76f1', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd03a40bc-0f59-42be-a1a5-3feadd7f5d39', N'admin@vidly.com', 0, N'ABuvheCgNlFqfuARi2qvxxRzPn0/BvQZQIoWmcrpIlnV4d8/sVDg809s4z9FB73bPQ==', N'd0c345b7-f30c-4efb-a2d3-07e5253786c8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
         
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'157062c2-b507-428b-ae93-5e6084e45176', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd03a40bc-0f59-42be-a1a5-3feadd7f5d39', N'157062c2-b507-428b-ae93-5e6084e45176')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
