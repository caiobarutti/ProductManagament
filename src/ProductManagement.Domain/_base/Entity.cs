using System;

namespace ProductManagement.Domain._base
{
    public abstract class Entity
    {
        public string Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}