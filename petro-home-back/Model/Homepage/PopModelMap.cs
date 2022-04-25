using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace petro_home_back.Model.Homepage
{
    public class PopModelMap
    {
        public PopModelMap(EntityTypeBuilder<PopModel> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.pop_no, x.pop_num });
        }
    }
}
