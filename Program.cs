namespace ProcessAdmin_19._08
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (args.Length == 1 && args[0].Equals("/background"))
                Application.Run(new Admin(false));
            else
                Application.Run(new Admin());
        }
    }
}