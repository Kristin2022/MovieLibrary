using System.Runtime.CompilerServices;
using System;
using System.IO;
using System.Collections.Generic;

//Download initial movie data file
List<string> movies = new List<string>();
string path = "movies.csv";
List<String> items = new List<string>();
string discard  = "duplicate";

//Console Application to see and add all movies
bool exit = false;
do
{   
    Console.WriteLine("Movie Library");
    Console.WriteLine("1) View all the movies");
    Console.WriteLine("2) Add a movie");
    Console.WriteLine("Enter anything else to quit.");
    string resp = Console.ReadLine();
    
    if (resp == "1")
    {
        //view movies
        if (File.Exists(path))
        {
            ViewMovies();
        }
    }
    else if (resp == "2")
    {
        //Exception Handling
        try
        {
            //enter movie
            Console.WriteLine("Enter movie id: ");
            string id = Console.ReadLine();
            Console.WriteLine("Enter title and year:  ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter genre: ");
            string genre = Console.ReadLine();

              AnyDuplicates(title);
        if (!items.Contains(title))
        {
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine("{0}, {1}, {2}", id, title, genre);
            }
        }
    }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while writing to the file: " + e.Message);
        }
    }
    else {
        exit = true;
    }
} while (!exit);

void ViewMovies()
{
    try
    {
        string path = "movies.csv";
        var lines = File.ReadAllLines(path); 
        foreach (var line in lines )
        {
            var movieSplitLine = line.Split(',');
            Console.WriteLine($"Id: {movieSplitLine[0]}\nTitle: {movieSplitLine[1]}\nGenres: {movieSplitLine[2]}\n");
        }
    }
    catch (IOException e)
    {
        Console.WriteLine("An error occurred while reading the file: " + e.Message);
    }
}

void AnyDuplicates(string newDuplicate)
{
    if(!items.Contains(newDuplicate))
    {
        items.Add(newDuplicate);
    }
    else
    {
        Console.WriteLine("The movie is already in the list.");
    }
}