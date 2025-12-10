using Microsoft.EntityFrameworkCore;

namespace ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extensions for ModelBuilder.
/// </summary>
/// <remarks>
/// Author: Raul Hiroshi Tasayco Osorio
/// </remarks>
public static class ModelBuilderExtensions
{
    public static void UseSnakeCaseWithPluralizedTableNamingConvention(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()?.ToPlural().ToSnakeCase());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName()?.ToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName()?.ToSnakeCase());
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName()?.ToSnakeCase());
            }
        }
    }
}