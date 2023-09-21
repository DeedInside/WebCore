namespace WebCore.Domain.Response
{
    /// <summary>
    /// class for responding to tasks 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T> : IBaseResponse<T>
    {
        /// <summary>
        /// description response
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// return data
        /// </summary>
        public T Data { get; set; }
    }
    /// <summary>
    /// interface for responding to tasks 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseResponse<T>
    {
        T Data { get; }
    }
}
