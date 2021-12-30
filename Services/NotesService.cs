using Notes.Api.Models;

namespace Notes.Api.Services;

public static class NotesService
{
    static List<Note> Notes { get; }
    static int nextId = 3;
    static DateTime dateCreated = DateTime.Now;
    static NotesService()
    {
        Notes = new List<Note>
        {
            new Note { Id=1, Title="Brush Teeth", Description="BrushMyTeeth", TimeCreated=dateCreated},
            new Note { Id=2, Title="Go To School", Description="Sitt all classes", TimeCreated=dateCreated}
        };
    }

    public static List<Note> GetAll() => Notes;

    public static Note? Get(int id) => Notes.FirstOrDefault(n => n.Id == id);

    public static void Add(Note note)
    {
        note.Id = nextId++;
        Notes.Add(note);
    }

    public static void Delete(int id)
    {
        var note = Get(id);
        if(note is null)
            return;

        Notes.Remove(note);

    }

    public static void Update(Note note)
    {
        var index= Notes.FindIndex(n => n.Id == note.Id);
        if(index == -1)
            return;
        

        Notes[index] = note;
    }
}