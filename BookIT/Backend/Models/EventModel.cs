using System.ComponentModel.DataAnnotations;
using System.Globalization;
using CsvHelper.Configuration.Attributes;

namespace Backend.Models;

public class EventModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Teacher { get; set; }
    public string? Subject { get; set; }
    public string? Group { get; set; }
    public string? Room { get; set; }
    
    [DataType(DataType.Date)]  
    [DisplayFormat(DataFormatString="{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode=true)]   
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}