namespace petro_home_back.Model.Base
{
    public class UserModel
    {
        public string id { get; set; } = "";
        public string pwd { get; set; } = "";
        public string nm { get; set; } = "";
        public int auth { get; set; } = 0;
        public string reg_dm { get; set; } = "";
    }
}
