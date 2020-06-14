namespace Ex03_ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageManager gm = new GarageManager();
            StartMenu sm = new StartMenu(gm);
            while(true)
            {
                sm.Show();
            }
        }
    }
}
