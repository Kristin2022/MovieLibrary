// See https://aka.ms/new-console-template for more information

//Create movie Console Application to see all movies in the file and to add movies to the file.
using System.Runtime.CompilerServices;
using System;
//using Microsoft.VisualBasic;
using System.IO;

//string file = "csv";
List<string> movies = new List<string>();
string path = "movies.csv"; 


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
                //string line = sr.ReadLine();
                //string pattern  = @"(\d+)([^\d]+)";
        }
    }
    else if (resp == "2")
    {
        //enter movie
        Console.WriteLine("Enter movie id: ");
        string id = Console.ReadLine();
        Console.WriteLine("Enter title and year:  ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter genre: ");
        string genre = Console.ReadLine();

        StreamWriter sw = new StreamWriter(path, append: true);
        sw.WriteLine("{0}, {1}, {2}", id, title, genre);
        sw.Close();
    }
    else {
        // if(resp != "1" ||  resp != "2");
        exit = true;
    }
} while (!exit);

void ViewMovies(){
    string path = "movies.csv";
             var lines = File.ReadAllLines(path); 
             foreach (var line in lines ){
                    var movieSplitLine = line.Split(',');
                    Console.WriteLine($"Id: {movieSplitLine[0]}\nTitle: {movieSplitLine[1]}\nGenres: {movieSplitLine[2]}\n");
             }
}
