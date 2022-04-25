using petro_home_back.Data.Advice.Exceptions;
using petro_home_back.Model.Test;
using petro_home_back.Repository.Base;

namespace petro_home_back.Service
{
    public class MsSQLService
    {
        private readonly IMSRepository<TestModel> _test;

        public MsSQLService(IMSRepository<TestModel> test)
        {
            _test = test;
        }

        public IEnumerable<TestModel> GetModelAll()
        {
            return _test.FindAll();
        }
        public IEnumerable<TestModel> GetModel(int int_data1, int int_data2)
        {
            return _test.FindByCondition(x => x.int_data1 == int_data1 && x.int_data2 == int_data2);
        }
        public void InsertModel(int int_data1, int int_data2, string str_data1, string? str_data2)
        {
            _test.Add(new TestModel()
            {
                int_data1 = int_data1,
                int_data2 = int_data2,
                str_data1 = str_data1,
                str_data2 = str_data2,
            });
        }
        public void UpdateModel(int int_data1, int int_data2, string str_data1, string? str_data2)
        {
            _test.Update(new TestModel()
            {
                int_data1 = int_data1,
                int_data2 = int_data2,
                str_data1 = str_data1,
                str_data2 = str_data2,
            });
        }
        public void DeleteModel(int int_data1, int int_data2)
        {
            var model = _test.FindByCondition(x => x.int_data1 == int_data1 && x.int_data2 == int_data2).ToList();
            if (model == null || model?.Count <= 0)
            {
                throw new ResourceNotExistException();
            }

            _test.Delete(model[0]);
        }
    }
}
