namespace Catalog.API.Base
{
    /// <summary>
    /// Class mô tả response trả về chung cho tất cả api
    /// </summary>
    /// <typeparam name="T">Loại đối tượng trả về nếu thành công</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Có thành công hay không
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Tin nhắn trả về client
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Dữ liệu trả về nếu thành công
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Mã lỗi quy định của dự án trả về nếu xảy ra lỗi
        /// </summary>
        public string ErrorCode { get; set; }
    }
}
