namespace petro_home_back.Service
{
    public partial class HomepageService
    {
        private const string SELECT_DASH_BOARD_POP_LIST = "SELECT " +
            "pop_num, " +
            "pop_img1_org_nm AS pop_img, " +
            "pop_name01 AS pop_value, " +
            "pop_name02 AS ko_unit, " +
            "pop_name05 AS en_unit, " +
            "pop_nm AS ko_title, " +
            "pop_contents AS ko_contents, " +
            "pop_name03 AS en_title, " +
            "pop_name04 AS en_contents " +
            "FROM ssipec.pop " +
            "WHERE pop_no = 2 " +
            "ORDER BY pop_num";
        private const string SELECT_HISTORY_POP_LIST = "SELECT " +
            "pop_num, " +
            "pop_img1_org_nm AS pop_img, " +
            "pop_name01 AS pop_value, " +
            "pop_name02 AS ko_unit, " +
            "pop_name05 AS en_unit, " +
            "pop_nm AS ko_title, " +
            "pop_contents AS ko_contents, " +
            "pop_name03 AS en_title, " +
            "pop_name04 AS en_contents " +
            "FROM ssipec.pop " +
            "WHERE pop_no = 5 " +
            "ORDER BY pop_num DESC";

        private const string SELECT_HISOTRY_DETAIL_LIST = "SELECT " +
            "history_seq_no, " +
            "history_etc1, " +
            "history_year, " +
            "history_contents AS ko_contents, " +
            "history_contents_en AS en_contents " +
            "FROM ssipec.history " +
            "ORDER BY history_year DESC";
    }
}
