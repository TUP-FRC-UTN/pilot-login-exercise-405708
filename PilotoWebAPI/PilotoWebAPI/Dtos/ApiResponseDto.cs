using System.Net;

namespace LoginPilotoApp.Dtos.ResponseApiDto
{
    public class ApiResponseDto<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiResponseDto()
        {
            Success = true;
            StatusCode = HttpStatusCode.OK;
            ErrorMessage = "";

        }


        public void SetError(string errorMessage, HttpStatusCode statusCode)
        {
            Success = false;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}
