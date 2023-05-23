namespace CPU
{
    public static class FileReader
    {
        public static T ReadFromFile<T>(string path, Func<string, T> converter)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File not found at path {path}");
            }

            string content = File.ReadAllText(path);

            return converter(content);
        }
    }
}
