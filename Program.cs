using System;
using System.Collections.Generic;

public class Program
{
    static List<string> todoList = new List<string>();

    public static void Main(string[] args)
    {
        Console.WriteLine("Try masteringbackend.com");
        Console.WriteLine("Hello, welcome to TODO List");

        bool isInputE = false;

        do
        {
            DisplayMenu();
            string userInput = Console.ReadLine();
            isInputE = ProcessUserInput(userInput);
        } while (!isInputE);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("[S]ee All TODOs");
        Console.WriteLine("[A]dd a TODO");
        Console.WriteLine("[R]emove a TODO");
        Console.WriteLine("[E]xit");
    }

    static bool ProcessUserInput(string userInput)
    {
        userInput = userInput.ToLower();
        switch (userInput)
        {
            case "a":
                AddTodo();
                break;
            case "s":
                ShowAllTodos();
                break;
            case "r":
                RemoveTodo();
                break;
            case "e":
                return true;
            default:
                Console.WriteLine("Invalid input: " + userInput);
                break;
        }
        return false;
    }

    static void ShowAllTodos()
    {
        if (todoList.Count == 0)
        {
            Console.WriteLine("No active TODOs in the list\n");
        }
        else
        {
            Console.WriteLine("All TODOs:\n");
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + todoList[i]);
            }
        }
    }

    static void AddTodo()
    {
        Console.WriteLine("Enter the TODO Description:");
        string todoDescription = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(todoDescription))
        {
            Console.WriteLine("TODO description cannot be empty.\n");
            return;
        }

        if (todoList.Contains(todoDescription))
        {
            Console.WriteLine("TODO description must be unique.\n");
            return;
        }

        todoList.Add(todoDescription);
        Console.WriteLine("TODO Description added successfully.\n");
    }

    static void RemoveTodo()
    {
        ShowAllTodos();

        if (todoList.Count == 0)
        {
            return;
        }

        int index;
        do
        {
            Console.WriteLine("Enter the index of the TODO to remove:");
            string userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out index) || index < 1 || index > todoList.Count)
            {
                Console.WriteLine("Invalid index. Please enter a valid index.\n");
                continue;
            }

            break;
        } while (true);

        Console.WriteLine("Remove Todo Item: " + todoList[index - 1]);
        Console.WriteLine("Do you really want to delete this? Press [Y/y] for Yes or [N/n] for No:");

        string confirmation = Console.ReadLine();
        confirmation = confirmation.ToLower();

        if (confirmation == "y")
        {
            Console.WriteLine("Removed Todo Item: " + todoList[index - 1]);
            todoList.RemoveAt(index - 1);
        }
        else if (confirmation == "n")
        {
            Console.WriteLine("Cancel Remove Todo Item: " + todoList[index - 1]);
        }
        else
        {
            Console.WriteLine("Invalid input. Action rolled back.");
            Console.WriteLine("Cancel Remove Todo Item: " + todoList[index - 1]);
        }
    }
}