namespace ClassLibrary
{
    public class ResponseDto
    {
        public object Result { get; set; } = null!;
        public bool IsSucceeded { get; set; }=false;
        public string message {  get; set; }=string.Empty;
        
    }
}
