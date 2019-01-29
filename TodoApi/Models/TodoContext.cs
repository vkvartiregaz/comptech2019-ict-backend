using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<MetadataEntry> MetadataEntry { get; set; }
        public DbSet<CollectionItem> CollectionItem { get; set; }
        public DbSet<MetadataSet> MetadataSet { get; set; }
        public DbSet<CollectionContents> CollectionContents { get; set; }

    }
}
