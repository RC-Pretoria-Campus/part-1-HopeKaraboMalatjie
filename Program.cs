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

        static void DisplayWelcomeScreen()
        {
            Console.Clear();

            // Display ASCII logo with color
            Console.ForegroundColor = primaryColor;
            Console.WriteLine(asciiLogo);
            Console.ResetColor();

            // Display welcome border
            Console.ForegroundColor = secondaryColor;
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine(" CYBERSECURITY AWARENESS BOT - Your guide to staying safe online ");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.ResetColor();
        }

        static void GetUserName()
        {
            // Ask for user's name with proper validation
            bool validName = false;

            while (!validName)
            {
                Console.ForegroundColor = highlightColor;
                Console.Write("\nPlease enter your name: ");
                Console.ResetColor();

                userName = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.ForegroundColor = warningColor;
                    Console.WriteLine("I didn't quite catch that. Could you please provide your name?");
                    Console.ResetColor();
                }
                else
                {
                    validName = true;

                    // Personalized greeting with typing effect
                    Console.ForegroundColor = primaryColor;
                    TypeWriteEffect($"\nGreat to meet you, {userName}! I'm here to help you learn about cybersecurity.\n");
                    Console.ResetColor();
                }
            }
        }

        static void MainLoop()
        {
            bool exit = false;

            while (!exit)
            {
                DisplayMainMenu();
                string userInput = GetUserInput();

                switch (userInput.ToLower())
                {
                    case "1":
                        PasswordSafetyTips();
                        break;
                    case "2":
                        PhishingAwarenessTips();
                        break;
                    case "3":
                        SafeBrowsingTips();
                        break;
                    case "help":
                        DisplayHelp();
                        break;
                    case "exit":
                        exit = ConfirmExit();
                        break;
                    default:
                        HandleInvalidInput(userInput);
                        break;
                }

                if (!exit)
                {
                    Console.ForegroundColor = secondaryColor;
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }

            // Goodbye message
            Console.ForegroundColor = highlightColor;
            TypeWriteEffect($"\nThank you for using the Cybersecurity Awareness Bot, {userName}! Stay safe online!");
            Console.ResetColor();
            Thread.Sleep(2000);
        }

        static void DisplayMainMenu()
        {
            Console.Clear();

            // Display ASCII art header again
            Console.ForegroundColor = primaryColor;
            Console.WriteLine(asciiLogo);
            Console.ResetColor();

            // Display personalized greeting
            Console.ForegroundColor = highlightColor;
            Console.WriteLine($"Hello, {userName}! What would you like to learn about today?\n");
            Console.ResetColor();

            // Display menu options with formatting
            Console.ForegroundColor = secondaryColor;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║           MAIN MENU               ║");
            Console.WriteLine("╠═══════════════════════════════════╣");
            Console.WriteLine("║ 1. Password Safety                ║");
            Console.WriteLine("║ 2. Phishing Awareness             ║");
            Console.WriteLine("║ 3. Safe Browsing                  ║");
            Console.WriteLine("║                                   ║");
            Console.WriteLine("║ Type 'help' for assistance        ║");
            Console.WriteLine("║ Type 'exit' to quit               ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = primaryColor;
            Console.Write("\nYour choice: ");
            Console.ResetColor();
        }

        static string GetUserInput()
        {
            return Console.ReadLine().Trim();
        }

        static void PasswordSafetyTips()
        {
            Console.Clear();

            Console.ForegroundColor = secondaryColor;
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║               PASSWORD SAFETY                     ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = primaryColor;
            TypeWriteEffect($"\n{userName}, here are some important tips for creating and managing secure passwords:\n");
            Console.ResetColor();

            Console.WriteLine("1. Use long passwords (at least 12 characters)");
            Console.WriteLine("2. Include a mix of uppercase, lowercase, numbers, and special characters");
            Console.WriteLine("3. Avoid using personal information in your passwords");
            Console.WriteLine("4. Don't reuse passwords across different accounts");
            Console.WriteLine("5. Consider using a password manager to generate and store complex passwords");
            Console.WriteLine("6. Enable two-factor authentication whenever possible");

            Console.ForegroundColor = warningColor;
            Console.WriteLine("\n⚠ Remember: Never share your passwords with anyone, even if they claim to be from technical support!");
            Console.ResetColor();
        }
