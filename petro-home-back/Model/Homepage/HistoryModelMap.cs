using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace petro_home_back.Model.Homepage
{
    public class HistoryModelMap
    {
        public HistoryModelMap(EntityTypeBuilder<HistoryModel> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.history_no, x.history_seq_no });
        }
    }
}
