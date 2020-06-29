using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Data;
using CodingEventsDemo.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        // GET: /<controller>/
        
        public IActionResult Index()
        {

            //ViewBag.events = EventData.GetAll();

            //return View();

            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventsViewModel addEventViewModel = new AddEventsViewModel();
            return View(addEventViewModel);
        }

        [HttpPost("/events/add")]
        public IActionResult Add(AddEventsViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {


                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    Location = addEventViewModel.Location,
                    Attending = addEventViewModel.Attending,
                    ContactEmail = addEventViewModel.ContactEmail
                };

                EventData.Add(newEvent);

                return Redirect("/events");
            }
            else
            {
                return View(addEventViewModel);
            }
        
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (var eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");

        }

        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.eventToEdit = EventData.GetByID(eventId);
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event edit = EventData.GetByID(eventId);
            edit.Name = name;
            edit.Description = description;
            return Redirect("/Events");
        }





    }

}
