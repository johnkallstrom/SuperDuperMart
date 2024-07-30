using Microsoft.EntityFrameworkCore;

namespace SuperDuperMart.Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder RenameIdentityDefaultTables(this ModelBuilder builder)
        {
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRole");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserToken");

            return builder;
        }
    }
}
