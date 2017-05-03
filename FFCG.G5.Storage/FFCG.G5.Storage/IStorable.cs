using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FFCG.G5.Storage
{
    public interface IStorable
    {
        string Id { get; }
    }

    public interface IStorage<T> where T : IStorable
    {
        void Store(T item);
        IEnumerable<T> All();
        void Delete(T item);
    }

    public class FileStorage<T> : IStorage<T> where T : IStorable
    {
        private readonly string _folderPath;

        public FileStorage(string folderPath)
        {
            _folderPath = Path.Combine(folderPath, typeof(T).Name + "s");
            Directory.CreateDirectory(_folderPath);
        }

        public void Store(T item)
        {
            var filePath = Path.Combine(_folderPath, item.Id);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(item));
        }

        public IEnumerable<T> All()
        {
            var files = Directory.GetFiles(_folderPath);
            return files.Select(file => JsonConvert.DeserializeObject<T>(File.ReadAllText(file))).ToList();
        }

        public void Delete(T item)
        {
            var filePath = Path.Combine(_folderPath, item.Id);
            File.Delete(filePath);
        }
    }

    public class Contact : IStorable
    {
        public Contact()
        {
        }

        public Contact(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString("N");
        }

        public string Name { get; set; }

        public string Id { get; set; }
    }
}