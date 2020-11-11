using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastucture.Context.Config
{
    public class GioHangConfig : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.HasKey(gh => new
            {
                gh.LinhKienId,
                gh.UserId
            });
            builder.HasOne(gt => gt.User).WithMany(user => user.GioHang).HasForeignKey(gt => gt.UserId);
            builder.HasOne(gt => gt.LinhKien).WithMany(lk => lk.GioHang).HasForeignKey(gt => gt.LinhKienId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}