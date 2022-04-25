using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using petro_home_back.Model.Base;
using petro_home_back.Model.Homepage;
using petro_home_back.Repository.Base;

namespace petro_home_back.Service
{
    public partial class HomepageService
    {
        private readonly IRepositoryBase<PopModel> _repoPop;
        private readonly IRepositoryBase<HistoryModel> _repoHistory;
        private readonly IRepositoryBase<UserModel> _repoUser;
        public HomepageService(IRepositoryBase<PopModel> repoPop, IRepositoryBase<HistoryModel> repoHistory, IRepositoryBase<UserModel> repoUser)
        {
            _repoPop = repoPop;
            _repoHistory = repoHistory;
            _repoUser = repoUser;
        }

        public IEnumerable<PopModel> GetDashBoardPopList(int pop_no = 2)
        {
            return _repoPop.FindByCondition(x => x.pop_no == pop_no).OrderByDescending(x => x.pop_num);
        }
        public void InsertDashBoardPopInfo(PopModel popModel)
        {
            _repoPop.Add(popModel);
        }
        public void UpdateDashBoardPopInfo(PopModel popModel)
        {
            _repoPop.Update(popModel);
        }
        public void DeleteDashBoardPopInfo(PopModel popModel)
        {
            _repoPop.Delete(popModel);
        }

        public IEnumerable<PopModel> GetHistoryPopList(int pop_no = 5)
        {
            return _repoPop.FindByCondition(x => x.pop_no == pop_no).OrderByDescending(x => x.pop_num);
        }
        public void InsertHisotryPopInfo(PopModel popModel)
        {
            _repoPop.Add(popModel);
        }
        public void UpdateHisotryPopInfo(PopModel popModel)
        {
            _repoPop.Update(popModel);
        }
        public void DeleteHisotryPopInfo(PopModel popModel)
        {
            _repoPop.Delete(popModel);
        }

        public IEnumerable<PopModel> GetCompanyAboutPopList(int pop_no = 4)
        {
            return _repoPop.FindByCondition(x => x.pop_no == pop_no).OrderBy(x => x.pop_num);
        }
        public void InsertCompanyAboutPopInfo(PopModel popModel)
        {
            _repoPop.Add(popModel);
        }
        public void UpdateCompanyAboutPopInfo(PopModel popModel)
        {
            _repoPop.Update(popModel);
        }
        public void DeleteCompanyAboutPopInfo(PopModel popModel)
        {
            _repoPop.Delete(popModel);
        }

        public HistoryModel? GetHistoryDetailLastSeqNo()
        {
            return _repoHistory.FindAll().OrderByDescending(x => x.history_seq_no).FirstOrDefault();
        }
        public IEnumerable<HistoryModel> GetHistoryDetailList()
        {
            return _repoHistory.FindAll().OrderByDescending(x => x.history_year);
        }
        public void InsertHistoryDetailInfo(HistoryModel historyModel)
        {
            _repoHistory.Add(historyModel);
        }
        public void UpdateHistoryDetailInfo(HistoryModel historyModel)
        {
            _repoHistory.Update(historyModel);
        }
        public void DeleteHistoryDetailInfo(HistoryModel historyModel)
        {
            _repoHistory.Delete(historyModel);
        }

        public UserModel? GetUser(string id)
        {
            return _repoUser.FindByCondition(x => x.id == id).SingleOrDefault();
        }
        public void InsertUser(string id, string pw, string nm)
        {
            var user = new UserModel()
            {
                id = id,
                pwd = pw,
                auth = 1,
                nm = nm,
                reg_dm = DateTime.Now.ToString("yyyyMMdd"),
            };

            _repoUser.Add(user);
        }
    }
}
