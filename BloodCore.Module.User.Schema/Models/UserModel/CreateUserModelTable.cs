using FluentMigrator;

namespace BloodCore.Module.User.Schema.Models.UserModel
{
    [Migration(1)]
    public class CreateUserModelTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users")

                .WithColumn("Id")
                    .AsInt64()
                    .NotNullable()
                    .PrimaryKey()
                    .Identity()

                .WithColumn("Username")
                    .AsString(32)
                    .NotNullable()
                    .Unique()

                .WithColumn("Email")
                    .AsString(255)
                    .NotNullable()
                    .Unique()

                .WithColumn("Salt")
                    .AsString(32)
                    .NotNullable()

                .WithColumn("PasswordHash")
                    .AsString(64)
                    .NotNullable()

                .WithColumn("CreatedAtUtc")
                    .AsDateTime()
                    .NotNullable()
                    //.WithDefault(SystemMethods.CurrentUTCDateTime)

                .WithColumn("UpdatedAtUtc")
                    .AsDateTime()
                    .NotNullable();
                    //.WithDefault(SystemMethods.CurrentUTCDateTime);
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}
