namespace vidly_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2b49e8a5-9e53-4dc1-aced-35e853861aaf', N'admin@vidly.com', 0, N'ABkb6x1pwblpwgvft5uUU3z+6CZsK3rlP54IqDsbItA095Bw/E5jTtICqS9kz177MA==', N'89735d89-e72c-402b-b648-72404716c5c9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e781458c-558d-4f1d-977c-bfd6537b2036', N'guest@vidly.com', 0, N'ABge3OdV3X2K549c9Kfz2DHjfC8TJxpqVjPwoKXrQOYw9b3bfNhTGkcEoOYPkmU9Og==', N'42db903b-d2b0-4c81-a5ce-a09d7f87ddb5', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3fb35908-4f22-4253-933a-da1b5a3319b2', N'CanManageMovies')            
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2b49e8a5-9e53-4dc1-aced-35e853861aaf', N'3fb35908-4f22-4253-933a-da1b5a3319b2')
");
        }
        
        public override void Down()
        {
        }
    }
}
