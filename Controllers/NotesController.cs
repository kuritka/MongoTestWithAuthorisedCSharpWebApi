using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoTest2.Data;
using MongoTest2.Data.Repositories;
using MongoTest2.Data.Entities;
using Newtonsoft.Json;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace MongoTest2.Controllers
{
//    [Authorize]
    [Route("api/[controller]")]    
    public class NotesController : Controller
    {
        private readonly INoteRepository _noteRepository;
        private readonly  ILoggerFactory _loggerFactory;

        public NotesController(INoteRepository noteRepository, ILoggerFactory loggerFactory)
        {
            _noteRepository = noteRepository;
            _loggerFactory = loggerFactory;
        }

        // GET: notes/notes
        [HttpGet]
        public Task<string> Get()
        {
            return GetNoteInternal();
        }

        private async Task<string> GetNoteInternal()
        {
            var notes = await _noteRepository.GetAllNotes();
            return JsonConvert.SerializeObject(notes);
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return GetNoteByIdInternal(id);
        }

        private async Task<string> GetNoteByIdInternal(string id)
        {
            var note = await _noteRepository.GetNote(id) ?? new Note();
            return JsonConvert.SerializeObject(note);
        }

        // POST api/notes
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _noteRepository.AddNote(new Note() { Body = value, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now   }); //, Id = ObjectId.GenerateNewId().ToString()  });
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
            _noteRepository.UpdateNote(id, value);
        }

        // DELETE api/notes/5
        public void Delete(string id)
        {
            _noteRepository.RemoveNote(id);
        }


        [HttpGet("throw")]
        public void Throw(string id)
        {

            var auditLog = _loggerFactory.CreateLogger("AuditLog");
            auditLog.LogInformation("Message  For  AUDIT");

            var systemLog = _loggerFactory.CreateLogger("SystemLog");
            systemLog.LogError("MessageForSystemLog");
            

            var fileLog = _loggerFactory.CreateLogger("FileSystemLog");
            fileLog.LogError("I didn't forgot  file! ");

        }

    }
}