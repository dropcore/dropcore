using FluentMigrator;
using System;

namespace BloodCore.Module.User.Schema.Models.UserModel
{
    [Profile("Test")]
    public class CreateTestUserModels : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Users").Row(new Shared.Models.UserModel
            {
                Username = "Test",
                Email = "test@example.com",
                Salt = "foo",
                PasswordHash = "bar",
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = DateTime.UtcNow,
            });
        }

        public override void Down()
        {
            //
        }
    }
}
