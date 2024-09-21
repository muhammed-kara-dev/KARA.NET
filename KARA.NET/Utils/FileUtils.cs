using System.IO;

namespace KARA.NET;
public static class FileUtils
{
    public static bool IsLocked(string path)
    {
        try
        {
            using var stream = new FileInfo(path).Open(FileMode.Open, FileAccess.Read, FileShare.None);
        }
        catch (IOException)
        {
            return true;
        }
        return false;
    }

    public static FileType GetFileType(string path)
    {
        switch (Path.GetExtension(path).ToLower())
        {
            case ".mp3":
            case ".ogg":
            case ".wav":
                return FileType.Audio;
            default:
                return FileType.File;
            case ".bmp":
            case ".gif":
            case ".jpeg":
            case ".jpg":
            case ".pbm":
            case ".png":
            case ".qoi":
            case ".tga":
            case ".tiff":
            case ".webp":
                return FileType.Image;
            case ".avi":
            case ".flv":
            case ".mp4":
                return FileType.Video;
        }
    }
}