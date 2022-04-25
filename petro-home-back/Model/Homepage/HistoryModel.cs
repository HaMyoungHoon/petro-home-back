namespace petro_home_back.Model.Homepage
{
    public class HistoryModel
    {
        public int history_no { get; set; } = 0;
        public int history_seq_no { get; set; } = 0;
        public int? history_year { get; set; } = null;
        public int? history_month { get; set; } = null;
        public int? history_day { get; set; } = null;
        public string? history_title { get; set; } = null;
        public string? history_file_nm { get; set; } = null;
        public string? history_org_nm { get; set; } = null;
        public string? history_etc1 { get; set; } = null;
        public string? history_etc2 { get; set; } = null;
        public string? history_etc3 { get; set; } = null;
        public string reg_dm { get; set; } = "";
        public string? history_contents { get; set; } = null;
        public string? history_contents_en { get; set; } = null;
    }
}
