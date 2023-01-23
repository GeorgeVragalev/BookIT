using System.ComponentModel.DataAnnotations;
using System.Globalization;
using CsvHelper.Configuration.Attributes;

namespace Backend.Models;

public class EventModel
{
    public int id { get; set; }
    public string title { get; set; }
    public string? teacher { get; set; }
    public string? subject { get; set; }
    public string? group { get; set; }
    public string? room { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }
}