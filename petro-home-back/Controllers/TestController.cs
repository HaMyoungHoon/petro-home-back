using Microsoft.AspNetCore.Mvc;
using petro_home_back.Model.Response;
using petro_home_back.Model.Test;
using petro_home_back.Repository.Base;
using petro_home_back.Service;

namespace petro_home_back.Controllers
{
    [ApiController]
    [Route("v1/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly FileService _fileService;
        private readonly ResponseService _responseService;
        private readonly MsSQLService _sqlService;
        public TestController(FileService fileService, MsSQLService sqlService)
        {
            _fileService = fileService;
            _responseService = new();
            _sqlService = sqlService;
        }

        [HttpPost]
        public CommonResult FileUploadTest(IFormFile file)
        {
            _fileService.SaveFile(file);
            return _responseService.GetSuccessResult();
        }

        [HttpGet]
        public ListResult GetAll()
        {
            return _responseService.GetListResult(_sqlService.GetModelAll());
        }

        [HttpGet]
        public ListResult GetModel([FromQuery] int int_data1, [FromQuery] int int_data2)
        {
            return _responseService.GetListResult(_sqlService.GetModel(int_data1, int_data2));
        }

        [HttpPost]
        public CommonResult InsertModel([FromForm] int int_data1, [FromForm] int int_data2, [FromForm] string str_data1, [FromForm] string? str_data2)
        {
            _sqlService.InsertModel(int_data1, int_data2, str_data1, str_data2);

            return _responseService.GetSuccessResult();
        }

        [HttpPut]
        public CommonResult UpdateModel([FromForm] int int_data1, [FromForm] int int_data2, [FromForm] string str_data1, [FromForm] string? str_data2)
        {
            _sqlService.UpdateModel(int_data1, int_data2, str_data1, str_data2);

            return _responseService.GetSuccessResult();
        }

        [HttpDelete]
        public CommonResult DeleteModel([FromForm] int int_data1, [FromForm] int int_data2)
        {
            _sqlService.DeleteModel(int_data1, int_data2);
            return _responseService.GetSuccessResult();
        }
    }
}
