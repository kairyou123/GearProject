using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastucture.Context.Config
{
    public class ChiTietGiaoConfig : IEntityTypeConfiguration<CTGiao>
    {
        public void Configure(EntityTypeBuilder<CTGiao> builder)
        {
            builder.HasKey(ct => new
            {
                ct.HDNhapId,
                ct.LinhKienId
            });
            builder.HasOne(ct => ct.HDNhapHang).WithMany(hdnh => hdnh.CTGiaos).HasForeignKey(ct => ct.HDNhapId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ct => ct.LinhKien).WithMany(lk => lk.CTGiaos).HasForeignKey(ct => ct.LinhKienId);
        }
    }
}