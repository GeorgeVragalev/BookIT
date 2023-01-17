namespace Backend.Services.DataImport;

public interface ICsvImport
{
    public bool ImportData(string csvFileName);
}