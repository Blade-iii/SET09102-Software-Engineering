
namespace Notes;

public partial class App : Application
{
	public App()
	{
    InitializeComponent();

        Routing.RegisterRoute(nameof(Views.NotesPage), typeof(Views.NotesPage));

        MainPage = new AppShell();
	}
}
