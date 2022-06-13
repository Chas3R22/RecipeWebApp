using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeWebApp.Models;

namespace RecipeWebApp.Data.EntityTypeConfigurations
{
    public class RecipeUsersMappingConfiguration : IEntityTypeConfiguration<RecipeUserMapping>
    {
        public void Configure(EntityTypeBuilder<RecipeUserMapping> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasAlternateKey(uam => new { uam.UserId, uam.RecipeId });

            builder.HasOne(uam => uam.User)
                .WithMany(u => u.RecipeUserMappings)
                .HasForeignKey(uam => uam.UserId);

            builder.HasOne(uam => uam.Recipe)
                .WithMany(a => a.RecipeUserMappings)
                .HasForeignKey(uam => uam.RecipeId);
        }
    }
}
