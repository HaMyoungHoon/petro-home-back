using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace petro_home_back.Model.Base
{
    public class UserModelMap
    {
        public UserModelMap(EntityTypeBuilder<UserModel> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.id);
            entityTypeBuilder.Property(x => x.pwd).IsRequired();
            entityTypeBuilder.Property(x => x.nm).IsRequired();
            entityTypeBuilder.Property(x => x.auth).IsRequired();
            entityTypeBuilder.Property(x => x.reg_dm).IsRequired();
        }
    }
}
