using Contacts.Models.Contacts;
using Contacts.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService _contactsService)
        {
            contactsService = _contactsService;
        }

        public async Task<IActionResult> All()
        {
            var result = await contactsService.GetAllContactsAsync();

            return View(result);
        }

        public async Task<IActionResult> Team()
        {
            var userId = GetUserId();

            var contacts = await contactsService.GetTeamContactsAsync(userId);

            return View(contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddContactViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await contactsService.AddContactAsync(model);

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int contactId)
        {
            var userId = GetUserId();

            var isContactInTeam = await contactsService.HasContactAsync(userId, contactId);

            if (!isContactInTeam)
            {
                var contact = await contactsService.FindContactByIdAsync(contactId);

                if (contact != null)
                {
                    await contactsService.AddContactToTeamAsync(userId, contactId);
                }
            }

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int contactId)
        {
            var userId = GetUserId();

            var isContactInTeam = await contactsService.HasContactAsync(userId, contactId);

            if (isContactInTeam)
            {
                await contactsService.RemoveContactFromTeamAsync(userId, contactId);
            }

            return RedirectToAction("Team");
        }

        public async Task<IActionResult> Edit(int contactId)
        {
            var contact = await contactsService.FindContactByIdAsync(contactId);

            if (!TempData.ContainsKey("contactId"))
            {
                TempData.Add("contactId", contactId);               
            }

            TempData["contactId"] = contactId;


            if (contact == null) 
            { 
                return View("Error");
            }

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddContactViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            var contactId = (int)TempData["contactId"];

            await contactsService.EditContactAsync(model, contactId);

            return RedirectToAction("All");
        }
    }
}
