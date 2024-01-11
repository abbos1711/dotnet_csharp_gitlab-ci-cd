using dosLogistic.API.Models.Foundations.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dosLogistic.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public void ConfigureUserEmail(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}
