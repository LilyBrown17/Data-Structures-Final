using System;
using System.Collections.Generic;

class Song {
    public required string Title { get; set; }
    public required string Artist { get; set; }
    public double Duration { get; set; }
}

class Playlist {
    // Linked List to store songs
    private LinkedList<Song> playlist;

    public Playlist() {
        // Initialize list
        playlist = new LinkedList<Song>();
    }

    public void AddSongStart(string title, string artist, double duration) {
        Song newSong = new Song {
            Title = title,
            Artist = artist,
            Duration = duration
        };

        // Add song to list end
        playlist.AddFirst(newSong); 
    }

    // Add new song to list end
    public void AddSongEnd(string title, string artist, double duration) {
        Song newSong = new Song {
            Title = title,
            Artist = artist,
            Duration = duration
        };

        // Add song to list end
        playlist.AddLast(newSong); 
    }

    // TODO: Add new song after a specific song
    public void AddSongAfter(string title, string artist, double duration, string oldTitle) {
        Song newSong = new Song {
            Title = title,
            Artist = artist,
            Duration = duration
        };

        var node = playlist.First;
        while (node != null) {
            // TODO: Loop through list to find song (oldTitle) to add next to
            // TODO: Add song to list
        }
    }

    // TODO: Remove song by title
    public void RemoveSong(string title) {
        var node = playlist.First;
        while (node != null) {
            // TODO: Loop through list to find song (title) to remove
            // TODO: Remove song from list
        }
    }

    // Display playlist
    public void DisplayPlaylist() {
        if (playlist.Count == 0) {
            Console.WriteLine("Playlist is empty.");
            return;
        }

        Console.WriteLine("Playlist:");
        foreach (var song in playlist) {
            Console.WriteLine($"{song.Title} by {song.Artist} - {song.Duration} mins");
        }
    }

    // Navigate forward through playlist
    public void NavigateForward() {
        if (playlist.Count == 0) {
            Console.WriteLine("Playlist is empty.");
            return;
        }

        Console.WriteLine("Playing (Forwards):");
        var node = playlist.First;
        while (node != null) {
            Console.WriteLine($"Now Playing: {node.Value.Title} by {node.Value.Artist}");
            node = node.Next;
        }
    }

    // TODO: Navigate backward through playlist
    public void NavigateBackward() {

    }
}

class Program {
    static void Main(string[] args) {
        Playlist playlist = new Playlist();

        // TODO: Add songs
        playlist.AddSongEnd("Rolling Girl", "Wowaka", 3.5);
        playlist.AddSongStart("Telecaster B-Boy", "Surii", 4.0);
        playlist.AddSongEnd("Hibikase", "GIGA", 5.2);
        // playlist.AddSongAfter("Unknown Mother Goose", "Wowaka", 2.6, "Rolling Girl");

        // Display playlist
        playlist.DisplayPlaylist();

        // Navigate forward
        playlist.NavigateForward();

        // TODO: Navigate backward
        // playlist.NavigateBackward();

        // TODO: Remove song
        // Console.WriteLine("Removing Telecaster B-Boy...");
        // playlist.RemoveSong("Telecaster B-Boy");

        // Display updated playlist
        playlist.DisplayPlaylist();
    }
}
