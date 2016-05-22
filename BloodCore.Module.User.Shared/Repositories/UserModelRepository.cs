﻿using BloodCore.Module.User.Shared.Models;
using BloodCore.Persistence;
using Dapper;
using System;
using System.Collections.Generic;

namespace BloodCore.Module.User.Shared.Repositories
{
    public class UserModelRepository : Repository
    {
        public IEnumerable<UserModel> Get()
        {
            return Connection.Query<UserModel>(Sql.Select);
        }

        public int Save(UserModel model)
        {
            int affectedRows;
            if (model.Id == 0 || (affectedRows = Update(model)) == 0)
                affectedRows = Insert(model);

            return affectedRows;
        }

        private int Insert(UserModel model)
        {
            model.CreatedAtUtc = DateTime.UtcNow;
            model.UpdatedAtUtc = DateTime.UtcNow;

            return Connection.Execute(Sql.Insert, model);
        }

        private int Update(UserModel model)
        {
            model.UpdatedAtUtc = DateTime.UtcNow;

            return Connection.Execute(Sql.Update, model);
        }

        class Sql
        {
            public static string Select = @"
SELECT
    Id,
    Username,
    Email,
    Salt,
    PasswordHash,
    CreatedAtUtc,
    UpdatedAtUtc
FROM
    users
            ";

            public static string Insert = @"
INSERT INTO
    users
    (Username, Email, Salt, PasswordHash, CreatedAtUtc, UpdatedAtUtc)
VALUES
    (@Username, @Email, @Salt, @PasswordHash, @CreatedAtUtc, @UpdatedAtUtc);
";

            public static string Update = @"
UPDATE
    users
SET
    Username = @Username,
    Email = @Email,
    Salt = @Salt,
    PasswordHash = @PasswordHash,
    CreatedAtUtc = @CreatedAtUtc,
    UpdatedAtUtc = @UpdatedAtUtc
WHERE
    Id = @Id;
";
        }
    }
}
