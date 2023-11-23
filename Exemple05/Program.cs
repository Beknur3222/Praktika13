using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple05
{
    class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
    }

    class CompactDisk
    {
        public string Title { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
    }

    class MusicCatalog
    {
        private Hashtable catalog = new Hashtable();

        public void AddDisk(string title)
        {
            CompactDisk disk = new CompactDisk { Title = title };
            catalog.Add(title, disk);
        }

        public void RemoveDisk(string title)
        {
            catalog.Remove(title);
        }

        public void AddSong(string diskTitle, string songTitle, string artist)
        {
            if (catalog.ContainsKey(diskTitle))
            {
                CompactDisk disk = (CompactDisk)catalog[diskTitle];
                disk.Songs.Add(new Song { Title = songTitle, Artist = artist });
            }
        }

        public void RemoveSong(string diskTitle, string songTitle)
        {
            if (catalog.ContainsKey(diskTitle))
            {
                CompactDisk disk = (CompactDisk)catalog[diskTitle];
                disk.Songs.RemoveAll(song => song.Title == songTitle);
            }
        }

        public void DisplayCatalog()
        {
            foreach (DictionaryEntry entry in catalog)
            {
                CompactDisk disk = (CompactDisk)entry.Value;
                Console.WriteLine($"Disk: {disk.Title}");
                foreach (var song in disk.Songs)
                {
                    Console.WriteLine($"  Song: {song.Title} - {song.Artist}");
                }
            }
        }

        public void DisplayArtistSongs(string artist)
        {
            foreach (DictionaryEntry entry in catalog)
            {
                CompactDisk disk = (CompactDisk)entry.Value;
                foreach (var song in disk.Songs)
                {
                    if (song.Artist == artist)
                    {
                        Console.WriteLine($"Disk: {disk.Title}, Song: {song.Title}");
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MusicCatalog catalog = new MusicCatalog();

            catalog.AddDisk("Disk 1");
            catalog.AddSong("Disk 1", "Шыда", "Мирас Жугунусов");
            catalog.AddSong("Disk 1", "Цепи", "Скриптонит");

            catalog.AddDisk("Disk 2");
            catalog.AddSong("Disk 2", "Сен туралы", "Мирас Жугунусов");
            catalog.AddSong("Disk 2", "Adjare Gudju", "Ирина Кайратовна");

            catalog.DisplayCatalog();

            catalog.RemoveSong("Disk 1", "Цепи");

            Console.WriteLine("\nПосле удаления песни:\n");

            catalog.DisplayCatalog();

            Console.WriteLine("\nПоиск по истолнителю:\n");

            catalog.DisplayArtistSongs("Мирас Жугунусов");

            Console.ReadKey();
        }
    }

}
