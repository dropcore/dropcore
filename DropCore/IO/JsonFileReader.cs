using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace DropCore.IO
{
    public class JsonFileReader : IDisposable
    {
        public string Path { get; private set; }

        FileStream FileStream { get; set; }
        StreamReader StreamReader { get; set; }
        bool Disposed { get; set; }

        public JsonFileReader(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Could not find JSON file.", path);

            FileStream = File.OpenRead(path);
            StreamReader = new StreamReader(FileStream);
            Path = path;
        }

        public void Dispose()
        {
            if (Disposed)
                throw new ObjectDisposedException(nameof(JsonFileReader));

            GC.SuppressFinalize(this);

            FileStream.Dispose();
            StreamReader.Dispose();

            Disposed = true;
        }

        public JObject Read()
        {
            FileStream.Seek(0, SeekOrigin.Begin);
            var contents = StreamReader.ReadToEnd();

            return JObject.Parse(contents);
        }
    }
}
