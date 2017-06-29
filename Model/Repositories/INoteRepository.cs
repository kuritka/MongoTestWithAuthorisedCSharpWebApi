using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoTest2.Model;
using MongoTest2.Model.Entities;

namespace MongoTest2.Model.Repositories
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllNotes();
        Task<Note>  GetNote(string id);
        Task AddNote(Note item);
         Task<DeleteResult> RemoveNote(string id);
         Task<UpdateResult> UpdateNote(string id, string body);

        // // demo interface - full document update
         //Task<ReplaceOneResult> UpdateNoteDocument(string id, string body);

        // // should be used with high cautious, only in relation with demo setup
         Task<DeleteResult> RemoveAllNotes();
    }

}