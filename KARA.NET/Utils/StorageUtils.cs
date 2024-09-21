namespace KARA.NET;
public static class StorageUtils
{
    public static string Root
    {
        get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), App.StorageName);
    }

    public static string GetDirectory(string name)
    {
        var directoryPath = Path.Combine(StorageUtils.Root, name);

        if (Directory.Exists(directoryPath) == false)
        {
            Directory.CreateDirectory(directoryPath);
        }

        return directoryPath;
    }

    public static string GetFile(string name)
    {
        var directoryPath = StorageUtils.Root;

        if (Directory.Exists(directoryPath) == false)
        {
            Directory.CreateDirectory(directoryPath);
        }

        return Path.Combine(directoryPath, name);
    }

    public static string GetFile(string directoryName, string fileName)
    {
        var directoryPath = Path.Combine(StorageUtils.Root, directoryName);

        if (Directory.Exists(directoryPath) == false)
        {
            Directory.CreateDirectory(directoryPath);
        }

        return Path.Combine(directoryPath, fileName);
    }
}