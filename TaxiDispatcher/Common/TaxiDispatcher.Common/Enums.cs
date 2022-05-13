namespace TaxiDispatcher.Common
{
    public static class Enums
    {
        public enum ErrorCode
        {
            ErrUnknown,
            ErrSearch,
            ErrView,
            ErrSave,
            ErrDelete,
            ErrUpload,
            ErrDownload,
            ErrBadId,
            ErrBadGetParam,
            ErrRequiredFields,
            ErrParamNotLoaded,
            ErrLogin
        }
    }
}
