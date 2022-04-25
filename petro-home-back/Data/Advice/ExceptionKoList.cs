namespace petro_home_back.Data.Advice
{
    public class ExceptionKoList
    {
        public const int Unknown = -9999;
        public const string UnknownMsg = "알 수 없는 오류가 발생하였습니다.";
        public const int UserNotFound = -1000;
        public const string UserNotFoundMsg = "존재하지 않는 회원입니다.";
        public const int SignInFailed = -1001;
        public const string SignInFailedMsg = "계정이 존재하지 않거나, 비밀번호가 맞지 않습니다.";
        public const int SignUpFailed = -1002;
        public const string SignUpFailedMsg = "이미 등록된 계정입니다.";
        public const int EntryPoint = -1003;
        public const string EntryPointMsg = "해당 리소스에 접근하기 위한 권한이 없습니다.";
        public const int AccessDenied = -1004;
        public const string AccessDeniedMsg = "보유한 권한으로 접근할 수 없는 리소스 입니다.";
        public const int CommunicationError = -1005;
        public const string CommunicationErrorMsg = "통신 중 오류가 발생하였습니다.";
        public const int ResourceNotExist = -1006;
        public const string ResourceNotExistMsg = "리소스가 존재하지 않습니다.";
        public const int NotOwner = -1007;
        public const string NotOwnerMsg = "접근 권한이 없거나, 소유의 리소스가 아닙니다.";
        public const int ForbiddenWord = -1008;
        public const string ForbiddenWordMsg = "입력한 내용에 금칙어({0})가 포함되어 있습니다.";
        public const int FileUpload = -1009;
        public const string FileUploadMsg = "파일 업로드에 실패했습니다.";
        public const int FileDownload = -1010;
        public const string FileDownloadMsg = "파일 다운로드에 실패했습니다.";
        public const int ExpiredUser = -1011;
        public const string ExpiredUserMsg = "로그인이 만료되었습니다.";
    }
}
