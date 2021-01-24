using System.Collections.Generic;

namespace E_Commerce_API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
            
        }
        public IEnumerable<string> Errors { get; set; }
    }
}