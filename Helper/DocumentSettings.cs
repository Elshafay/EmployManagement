namespace Demo.PL.Helper
{
    public class DocumentSettings
    {
        public static string UploudFiles(IFormFile file , string FolderName)
        {
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Files",FolderName);

            var FileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            var FilePath = Path.Combine(FolderPath, FileName);

            using var FileStream = new FileStream(FilePath, FileMode.Create);

            file.CopyTo(FileStream);

            return Path.Combine("Files/Images",FileName);

        }
    }
}
