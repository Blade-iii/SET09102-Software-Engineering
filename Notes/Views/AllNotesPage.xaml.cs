using System.Collections.ObjectModel;
using System.IO.Enumeration;

namespace Notes.Models;

internal class AllNotes{

	// Object List - ObservableCollection allows the ui to update based on content on the list
	public ObservableCollection<Note> Notes { get;set; } = new ObservableCollection<Note>();
	
	// Constructor - When AllNotes object is created the notes get loaded. 
	public AllNotes() => LoadNotes();

	public void LoadNotes(){

		// Clears the list
		Notes.Clear();

		// Store the notes location in a variable
		string appDataPath = FileSystem.AppDataDirectory;

		// Uses wildcard to store any textfile with notes.txt in it's name that is stored in the app directory
		IEnumerable<Note> notes = Directory.EnumerateFiles(appDataPath,"*.notes.txt")
		
		.Select(filename => new Note{
			Filename = filename,
			Text = File.ReadAllText(filename),
			Date = File.GetLastWriteTime(filename)
		})

		// Order the note collection by date
		.OrderBy(note => note.Date);

		// Add the notes into the collection
		foreach (Note note in notes)
		{
			Notes.Add(note);
		}
	}
}