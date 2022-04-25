using petro_home_back.Data;
using petro_home_back.Data.Advice.Exceptions;

namespace petro_home_back.Service
{
    public class FileService
    {
        private readonly IConfiguration _config;
        public FileService(IConfiguration config)
        {
            _config = config;
        }

        public void SaveDashBoardImage(IFormFile file, out string outImgName)
        {
            string filePath = _config["UploadDir:Inquiry"] + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (file.FileName.Contains('.'))
            {
                filePath += file.FileName[(file.FileName.LastIndexOf('.') + 1)..];
            }
            outImgName = filePath;

            CheckFolder(filePath);
            CheckFile(filePath);
            using (var stream = File.Create(filePath))
            {
                Task.Run(async () => await file.CopyToAsync(stream)).Wait();
            }

            filePath = _config["UploadDir:DashBoard1"] + file.FileName;
            CheckFolder(filePath);
            CheckFile(filePath);
            using (var stream = File.Create(filePath))
            {
                Task.Run(async () => await file.CopyToAsync(stream)).Wait();
            }

            filePath = _config["UploadDir:DashBoard2"] + file.FileName;
            CheckFolder(filePath);
            CheckFile(filePath);
            using (var stream = File.Create(filePath))
            {
                Task.Run(async () => await file.CopyToAsync(stream)).Wait();
            }
        }
        public void SaveHistoryImage(IFormFile file, out string outImgName)
        {
            string filePath = _config["UploadDir:Inquiry"] + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (file.FileName.Contains('.'))
            {
                filePath += file.FileName[(file.FileName.LastIndexOf('.') + 1)..];
            }
            outImgName = filePath;

            CheckFolder(filePath);
            CheckFile(filePath);
            using var stream = File.Create(filePath);
            Task.Run(async () => await file.CopyToAsync(stream)).Wait();
        }
        public void SaveFile(IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            CheckFolder(filePath);
            CheckFile(filePath);

            using var stream = File.Create(filePath);
            Task.Run(async () => await file.CopyToAsync(stream)).Wait();
        }

        public Stream GetInquiryFile(string fileName)
        {
            string filePath = _config["UploadDir:Inquiry"] + fileName;
            if (!CheckFile(filePath))
            {
                throw new ResourceNotExistException();
            }

            var img = File.OpenRead(filePath);
            var stream = new MemoryStream();
            img.CopyTo(stream);
            stream.Position = 0;
            return stream;
        }

        public string ParseMediaType(string fileName)
        {
            int extension = fileName.LastIndexOf('.');
            if (extension == -1)
            {
                return "application/octet-stream";
            }

            return fileName[(extension + 1)..].ToLower() switch
            {
                "aac" => ContentsType.type_aac,
                "abw" => ContentsType.type_abw,
                "arc" => ContentsType.type_arc,
                "avi" => ContentsType.type_avi,
                "azw" => ContentsType.type_azw,
                "bin" => ContentsType.type_bin,
                "bz" => ContentsType.type_bz,
                "bz2" => ContentsType.type_bz2,
                "csh" => ContentsType.type_csh,
                "css" => ContentsType.type_css,
                "csv" => ContentsType.type_csv,
                "doc" => ContentsType.type_doc,
                "epub" => ContentsType.type_epub,
                "gif" => ContentsType.type_gif,
                "htm" => ContentsType.type_htm,
                "html" => ContentsType.type_html,
                "ico" => ContentsType.type_ico,
                "ics" => ContentsType.type_ics,
                "jar" => ContentsType.type_jar,
                "jpeg" => ContentsType.type_jpeg,
                "jpg" => ContentsType.type_jpg,
                "js" => ContentsType.type_js,
                "json" => ContentsType.type_json,
                "mid" => ContentsType.type_mid,
                "midi" => ContentsType.type_midi,
                "mpeg" => ContentsType.type_mpeg,
                "mpkg" => ContentsType.type_mpkg,
                "odp" => ContentsType.type_odp,
                "ods" => ContentsType.type_ods,
                "odt" => ContentsType.type_odt,
                "oga" => ContentsType.type_oga,
                "ogv" => ContentsType.type_ogv,
                "ogx" => ContentsType.type_ogx,
                "pdf" => ContentsType.type_pdf,
                "ppt" => ContentsType.type_ppt,
                "rar" => ContentsType.type_rar,
                "rtf" => ContentsType.type_rtf,
                "sh" => ContentsType.type_sh,
                "svg" => ContentsType.type_svg,
                "swf" => ContentsType.type_swf,
                "tar" => ContentsType.type_tar,
                "tif" => ContentsType.type_tif,
                "tiff" => ContentsType.type_tiff,
                "ttf" => ContentsType.type_ttf,
                "txt" => ContentsType.type_txt,
                "vsd" => ContentsType.type_vsd,
                "wav" => ContentsType.type_wav,
                "weba" => ContentsType.type_weba,
                "webm" => ContentsType.type_webm,
                "webp" => ContentsType.type_webp,
                "woff" => ContentsType.type_woff,
                "xhtml" => ContentsType.type_xhtml,
                "xls" => ContentsType.type_xls,
                "xlsx" => ContentsType.type_xlsx,
                "xlsm" => ContentsType.type_xlsm,
                "xml" => ContentsType.type_xml,
                "xul" => ContentsType.type_xul,
                "zip" => ContentsType.type_zip,
                "3gp" => ContentsType.type_3gp,
                "3g2" => ContentsType.type_3g2,
                "7z" => ContentsType.type_7z,
                _ => "application/octet-stream",
            };
        }
        private bool CheckFolder(string path)
        {
            string temp = path;
            DirectoryInfo filePath = new(path);
            DirectoryInfo di = new(temp.Replace(filePath.Name, ""));

            if (di.Exists == false)
            {
                di.Create();
                return false;
            }

            return true;
        }
        private bool CheckFile(string path)
        {
            if (File.Exists(path) == false)
            {
                using (File.Create(path))
                {

                }

                return false;
            }

            return true;
        }
    }
}
