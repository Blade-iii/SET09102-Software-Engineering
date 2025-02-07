using System.Runtime.CompilerServices;

namespace Notes.Views;

public partial class NotesPage : ContentPage
{ 
	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt") ;
	public NotesPage()
	{
		InitializeComponent();

		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

		LoadNote(Path.Combine(appDataPath,randomFileName));
		
		// if (File.Exists(_fileName)){
		// 	TextEditor.Text = File.ReadAllText(_fileName);
		// }
	}

	private void LoadNote(string fileName)
{
    Models.Note noteModel = new Models.Note();
    noteModel.Filename = fileName;

    if (File.Exists(fileName))
    {
        noteModel.Date = File.GetCreationTime(fileName);
        noteModel.Text = File.ReadAllText(fileName);
    }

    BindingContext = noteModel;
}


	private void SaveButton_Clicked(object sender,EventArgs e){
			// Save the file
			File.WriteAllText(_fileName,TextEditor.Text);
		}
	private void DeleteButton_Clicked(object sender,EventArgs e){
		// Delete the file
		if (File.Exists(_fileName)){
			File.Delete(_fileName);
			// Empty the text field
			TextEditor.Text = string.Empty;
		}
	}
}