using infoApi.Data;
using infoApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace infoApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class ContactsController : Controller
  {
    private readonly ContactsApiDbContext dbContext;

    public ContactsController(ContactsApiDbContext dbContext)
    {
      this.dbContext = dbContext;

    }
    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
      var contact = await dbContext.Contacts.ToListAsync();
      if (contact != null)
      {
        return Ok(contact);
      }
      return NotFound();
    }
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetContact([FromRoute] Guid id)
    {
      var contact = await dbContext.Contacts.FindAsync(id);
      if (contact == null)
      {
        return NotFound();
      }
      return Ok(contact);
    }
    [HttpPost]
    public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
    {
      var contact = new Contact()
      {
        Id = Guid.NewGuid(),
        Address = addContactRequest.Address,
        FullName = addContactRequest.FullName,
        Phone = addContactRequest.Phone,
        Email = addContactRequest.Email

      };
      await dbContext.Contacts.AddAsync(contact);
      await dbContext.SaveChangesAsync();
      return Ok(contact);

    }
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
    {
      var contact = await dbContext.Contacts.FindAsync(id);
      if (contact != null)
      {
        contact.FullName = updateContactRequest.FullName;
        contact.Address = updateContactRequest.Address;
        contact.Email = updateContactRequest.Email;
        contact.Phone = updateContactRequest.Phone;

        await dbContext.SaveChangesAsync();
        return Ok(contact);

      }
      return NotFound();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
    {
      var contact = await dbContext.Contacts.FindAsync(id);
      if (contact != null)
      {
        dbContext.Remove(contact);
        await dbContext.SaveChangesAsync();
        return Ok(contact);
      }
      return NotFound();
    }
  }
}