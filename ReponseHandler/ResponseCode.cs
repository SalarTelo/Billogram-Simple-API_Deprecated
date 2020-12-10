namespace Billogram.Handles
{
    public enum ResponseCode
    {
        OK = 200,
        MISSING_AUTH = 401,
        INVALID_AUTH = 403,
        PERMISSION_DENIED = 403,
        NOT_FOUND = 404,
        NOT_AVAILABLE_YET = 404,
        METHOD_NOT_ALLOWED = 405,
        MISSING_QUERY_PARAMETER = 400,
        INVALID_PARAMETER = 400,
        INVALID_PARAMETER_COMBINATION = 400,
        READ_ONLY_PARAMETER = 400,
        UNKNOWN_PARAMETER = 400,
        INVALID_OBJECT_STATE = 400,
        ERROR_INVALID_OR_UNKNOWN_RESPONSE_CODE = 000
    }
}
