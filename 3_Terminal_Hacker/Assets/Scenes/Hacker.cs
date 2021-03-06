﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrwo" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "enviroment", "exploration", "astronauts" };

    // Game state 
    int level;

    // Enumerations in C#
    enum Screen { MainMenu, Password, Win };
    
    string password;

    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Iskander!");
    }

    void ShowMainMenu(string greeting)
    {
        Screen currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local liberary");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA!");
        Terminal.WriteLine("Enter you selection: ");
    }
    
    void CookCurry(string meatToUse)
    {
        // common cooking steps go here 
        print("Iam adding the " + meatToUse);
    } 

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Hello Iskander!");
        } 
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber) 
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else 
        {
            Terminal.WriteLine("Please choose a valid number");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword() 
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter you password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword() 
    {
         switch(level)
        {
            case 1: 
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        } 
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward(); 
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward() 
    {
        switch (level) 
        {
            case 1: 
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
                        ___________
                       /          //
                      /          //
                     /__________//
                    (__________(/ 
                ");
                Terminal.WriteLine("Play again with a greater challenge.");
                break;
            case 2: 
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
                     __
                    /0 \__________
                    \__/-= ' === '
                ");
                Terminal.WriteLine("Play again with a greater challenge.");
                break;
            case 3: 
                Terminal.WriteLine(@"
                     NASA
                ");
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;
            default:
                Debug.LogError("Invalid level reached!");
                break;
        }
    }
}
