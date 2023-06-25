using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Definirea spectacolelor
        List<Show> shows = new List<Show>()
        {
            new Show("Show 1", new DateTime(2023, 6, 24, 9, 0, 0), new DateTime(2023, 6, 24, 10, 0, 0)),
            new Show("Show 2", new DateTime(2023, 6, 24, 9, 30, 0), new DateTime(2023, 6, 24, 10, 30, 0)),
            new Show("Show 3", new DateTime(2023, 6, 24, 10, 0, 0), new DateTime(2023, 6, 24, 11, 0, 0)),
            new Show("Show 4", new DateTime(2023, 6, 24, 10, 30, 0), new DateTime(2023, 6, 24, 11, 30, 0)),
            new Show("Show 5", new DateTime(2023, 6, 24, 11, 0, 0), new DateTime(2023, 6, 24, 12, 0, 0))
        };

        // Sortarea spectacolelor în ordine crescătoare a orelor de sfârșit
        shows.Sort((x, y) => x.EndTime.CompareTo(y.EndTime));

        // Selectarea spectacolelor neconflictuale
        List<Show> selectedShows = new List<Show>();
        selectedShows.Add(shows[0]);

        DateTime lastEndTime = shows[0].EndTime;

        for (int i = 1; i < shows.Count; i++)
        {
            if (shows[i].StartTime >= lastEndTime)
            {
                selectedShows.Add(shows[i]);
                lastEndTime = shows[i].EndTime;
            }
        }

        // Afișarea spectacolelor selectate
        Console.WriteLine("Spectacolele selectate sunt:");

        foreach (Show show in selectedShows)
        {
            Console.WriteLine(show.Name);
        }
    }
}

class Show
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Show(string name, DateTime startTime, DateTime endTime)
    {
        Name = name;
        StartTime = startTime;
        EndTime = endTime;
    }
}