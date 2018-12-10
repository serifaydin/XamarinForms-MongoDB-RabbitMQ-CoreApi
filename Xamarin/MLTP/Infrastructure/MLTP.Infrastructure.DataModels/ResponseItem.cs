namespace MLTP.Infrastructure.DataModels
{
    public class ResponseItem
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Result { get; set; }
    }
}