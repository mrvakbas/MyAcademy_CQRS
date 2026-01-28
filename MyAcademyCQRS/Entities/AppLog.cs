namespace MyAcademyCQRS.Entities
{
    public class AppLog
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; } = DateTime.Now;
        public string LogLevel { get; set; } = "Info"; 
        public string Module { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? UserName { get; set; }
        public string? AdditionalData { get; set; }
    }
}