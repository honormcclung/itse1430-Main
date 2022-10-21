// See https://aka.ms/new-console-template for more information

/*
 * ITSE 1430 
 * Lab 2
 * Honor McClung
 * Date: 10/21/22
 */

using Honor.CharacterCreator.ConsoleHost;
using Honor.CharacterCreator;

DisplayProgramInformation();

Character characterOne = new Character("-1", "-1", "-1", "-1", -1, -1, -1, -1, -1);

bool userHasMadeCharacter = false;

var done = false;
do
{
    switch (DisplayMenu())
    {
        case MenuOption.NewCharacter: HandleNewCharacter(); break;
        case MenuOption.ViewCharacter: HandleViewCharacter(); break;
        case MenuOption.EditCharacter: HandleEditCharacter(); break;
        case MenuOption.DeleteCharacter: HandleDeleteCharacter(); break;

        case MenuOption.Quit: done = HandleQuit(); break;
    };
} while (!done);

#region Helper Functions 

/// <summary>Displays program information.</summary>
void DisplayProgramInformation ()
{
    Console.WriteLine("Lab 2 - Character Creator");
    Console.WriteLine("ITSE 1430");
    Console.WriteLine("Honor McClung");
    DrawLine(40);

    Console.WriteLine();
}

///<summary> Displays Menu Options. </summary>
MenuOption DisplayMenu ()
{
    Console.WriteLine();

    Console.WriteLine("N)ew Character");
    Console.WriteLine("V)iew Character");
    Console.WriteLine("E)dit Character");
    Console.WriteLine("D)elete Chatacter");

    Console.WriteLine("Q)uit");

    switch (GetKeyInput(ConsoleKey.Q, ConsoleKey.N, ConsoleKey.V, ConsoleKey.D, ConsoleKey.E))
    {
        case ConsoleKey.N: return MenuOption.NewCharacter;
        case ConsoleKey.V: return MenuOption.ViewCharacter;
        case ConsoleKey.D: return MenuOption.DeleteCharacter;
        case ConsoleKey.E: return MenuOption.EditCharacter;

        case ConsoleKey.Q: return MenuOption.Quit;
    };

    return 0;
}
#endregion

#region General Purpose Functions 

/// <summary>Draws a line.</summary>
/// <param name="width">The desired width.</param>
void DrawLine ( int width )
{
    Console.WriteLine("".PadLeft(width, '-'));
}

/// <summary>Prompts for a single, valid key.</summary>
/// <param name="validKeys">The list of valid keys.</param>
/// <returns>The entered key.</returns>
ConsoleKey GetKeyInput ( params ConsoleKey[] validKeys )
{
    do
    {
        var key = Console.ReadKey(true);
        if (validKeys.Contains(key.Key))
        {
            Console.WriteLine();
            return key.Key;
        } else
        {
            Console.WriteLine("Error: Invalid input. Try again.");
        }
    } while (true);
}

/// <summary>Displays a confirmation message and waits for a valid response.</summary>
/// <param name="message">The message to display.</param>
/// <returns><see langword="true"/> if confirmed.</returns>
bool Confirm ( string message )
{
    Console.WriteLine(message);

    return GetKeyInput(ConsoleKey.Y, ConsoleKey.N) == ConsoleKey.Y;
}

/// <summary>Draws a header row.</summary>
/// <param name="header">The header.</param>
void DrawHeader ( string header )
{
    Console.WriteLine(header);
    DrawLine(header.Length);
}

/// <summary>Poor man's code to draw a table row.</summary>
void DrawTableRow ( string column1, int column1Width, string column2, int column2Width = 0, string column3 = null, int column3Width = 0 )
{
    Console.Write(column1.PadRight(column1Width) + column2.PadRight(column2Width));
    if (!String.IsNullOrEmpty(column3))
        Console.Write(column3.PadRight(column3Width));

    Console.WriteLine();
}
#endregion

#region Command Functions

/// <summary>Handles the Quit command.</summary>
/// /// <returns><see langword="true"/> if confirmed.</returns>
bool HandleQuit ()
{
    if (Confirm("Are you sure you want to quit (Y/N)? "))
        return true;

    return false;
}

///<summary> Handles the new character command </summary>
void HandleNewCharacter ()
{
    userHasMadeCharacter = true;

    SetName();
    SelectRace();
    SelectProfession();
    SetBiography();
    SetStrength();
    SetIntelligence();
    SetAgility();
    SetConstitution();
    SetCharisma();
}

///<summary> Handles the view character command </summary>
void HandleViewCharacter ()
{
    if (userHasMadeCharacter == true)
    {
        DrawHeader("Character Information:");

        DrawTableRow("Name: ", 3, characterOne.Name);
        DrawTableRow("Race: ", 3, characterOne.Race);
        DrawTableRow("Profession: ", 3, characterOne.Profession);
        DrawTableRow("Biography: ", 3, characterOne.Biography);
        DrawTableRow("Strength: ", 3, characterOne.Strength.ToString());
        DrawTableRow("Intelligence: ", 3, characterOne.Intellingence.ToString());
        DrawTableRow("Agility: ", 3, characterOne.Agility.ToString());
        DrawTableRow("Construction: ", 3, characterOne.Constitution.ToString());
        DrawTableRow("Charisma: ", 3, characterOne.Charisma.ToString());
    } else
    {
        Console.WriteLine("No Character has been created.");
    }

}

///<summary> Handles the edit character command. </summary>
void HandleEditCharacter ()
{
    if (userHasMadeCharacter == true)
    {
        DrawTableRow("Current Name: ", 3, characterOne.Name);
        if (Confirm("Are you sure you want to edit name? (Y/N)"))
        {
            SetName();
        }

        DrawTableRow("Current Race: ", 3, characterOne.Name);
        if (Confirm("Are you sure you want to edit race? (Y/N)"))
        {
            SelectRace();
        }

        DrawTableRow("Current Profession: ", 3, characterOne.Profession);
        if (Confirm("Are you sure you want to edit profession? (Y/N)"))
        {
            SelectProfession();
        }

        DrawTableRow("Current Biography: ", 3, characterOne.Biography);
        if (Confirm("Are you sure you want to edit biography? (Y/N)"))
        {
            SetBiography();
        }

        DrawTableRow("Current Strength: ", 3, characterOne.Strength.ToString());
        if (Confirm("Are you sure you want to edit strength? (Y/N)"))
        {
            SetStrength();
        }

        DrawTableRow("Current Intelligence: ", 3, characterOne.Intellingence.ToString());
        if (Confirm("Are you sure you want to edit intelligence? (Y/N)"))
        {
            SetIntelligence();
        }

        DrawTableRow("Current Agility: ", 3, characterOne.Agility.ToString());
        if (Confirm("Are you sure you want to edit agility? (Y/N)"))
        {
            SetAgility();
        }

        DrawTableRow("Current constitution: ", 3, characterOne.Constitution.ToString());
        if (Confirm("Are you sure you want to edit constitution? (Y/N)"))
        {
            SetConstitution();
        }

        DrawTableRow("Current Charisma: ", 3, characterOne.Charisma.ToString());
        if (Confirm("Are you sure you want to edit charisma? (Y/N)"))
        {
            SetCharisma();
        }

        HandleViewCharacter();
    } else
    {
        Console.WriteLine("No character has been created.");
    }
}

///<summary> Handles the delete character command. </summary>
void HandleDeleteCharacter ()
{
    if (userHasMadeCharacter == false)
    {
        Console.WriteLine("Error. No Character has been made.");
    } else
    {
        if (Confirm("Are you sure you want to delete character? (Y/N)"))
        {
            Console.WriteLine("Character has been deleted.");
            userHasMadeCharacter = false;
        }
    }
}
#endregion


#region Components
///<summary> Displays availible professions and allows user to select one. </summary>
void SelectProfession ()
{
    DrawHeader("Available Professions");

    DrawTableRow("1)", 3, "Fighter");
    DrawTableRow("2)", 3, "Hunter");
    DrawTableRow("3)", 3, "Priest");
    DrawTableRow("4)", 3, "Rogue");
    DrawTableRow("5)", 3, "Wizard");

    switch (GetKeyInput(ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6))
    {
        case ConsoleKey.D1:
        characterOne.Profession = "Fighter";
        break;
        case ConsoleKey.D2:
        characterOne.Profession = "Fighter";
        break;
        case ConsoleKey.D3:
        characterOne.Profession = "Priest";
        break;
        case ConsoleKey.D4:
        characterOne.Profession = "Rogue";
        break;
        case ConsoleKey.D5:
        characterOne.Profession = "Wizard";
        break;
    }
}

///<summary>Displays availible race options and allows user to select one. </summary>
void SelectRace ()
{
    DrawHeader("Available Races");

    DrawTableRow("1)", 3, "Dwarf");
    DrawTableRow("2)", 3, "Elf");
    DrawTableRow("3)", 3, "Gnome");
    DrawTableRow("4)", 3, "Half Elf");
    DrawTableRow("5)", 3, "Human");

    switch (GetKeyInput(ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6))
    {
        case ConsoleKey.D1:
        characterOne.Race = "Dwarf";
        break;
        case ConsoleKey.D2:
        characterOne.Race = "Fighter";
        break;
        case ConsoleKey.D3:
        characterOne.Race = "Priest";
        break;
        case ConsoleKey.D4:
        characterOne.Race = "Rogue";
        break;
        case ConsoleKey.D5:
        characterOne.Race = "Wizard";
        break;
    }
}

///<summary> Allows user to input character name. </summary>
void SetName ()
{
    DrawHeader("Choose a name for your character");
    characterOne.Name = Console.ReadLine();
    Console.WriteLine();
}

///<summary> Allows user to inoput character biography. </summary>
void SetBiography ()
{
    DrawHeader("Set a biography for your character (optional)");
    characterOne.Biography = Console.ReadLine();
    Console.WriteLine();
}

///<summary> Allows user to input character strength. </summary>
void SetStrength ()
{
    int userInput = -1;
    do
    {
        try
        {
            DrawHeader("Set a strength level for your character (0-100)");

            userInput = Int32.Parse(Console.ReadLine());
        } catch
        {
            Console.WriteLine("Invalid input, try again.");
        }
        characterOne.Strength = userInput;
    } while (characterOne.Strength < 0 || characterOne.Strength > 100);

    Console.WriteLine();
}

///<summary> Allows user to inout character intelligence. </summary>
void SetIntelligence ()
{
    int userInput = -1;
    do
    {
        try
        {
            DrawHeader("Set a level of intelligence for your character (0-100):");

            userInput = Int32.Parse(Console.ReadLine());
        } catch
        {
            Console.WriteLine("Invalid input, try again.");
        }
        characterOne.Intellingence = userInput;
    } while (characterOne.Intellingence < 0 || characterOne.Intellingence > 100);

    Console.WriteLine();
}

///<summary> Allows user to input character agility. </summary>
void SetAgility ()
{
    int userInput = -1;
    do
    {
        try
        {
            DrawHeader("Set a Agility level for your character (0-100):");

            userInput = Int32.Parse(Console.ReadLine());
        } catch
        {
            Console.WriteLine("Invalid input, try again.");
        }
        characterOne.Agility = userInput;
    } while (characterOne.Agility < 0 || characterOne.Agility > 100);

    Console.WriteLine();
}

///<summary> Allows user to input character constitution. </summary>
void SetConstitution ()
{
    int userInput = -1;
    do
    {
        try
        {
            DrawHeader("Set a constitution level for your character (0-100):");

            userInput = Int32.Parse(Console.ReadLine());
        } catch
        {
            Console.WriteLine("Invalid input, try again.");
        }
        characterOne.Constitution = userInput;
    } while (characterOne.Constitution < 0 || characterOne.Constitution > 100);

    Console.WriteLine();
}

///<summary> Allows user to input character charisma </summary>
void SetCharisma ()
{
    int userInput = -1;
    do
    {
        try
        {
            DrawHeader("Set a charisma level for your character (0-100):");

            userInput = Int32.Parse(Console.ReadLine());
        } catch
        {
            Console.WriteLine("Invalid input, try again.");
        }
        characterOne.Charisma = userInput;
    } while (characterOne.Charisma < 0 || characterOne.Charisma > 100);

    Console.WriteLine();
}


#endregion




