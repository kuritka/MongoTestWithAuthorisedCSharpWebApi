using System;
using Microsoft.AspNetCore.Mvc;
using MongoTest2.Model;
using MongoTest2.Model.Entities;
using MongoTest2.Model.Repositories;

namespace MongoTest2.Controllers
{
        [Route("api/[controller]")]
        public class SystemController : Controller
        {
            private readonly INoteRepository _noteRepository;

            public SystemController(INoteRepository noteRepository)
            {
                _noteRepository = noteRepository;
            }

            // Call an initialization - api/system/init
            [HttpGet("{setting}")]
            public string Get(string setting)
            {
                if (setting == "init")
                {
                    _noteRepository.RemoveAllNotes();
                    _noteRepository.AddNote(new Note() {  Body = "Test note 1", 
                                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 1 });
                    _noteRepository.AddNote(new Note() {  Body = "Test note 2", 
                                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 1 });
                    _noteRepository.AddNote(new Note() { Body = "Test note 3", 
                                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 2 });
                    _noteRepository.AddNote(new Note() { Body = "Test note 4", 
                                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 2 });

                    return "Done";
                }

                return "Unknown";
            }
        }

}