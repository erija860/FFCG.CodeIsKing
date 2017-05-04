using System;

namespace FFCG.G5.Storage
{
    public class Contact : IStorable
    {
        private Contact()
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