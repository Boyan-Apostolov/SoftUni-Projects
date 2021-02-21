namespace P03.StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            StudentData studentSystem = new StudentData();
            while (true)
            {
                studentSystem.ParseCommand();
            }
        }
    }
}
