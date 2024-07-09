using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RESTSample.Infrastructure
{

    public class DeviceInteractionContext : DbContext
    {
        public DbSet<DeviceInteraction> DeviceInteraction { get; set; }

        public DeviceInteractionContext(DbContextOptions<DeviceInteractionContext> options) : base(options)
        {
        }
    }
    [Table("device_interactions")]
    public class DeviceInteraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }
        [Column("name", TypeName = "varchar(200)")]
        [Required]
        public required string Name { get; set; }
    }

}