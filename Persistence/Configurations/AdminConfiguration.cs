//using Domain;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Configurations
//{
//    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
//    {
//        public void Configure(EntityTypeBuilder<Admin> builder)
//        {
//            builder.HasKey(x => x.Id);
//            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

//            builder.Property(x => x.Email);
//            builder.Property(x => x.Hash);
//            builder.Property(x => x.Salt);
//            builder.Property(x => x.Role);

//            builder.ToTable("Admins");
//        }
//    }
//}
