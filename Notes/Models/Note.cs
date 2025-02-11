namespace Notes.Models;

// In C#, the internal keyword is used to define the accessibility of classes and members, restricting access to code within the same assembly. 
public  class Note
{
    //The question marks after the datatypes in the code above indicate that these properties are all nullable.
    public string? Filename { get; set; }
    public string? Text { get; set; }
    public DateTime? Date { get; set; }
}
