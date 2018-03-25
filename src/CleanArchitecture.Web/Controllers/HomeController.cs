using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Interfaces;
using DDDGuestbook.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Mail;

namespace DDDGuestbook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuestbookRepository _guestbookRepository;
        private readonly IGuestbookService _guestbookService;

        public HomeController(IGuestbookRepository guestbookRepository, IGuestbookService guestbookService)
        {
            _guestbookRepository = guestbookRepository;
            _guestbookService = guestbookService;
        }

        public IActionResult Index()
        {
            if(!_guestbookRepository.List().Any())
            {
                var newGuestbook = new Guestbook() { Name = "My Guestbook" };
                newGuestbook.Entries.Add(new GuestbookEntry { EmailAddress = "steve@deviq.com", Message = "Hi!", DateTimeCreated = DateTime.UtcNow.AddHours(-2) });
                _guestbookRepository.Add(newGuestbook);
            }

            var guestbook = _guestbookRepository.GetById(1);
            var viewModel = new HomePageViewModel();
            viewModel.GuestbookName = guestbook.Name;
            viewModel.PreviousEntries.AddRange(guestbook.Entries);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(HomePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guestbook = _guestbookRepository.GetById(1);
                guestbook.AddEntry(model.NewEntry);
                _guestbookRepository.Update(guestbook);

                model.PreviousEntries.Clear();
                model.PreviousEntries.AddRange(guestbook.Entries);
            }

            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
