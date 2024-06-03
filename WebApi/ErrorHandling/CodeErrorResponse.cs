namespace WebApi.ErrorHandling {
    public class CodeErrorResponse {

        public CodeErrorResponse(int statusCode, string message = null) {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        private string GetDefaultMessageStatusCode(int statusCode) {
            return statusCode switch {
                400 => "Received request has errors.",
                401 => "Unauthorized.",
                404 => "The required resource is not available or does not exists.",
                500 => "Server side error.", _ => null 
            };
        }
    }
}
