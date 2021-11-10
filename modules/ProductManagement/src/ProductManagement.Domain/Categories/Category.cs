using System;
using Volo.Abp.Domain.Entities;

namespace ProductManagement.Categories
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }
                
        protected Category()
        {
        }

        public Category(Guid id) : base(id)
        {
        }
    }
}
