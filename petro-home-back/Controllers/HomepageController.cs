using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petro_home_back.Model.Homepage;
using petro_home_back.Repository;
using petro_home_back.Service;
using petro_home_back.Model.Response;
using petro_home_back.Data.Security;
using petro_home_back.Data.Advice.Exceptions;

namespace petro_home_back.Controllers
{
    [ApiController]
    [Route("v1/[controller]/[action]")]
    public class HomepageController : ControllerBase
    {
        private readonly JwtTokenProvider _jwtTokenProvider;
        private readonly ResponseService _responseService;
        private readonly HomepageService _homepageService;
        private readonly FileService _fileService;
        private readonly IConfiguration _config;

        public HomepageController(HomepageService homepageRepository, FileService fileService, IConfiguration config)
        {
            _jwtTokenProvider = new(config);
            _responseService = new();
            _homepageService = homepageRepository;
            _fileService = fileService;
            _config = config;
        }

        [HttpGet]
        public ListResult GetDashBoardPopList()
        {
            return _responseService.GetListResult(_homepageService.GetDashBoardPopList());
        }
        [HttpGet]
        public ListResult GetHistoryPopList()
        {
            return _responseService.GetListResult(_homepageService.GetHistoryPopList());
        }
        [HttpGet]
        public ListResult GetHistoryDetailList()
        {
            return _responseService.GetListResult(_homepageService.GetHistoryDetailList());
        }

        [HttpGet]
        public SingleResult SignIn(string id, string pw)
        {
            var user = _homepageService.GetUser(id);
            if (user == null)
            {
                throw new SignInFailedException();
            }
            if (FAES128.Encrypt(pw, _config["Jwt:SecretKey"]) == user.pwd)
            {
                return _responseService.GetSingleResult(_jwtTokenProvider.CreateToken(user));
            }

            throw new SignInFailedException();
        }
        [HttpGet]
        public CommonResult AddUser([FromHeader] string token, string id, string pw, string nm)
        {
            if (!_jwtTokenProvider.IsValidateToken(token))
            {
                throw new AuthenticationEntryPointException();
            }

            pw = FAES128.Encrypt(pw, _config["Jwt:SecretKey"]);
            _homepageService.InsertUser(id, pw, nm);

            return _responseService.GetSuccessResult();
        }

        [HttpPost]
        public CommonResult UpdateDashBoardPopInfo([FromHeader] string token, [FromForm] int pop_num,
            [FromForm] string titleKo, [FromForm] string titleEn,
            [FromForm] string value, IFormFile file,
            [FromForm] string unitKo, [FromForm] string unitEn,
            [FromForm] string contentsKo, [FromForm] string contentsEn)
        {
            if (!_jwtTokenProvider.IsValidateToken(token))
            {
                throw new AccessDeniedException();
            }

            _fileService.SaveDashBoardImage(file, out string outImgName);

            _homepageService.UpdateDashBoardPopInfo(new PopModel()
            {
                pop_no = 2,
                pop_num = pop_num,
                pop_img1_nm = outImgName,
                pop_img1_org_nm = file.FileName,
                pop_name01 = value,
                pop_name02 = unitKo,
                pop_name05 = unitEn,
                pop_nm = titleKo,
                pop_name03 = titleEn,
                pop_contents = contentsKo,
                pop_name04 = contentsEn
            });

            return _responseService.GetSuccessResult();
        }

        [HttpPost]
        public CommonResult InsertHistoryPopList([FromHeader] string token, [FromForm] string title, IFormFile file)
        {
            if (!_jwtTokenProvider.IsValidateToken(token))
            {
                throw new AccessDeniedException();
            }

            _fileService.SaveHistoryImage(file, out string outImgName);

            int lastPopNum = 1;
            var companyAboutPopList = _homepageService.GetHistoryPopList();
            if (companyAboutPopList.Any())
            {
                lastPopNum = companyAboutPopList.First().pop_num + 1;
            }

            _homepageService.InsertHisotryPopInfo(new PopModel()
            {
                pop_no = 5,
                pop_num = lastPopNum,
                pop_img1_nm = outImgName,
                pop_img1_org_nm = file.FileName,
                pop_nm = title,
            });

            return _responseService.GetSuccessResult();
        }
        [HttpPost]
        public CommonResult UpdateHistoryPopList([FromHeader] string token, [FromForm] int pop_num,
            [FromForm] string title, IFormFile file)
        {
            if (!_jwtTokenProvider.IsValidateToken(token))
            {
                throw new AccessDeniedException();
            }

            _fileService.SaveHistoryImage(file, out string outImgName);

            _homepageService.UpdateHisotryPopInfo(new PopModel()
            {
                pop_no = 5,
                pop_num = pop_num,
                pop_img1_nm = outImgName,
                pop_img1_org_nm = file.FileName,
                pop_nm = title,
            });

            return _responseService.GetSuccessResult();
        }
        [HttpPost]
        public CommonResult DeleteHistoryPopList([FromHeader] string token, [FromForm] int pop_num)
        {
            if (!_jwtTokenProvider.IsValidateToken(token))
            {
                throw new AccessDeniedException();
            }

            _homepageService.DeleteHisotryPopInfo(new PopModel()
            {
                pop_no = 5,
                pop_num = pop_num,
            });

            return _responseService.GetSuccessResult();
        }

        [HttpPost]
        public CommonResult UpdateCompanyAboutPopList([FromHeader] string token, [FromForm] int pop_num,
            [FromForm] string title, [FromForm] string value)
        {
            if (!_jwtTokenProvider.IsValidateToken(token))
            {
                throw new AccessDeniedException();
            }

            _homepageService.UpdateCompanyAboutPopInfo(new PopModel()
            {
                pop_no = 4,
                pop_num = pop_num,
                pop_nm = title,
                pop_name01 = value
            });

            return _responseService.GetSuccessResult();
        }


        [HttpPost]
        public CommonResult InsertHistoryDetail([FromHeader] string token, [FromForm] string pop_num, 
            [FromForm] int year, [FromForm] string contentsKo, [FromForm] string contentsEn)
        {
            if (!_jwtTokenProvider.IsValidateToken(token))
            {
                throw new AccessDeniedException();
            }

            int lastSeqNo = 1;
            var companyAboutPopList = _homepageService.GetHistoryDetailLastSeqNo();
            if (companyAboutPopList != null)
            {
                lastSeqNo = companyAboutPopList.history_seq_no;
            }

            _homepageService.InsertHistoryDetailInfo(new HistoryModel()
            {
                history_no = 1,
                history_seq_no = lastSeqNo,
                history_etc1 = pop_num,
                history_year = year,
                history_contents = contentsKo,
                history_contents_en = contentsEn
            });

            return _responseService.GetSuccessResult();
        }
        [HttpPost]
        public CommonResult UpdateHistoryDetail([FromHeader] string token, [FromForm] int seqNo, [FromForm] string pop_num,
            [FromForm] int year, [FromForm] string contentsKo, [FromForm] string contentsEn)
        {
            if (!_jwtTokenProvider.IsValidateToken(token))
            {
                throw new AccessDeniedException();
            }

            _homepageService.UpdateHistoryDetailInfo(new HistoryModel()
            {
                history_no = 1,
                history_seq_no = seqNo,
                history_etc1 = pop_num,
                history_year = year,
                history_contents = contentsKo,
                history_contents_en = contentsEn
            });

            return _responseService.GetSuccessResult();
        }
        [HttpPost]
        public CommonResult DeleteHistoryDetail([FromHeader] string token, [FromForm] int seqNo)
        {
            if (!_jwtTokenProvider.IsValidateToken(token))
            {
                throw new AccessDeniedException();
            }

            _homepageService.DeleteHistoryDetailInfo(new HistoryModel()
            {
                history_no = 1,
                history_seq_no = seqNo,
            });

            return _responseService.GetSuccessResult();
        }

        [HttpGet]
        public FileStreamResult GetViewInquiryFile(string fileName)
        {
//            HttpResponseMessage result = new();

            var stream = _fileService.GetInquiryFile(fileName);
//            result.Content = new StreamContent(stream);
//            result.Content.Headers.ContentDisposition = new("Content-Disposition");
//            result.Content.Headers.ContentDisposition.FileName = fileName;
//            result.Content.Headers.ContentType = new(_fileService.ParseMediaType(fileName));
//            result.Content.Headers.ContentLength = stream.Length;

            return File(stream, _fileService.ParseMediaType(fileName));
        }
    }
}
