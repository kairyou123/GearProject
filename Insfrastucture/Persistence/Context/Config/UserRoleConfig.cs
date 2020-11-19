using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastucture.Context.Config
{
    public class UserRoleConfig : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.HasOne(ur => ur.Role).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.RoleId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
        }
    }
}