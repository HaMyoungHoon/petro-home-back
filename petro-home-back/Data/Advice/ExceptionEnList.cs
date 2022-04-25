namespace petro_home_back.Data.Advice
{
    public class ExceptionEnList
    {
        public const int Unknown = -9999;
        public const string UnknownMsg = "an unknown error has occurred.";
        public const int UserNotFound = -1000;
        public const string UserNotFoundMsg = "this member not exist.";
        public const int SignInFailed = -1001;
        public const string SignInFailedMsg = "your account does not exist or password incorrect.";
        public const int SignUpFailed = -1002;
        public const string SignUpFailedMsg = "this account is already registered.";
        public const int EntryPoint = -1003;
        public const string EntryPointMsg = "you do not have permission to access this resource.";
        public const int AccessDenied = -1004;
        public const string AccessDeniedMsg = "a resource that can not be accessed with the privileges it has.";
        public const int CommunicationError = -1005;
        public const string CommunicationErrorMsg = "an error occurred during communication.";
        public const int ResourceNotExist = -1006;
        public const string ResourceNotExistMsg = "not exist resource.";
        public const int NotOwner = -1007;
        public const string NotOwnerMsg = "you do not have access, or you do not own the resource.";
        public const int ForbiddenWord = -1008;
        public const string ForbiddenWordMsg = "forbidden words ({0}) are included in the input.";
        public const int FileUpload = -1009;
        public const string FileUploadMsg = "file upload failed";
        public const int FileDownload = -1010;
        public const string FileDownloadMsg = "file download failed";
        public const int ExpiredUser = -1011;
        public const string ExpiredUserMsg = "login has been expired";
    }
}
