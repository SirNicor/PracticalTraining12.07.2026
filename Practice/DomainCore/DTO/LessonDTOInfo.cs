namespace DomainCore.DTO;

public class LessonDTOInfo
{
    public int ID { get; set; }
    public TimeOnly DateStart { get; set; }
    public int DayOfWeek { get; set; }
    public int NumberOfWeek { get; set; }
}