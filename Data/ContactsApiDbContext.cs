using System;
using infoApi.Models;
using Microsoft.EntityFrameworkCore;
namespace infoApi.Data

{
  public class ContactsApiDbContext : DbContext
  {
    public ContactsApiDbContext()
    {
    }

    public ContactsApiDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
  }
}

