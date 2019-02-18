using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserModule.Model;

namespace UserModule.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("u_user");
            builder.Property(p => p.PrimaryKey).HasColumnName("primary_key");
            builder.Property(p => p.CreateDate).HasColumnName("create_date").HasColumnType("datetime");
            builder.Property(p => p.CreateBy).HasColumnName("create_by");
            builder.Property(p => p.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");
            builder.Property(p => p.UpdateBy).HasColumnName("update_by");

            builder.Property(p => p.UserName).HasColumnName("user_name");
            builder.Property(p => p.Password).HasColumnName("password");
            builder.Property(p => p.Phone).HasColumnName("phone");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.HeadImage).HasColumnName("head_image");

            builder.Property(p => p.Type).HasColumnName("type");
            builder.Property(p => p.Status).HasColumnName("status");
        }

    }
}
