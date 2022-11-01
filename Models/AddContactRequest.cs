using System;
namespace infoApi.Models
{
  public class AddContactRequest
  {
    public AddContactRequest()
    {
    }
    public string FullName { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    public string Address { get; set; }
  }
}

