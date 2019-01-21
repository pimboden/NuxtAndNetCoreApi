namespace _8anu.Data.Migration.Generators
{
    public interface IGenerator
    {
        string Generate(int maxRows, string staticFileName = "");
        void GenerateSqlFile(string path);
    }
}
