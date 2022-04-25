namespace petro_home_back.Data.Advice
{
    public class ExceptionDict
    {
        bool _isKoLang;

        public ExceptionDict(bool isKoLang = false)
        {
            _isKoLang = isKoLang;
        }

        public void InitLang(string data)
        {
            if (data == "ko")
            {
                _isKoLang = true;
            }
            else
            {
                _isKoLang = false;
            }
        }

        public string GetMessage(int data, bool isKoLang = false)
        {
            _isKoLang = isKoLang;
            if (_isKoLang)
            {
                return GetKoMsg(data);
            }
            else
            {
                return GetEnMsg(data);
            }
        }

        private static string GetKoMsg(int data) => data switch
        {
            ExceptionKoList.UserNotFound =>       ExceptionKoList.UserNotFoundMsg,
            ExceptionKoList.SignInFailed =>       ExceptionKoList.SignInFailedMsg,
            ExceptionKoList.SignUpFailed =>       ExceptionKoList.SignUpFailedMsg,
            ExceptionKoList.EntryPoint =>         ExceptionKoList.EntryPointMsg,
            ExceptionKoList.AccessDenied =>       ExceptionKoList.AccessDeniedMsg,
            ExceptionKoList.CommunicationError => ExceptionKoList.CommunicationErrorMsg,
            ExceptionKoList.ResourceNotExist =>   ExceptionKoList.ResourceNotExistMsg,
            ExceptionKoList.NotOwner =>           ExceptionKoList.NotOwnerMsg,
            ExceptionKoList.ForbiddenWord =>      ExceptionKoList.ForbiddenWordMsg,
            ExceptionKoList.FileUpload =>         ExceptionKoList.FileUploadMsg,
            ExceptionKoList.FileDownload =>       ExceptionKoList.FileDownloadMsg,
            ExceptionKoList.ExpiredUser =>        ExceptionKoList.ExpiredUserMsg,
            _ => ExceptionKoList.UnknownMsg
        };
        private static string GetEnMsg(int data) => data switch
        {
            ExceptionEnList.UserNotFound =>       ExceptionEnList.UserNotFoundMsg,
            ExceptionEnList.SignInFailed =>       ExceptionEnList.SignInFailedMsg,
            ExceptionEnList.SignUpFailed =>       ExceptionEnList.SignUpFailedMsg,
            ExceptionEnList.EntryPoint =>         ExceptionEnList.EntryPointMsg,
            ExceptionEnList.AccessDenied =>       ExceptionEnList.AccessDeniedMsg,
            ExceptionEnList.CommunicationError => ExceptionEnList.CommunicationErrorMsg,
            ExceptionEnList.ResourceNotExist =>   ExceptionEnList.ResourceNotExistMsg,
            ExceptionEnList.NotOwner =>           ExceptionEnList.NotOwnerMsg,
            ExceptionEnList.ForbiddenWord =>      ExceptionEnList.ForbiddenWordMsg,
            ExceptionEnList.FileUpload =>         ExceptionEnList.FileUploadMsg,
            ExceptionEnList.FileDownload =>       ExceptionEnList.FileDownloadMsg,
            ExceptionEnList.ExpiredUser =>        ExceptionEnList.ExpiredUserMsg,
            _ => ExceptionEnList.UnknownMsg
        };
    }
}
