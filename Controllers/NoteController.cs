using Notes.Api.Models;
using Notes.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    public NoteController()
    {

    }

    //GET all

    [HttpGet]
    public ActionResult<List<Note>> GetAll() => 
        NotesService.GetAll();
    //GET by Id
    [HttpGet("{id}")]
    public ActionResult<Note> Get(int id) 
    {
        var note = NotesService.Get(id);

        if(note == null)
        {
            return NotFound();
        }

        return note;
    }
    //POST
    [HttpPost]
    public IActionResult Create(Note note)
    {
        note.TimeCreated = DateTime.Now;
        NotesService.Add(note);
        return CreatedAtAction(nameof(Create), new { id = note.Id}, note);
    }
    //PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Note note)
    {
        if (id != note.Id)
        {
            return BadRequest();
        }

        var existingNote = NotesService.Get(id);
        if(existingNote is null)
        {
            return NotFound();
        }
        note.TimeCreated = DateTime.Now;
        NotesService.Update(note);
        return NoContent();
    }

    //DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var note = NotesService.Get(id);

        if (note is null)
        {
            return NotFound();
        }

        NotesService.Delete(id);

        return NoContent();

    }
}   