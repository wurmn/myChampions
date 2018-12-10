using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace myChampions
{

    // *************************************************************
    // Title: My Champions
    // Description: This program will allow you to compile a Marvel COC team and show the rankings of the team.
    // Application Type: Console
    // Author: Nolan Wurm
    // Dated Created: 12/2/18
    // Last Modified: 12/4/18
    // *************************************************************

        // split, turns into an array of indevid properties, then put into object 
        // static list<Champion> ReadChampFromFile(string datafile)
        //      const char delineator = ',';
        //      List<string> ChampStringList = new List<string>();
        //      List<Champ> champclasslist = new list<Champ>();
        //      Champ tempChampion = new character();
        //  ForEACH IS A STRING NOT VAR
        //
    public class Champion
    {
        public enum ChampionAwake {  NO, YES }
        public string ChampName { get; set; }
        public string ChampClass { get; set; }
        public string ChampRank { get; set; }
        public ChampionAwake ChampAwake { get; set; }


    }

    class Program
    {

        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMainMenu();
          //  DisplayChampList();
          //  DisplayGetMyTeam();
           // DisplayTeamRanking();
            DisplayClosingScreen();            
        }

        static void DisplayMainMenu()
        {        

            {
                bool runApplication = true;
                string userMenuChoice;
                List<Champion> champions = null;

                string dataPath = @"Data\ExcelChamp.cvs";
                string dataInfo;
                dataInfo = File.ReadAllText(dataPath);
                Console.WriteLine(dataInfo);

                champions = InitializeListofChampions();

                while (runApplication)
                {
                    DisplayHeader("Main Menu");
                    //Display Main Menu

                    Console.WriteLine("A) Display The List of Champions");
                    Console.WriteLine("B) Enter the Members of your team");
                    Console.WriteLine("C) Show the ranking and class of your champion");
                    Console.WriteLine("D) Exit");
                    Console.WriteLine();
                    Console.Write("Enter Menu Choice: ");
                    userMenuChoice = Console.ReadLine().ToUpper();

                    //Process Menu Choice

                    switch (userMenuChoice)
                    {
                        case "A":
                            DisplayChampList();
                            break;
                        case "B":
                            DisplayGetMyTeam(dataInfo);
                            break;
                        case "C":
                            DisplayTeamRanking();
                            break;
                        case "D":
                            runApplication = false;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Please enter the letter for a menu choice.");

                            DisplayContinuePrompt();
                            break;
                    }
                }
            }
        }

        static List<Champion> DisplayGetMyTeam(string dataFile)
        {
            //const Environment.NewLine;

            List<string> characterStringList = new List<string>();
            List<Champion> characterObjectList = new List<Champion>();
            Champion tempCharacter = new Champion();

            //
            // read each line and put it into an array and convert the array to a list
            //
            try
            {
                characterStringList = File.ReadAllLines(dataFile).ToList();
            }
            catch (Exception) // throw any exception up to the calling method
            {
                throw;
            }

            //
            // create character object for each line of data read and fill in the property values
            //
            foreach (string characterString in characterStringList)
            {
                tempCharacter = new Champion();

                // use the Split method and the delineator on the array to separate each property into an array of properties
                string[] properties = characterString.Split();

                tempCharacter.ChampName = properties[0];
                tempCharacter.ChampClass = properties[1];
                tempCharacter.ChampRank = properties[2];
                tempCharacter.ChampAwake = (Champion.ChampionAwake)Enum.Parse(typeof(Champion.ChampionAwake), properties[3]);

                characterObjectList.Add(tempCharacter);
            }

            return characterObjectList;
        }
        static List<Champion> InitializeListofChampions()
        {
            // List<Character> characters = new List<Character>();
            List<Champion> champions = new List<Champion>();

            Console.WriteLine("Enter the name of your champion here: ");

            try
            {

                
            }
            catch (Exception e)// catch any exception thrown by the write method
            {
                Console.WriteLine("\tThe following error occurred when adding a champion.");
                Console.WriteLine(e.Message);
            }

            return champions;
        }

        static void DisplayOpeningScreen()
        {
            Console.WriteLine("My Champions Application");
            string OpenLogo = @"
   _____         _________ .__                          .__                      
  /     \ ___.__.\_   ___ \|  |__ _____    _____ ______ |__| ____   ____   ______
 /  \ /  <   |  |/    \  \/|  |  \\__  \  /     \\____ \|  |/  _ \ /    \ /  ___/
/    Y    \___  |\     \___|   Y  \/ __ \|  Y Y  \  |_> >  (  <_> )   |  \\___ \ 
\____|__  / ____| \______  /___|  (____  /__|_|  /   __/|__|\____/|___|  /____  >
        \/\/             \/     \/     \/      \/|__|                  \/     \/ 
";
            Console.WriteLine(OpenLogo);
            DisplayContinuePrompt();
        }

        static void DisplayChampList()
        {            
            DisplayHeader("List of Champions in Marvel Contest of Champions");

            string dataPath = @"Data\ExcelChamp.cvs";
            string dataInfo;
            dataInfo = File.ReadAllText(dataPath);
            Console.WriteLine(dataInfo);

            DisplayContinuePrompt();
        }

        //static void DisplayGetMyTeam()
        //{
        //    DisplayHeader("Enter MCOC Team of Five");
        //    Console.ReadLine();



        //    DisplayContinuePrompt();
        //}

        static void DisplayTeamRanking()
        {
            DisplayHeader("Display Team Ranking");



            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            //Add aski for MARVEL COC or something
            Console.WriteLine();
            Console.WriteLine("\t\tThank You for using my application!");
            Console.WriteLine();
            string EndingLogo = @"
  __  __   _   _____   _____ _       ___         _          _      ___   __    ___ _                    _             
 |  \/  | /_\ | _ \ \ / / __| |     / __|___ _ _| |_ ___ __| |_   / _ \ / _|  / __| |_  __ _ _ __  _ __(_)___ _ _  ___
 | |\/| |/ _ \|   /\ V /| _|| |__  | (__/ _ \ ' \  _/ -_|_-<  _| | (_) |  _| | (__| ' \/ _` | '  \| '_ \ / _ \ ' \(_-<
 |_|  |_/_/ \_\_|_\ \_/ |___|____|  \___\___/_||_\__\___/__/\__|  \___/|_|    \___|_||_\__,_|_|_|_| .__/_\___/_||_/__/
                                                                                                  |_|                                                                                                                                                                                                             
";
            Console.WriteLine(EndingLogo);
            DisplayContinuePrompt();
        }

        #region HELPER  METHODS

        /// <summary>
        /// display header
        /// </summary>
        /// <param name="header"></param>
        static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + header);
            Console.WriteLine();
        }

        /// <summary>
        /// display the continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        #endregion

    }
}
