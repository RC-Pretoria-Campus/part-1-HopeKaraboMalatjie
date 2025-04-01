using System;
using System.Media;
using System.Threading;
using System.IO;



namespace CybersecurityAwarenessBot
{
    class Program
    {
        // ASCII art logo for the cybersecurity bot
        static string asciiLogo = @"
  ██████╗██╗   ██╗██████╗ ███████╗██████╗     ██████╗  ██████╗ ████████╗
██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██╔═══██╗╚══██╔══╝
██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝    ██████╔╝██║   ██║   ██║   
██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗    ██╔══██╗██║   ██║   ██║   
╚██████╗   ██║   ██████╔╝███████╗██║  ██║    ██████╔╝╚██████╔╝   ██║   
 ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚═════╝  ╚═════╝    ╚═╝   

";

        // Colors for better UI
        static ConsoleColor primaryColor = ConsoleColor.Cyan;
        static ConsoleColor secondaryColor = ConsoleColor.Yellow;
        static ConsoleColor highlightColor = ConsoleColor.Green;
        static ConsoleColor warningColor = ConsoleColor.Red;

        // User information
        static string userName = "";

        static void Main(string[] args)
        {
            // Play voice greeting
            PlayVoiceGreeting();

            // Display ASCII art and welcome message
            DisplayWelcomeScreen();

            // Get user's name and personalize the experience
            GetUserName();

            // Main interaction loop
            MainLoop();
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                string audioFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "greeting.wav");

                if (!File.Exists(audioFilePath))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: Audio file '{audioFilePath}' not found.");
                    Console.ResetColor();
                    return;
                }

                using (SoundPlayer player = new SoundPlayer(audioFilePath))
                {
                    player.PlaySync(); // Play sound and wait
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error playing voice greeting: {ex.Message}");
                Console.ResetColor();
            }
        }

      