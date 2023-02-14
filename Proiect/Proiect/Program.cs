
using Proiect;

class MainClass
{
    public static void Main(string[] args)
    {
        Service Service = new Service(new AuthRepo("users.txt"), new NoteRepo("notes.txt"));
        UI Ui = new UI(Service);
        Ui.Start();
    }
}