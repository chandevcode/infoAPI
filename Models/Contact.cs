using System;
using System.Diagnostics.Eventing.Reader;

namespace infoApi.Models
{
  public class Contact
  {
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    public string address { get; set; }
  }
}

