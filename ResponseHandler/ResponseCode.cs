namespace Billogram.Handle
{
    /// <summary>
    /// The following is a list of common errors that can occur when sending request to the server.
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// Requesting succeeded and returned desired response.
        /// </summary>
        OK = 200,

        /// <summary>
        /// The authentication credentials are missing. The request did not include an HTTP Authorization and was rejected. 
        /// This response includes a WWW-Authenticate header indicating to HTTP clients that they need to send HTTP Basic authentication credentials; 
        /// for some HTTP libraries receiving this response first may be expected behavior.
        /// </summary>
        MISSING_AUTH = 401,

        /// <summary>
        /// The API user and key combination used to authenticate is not valid. Either one of them is wrong, or the credentials have been revoked.
        /// </summary>
        INVALID_AUTH = 403,

        /// <summary>
        /// The API user does not have permission to perform the request. 
        /// Authentication succeeded, but the credentials used do not have sufficient permissions to perform the operation.
        /// </summary>
        PERMISSION_DENIED = 403,

        /// <summary>
        /// The request was sent to a specific object of a className, but the object id (ID) specified in the URL does not exist. 
        /// If the ID was obtained from a previous request, the object might have been deleted in the meantime.
        /// </summary>
        NOT_FOUND = 404,

        /// <summary>
        /// The requested object does not exist yet, but is in the process of being created. Try again later.
        /// </summary>
        NOT_AVAILABLE_YET = 404,

        /// <summary>
        /// The request used a HTTP method not allowed for the resource. Ensure all calls made correspond to those documented here.
        /// </summary>
        METHOD_NOT_ALLOWED = 405,

        /// <summary>
        /// When performing a search/filter request, a required query parameter was missing. 
        /// This may include the field specification for the missing parameter.
        /// </summary>
        MISSING_QUERY_PARAMETER = 400,

        /// <summary>
        /// When performing a search/filter request, a query parameter was given an invalid value. 
        /// This typically includes the field specification for the incorrect parameter.
        /// </summary>
        INVALID_PARAMETER = 400,

        /// <summary>
        /// A field in the request JSON data has an invalid value, wrong type or out of range. 
        /// This error is caused by the request not adhering to the schema of the object structure, and can always be avoided by the client application.
        /// This typically includes the field specification for the incorrect parameter.
        /// </summary>
        INVALID_PARAMETER_COMBINATION = 400,

        /// <summary>
        /// An illegal combination of fields were given in the JSON. 
        /// Either two fields were specified together when they may not occur together or a set of fields that must always occur together was missing one or more.
        /// </summary>
        READ_ONLY_PARAMETER = 400,

        /// <summary>
        /// A read-only parameter was given a value. These may never be given a value when the client application sends data to the Billogram API, they only contain information from the Billogram API to the client.
        /// This typically includes the field specification for the offending parameter.
        /// </summary>
        UNKNOWN_PARAMETER = 400,

        /// <summary>
        /// A field with an unknown name was given in the JSON. Check that the JSON only contains legal fields, and check the spelling of all field names.
        /// This typically includes the field specification, naming the unknown parameter.
        /// </summary>
        INVALID_OBJECT_STATE = 400,

        /// <summary>
        /// Invalid or unknown response code.
        /// </summary>
        ERROR_INVALID_OR_UNKNOWN_RESPONSE_CODE = 000
    }
}
