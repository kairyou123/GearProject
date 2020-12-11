using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastucture.Context.Config
{
    public class ChiTietHDConfig : IEntityTypeConfiguration<ChiTietHD>
    {
        public void Configure(EntityTypeBuilder<ChiTietHD> builder)
        {
            builder.HasOne(ct => ct.LinhKien).WithMany(lk => lk.ChiTietHDs).HasForeignKey(ct => ct.LinhKienId);
            builder.HasOne(ct => ct.HoaDon).WithMany(hd => hd.ChiTietHDs).HasForeignKey(ct => ct.HoaDonId);
        }
    }
}