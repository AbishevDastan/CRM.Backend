using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            //builder.HasKey(ti => ti.Id);
            //builder.Property(ti => ti.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(ti => ti.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(ti => ti.Deadline)
                .IsRequired();

            builder.HasOne(ti => ti.Employee)
                .WithMany(e => e.TaskItems)
                .HasForeignKey(ti => ti.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("TaskItems");
        }
    }
}
