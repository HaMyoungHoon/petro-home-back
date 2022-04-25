using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace petro_home_back.Model.Test
{
    public class TestModelMap
    {
        public TestModelMap(EntityTypeBuilder<TestModel> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.int_data1, x.int_data2 } );
            entityTypeBuilder.Property(x => x.str_data1).IsRequired();
        }
    }
}
