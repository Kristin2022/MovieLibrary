using System.Runtime.CompilerServices;
using System;
using System.IO;
using System.Collections.Generic;
using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.conf";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

// log sample messages
logger.Trace("Sample trace message");
logger.Debug("Sample debug message");
logger.Info("Sample informational message");
logger.Warn("Sample warning message");
logger.Error("Sample error message");
logger.Fatal("Sample fatal error message");

//Download initial movie data file
List<string> movies = new List<string>();
string path_ = Directory.GetCurrentDirectory() + "\\movies.csv"; //Updated path
HashSet<String> items = new HashSet<string>();

//List<String> items = new List<string>();
//string discard = "duplicate";
LoadExistingMovies();
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
        if (File.Exists(path_))
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

            if  (AnyDuplicates(title))
            {
                continue;
            }

            using (StreamWriter sw = new StreamWriter(path_, append: true))
            {
                sw.WriteLine("{0}, {1}, {2}", id, title, genre);
            }
        }
    
        catch (IOException e)
        {
            logger.Error(e, "An error occured while writing to the file"); //logging the exception
            Console.WriteLine("An error occurred while writing to the file: " + e.Message);
        }
    }
    else if (resp == "3")
     {
        RemoveDuplicates();
     }
     else {
        exit = true;
    }
} while (!exit);

void RemoveDuplicates()
{
    throw new NotImplementedException();
}

void LoadExistingMovies()
{
    if(File.Exists(path_))
    {
        var lines = File.ReadAllLines(path_);
        foreach(var line in lines)
        {
            items.Add(line);
           // var movieSplitLine = line.Split(',');
           // items.Add(movieSplitLine[1].Trim());
        }
    }
}

void ViewMovies()
{
    try
    {
        //string path = Directory.GetCurrentDirectory(); + "\\movies.csv"; //Updated path "movies.csv";
        var lines = File.ReadAllLines(path_); 
        foreach (var line in lines )
        {
            var movieSplitLine = line.Split(',');
            Console.WriteLine($"Id: {movieSplitLine[0]}\nTitle: {movieSplitLine[1]}\nGenres: {movieSplitLine[2]}\n");
        }
    }
    catch (IOException e)
    {
        logger.Error(e, "An error occured while reading the file");//logging exception
        Console.WriteLine("An error occurred while reading the file: " + e.Message);
    }
}

bool AnyDuplicates(string newDuplicate)
{
    if(!items.Contains(newDuplicate))
    {
        items.Add(newDuplicate);
        return false;
    }
    else
    {
        Console.WriteLine("The movie is already in the list.");
        return true;
        throw new Exception("Duplicate movie title");
    }
}