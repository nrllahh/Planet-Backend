namespace Planet.Application.Common
{
    public abstract class ResponseBase
    {
        public Header Header { get; set; } = new Header();
        public object Body { get; set; }

    }

    public sealed class Header
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<ValidationMessage> ValidationMessages { get; set; } = new List<ValidationMessage>();
    }

    public class ValidationMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public static class Response
    {
        public static T SuccessWithBody<T>(object body, string message = null) where T : ResponseBase, new()
        {
            var response = Success<T>();
            response.Body = body;
            response.Header.Message = message;
            response.Header.IsSuccess = true;

            return response;
        }

        public static T SuccessWithMessage<T>(string message) where T : ResponseBase, new()
        {
            var response = Success<T>();
            response.Header.Message = message;

            return response;
        }

        public static T Success<T>() where T : ResponseBase, new()
        {
            var response = (T)Activator.CreateInstance(typeof(T));
            response.Header.IsSuccess = true;

            return response;
        }

        public static T Failure<T>(string message) where T : ResponseBase, new()
        {
            var response = (T)Activator.CreateInstance(typeof(T));
            response.Header.IsSuccess = false;
            response.Header.Message = message;

            return response;
        }
    }
}
