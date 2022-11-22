namespace Modul14.Dto
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public short Status { get; set; }
    }
}
