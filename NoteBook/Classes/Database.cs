using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.Classes
{
    public class Database
    {
        private List<About> abouts = new List<About>();
        private int autoincrement = 3;
        public Database()
        {
            About about = new About { Id = 1, Name = "Первая задача"};
            About about2 = new About { Id = 2, Name = "Вторая задача"};
            About about3 = new About { Id = 3, Name = "Третья задача"};
            abouts.Add(about);
            abouts.Add(about2);
            abouts.Add(about3);
        }

        public Task<List<About>> GetAbouts()
        {
            return Task.FromResult(abouts);
        }

        public Task<About> GetAbout(int id)
        {
            return Task.FromResult(abouts.Find(s => s.Id == id));
        }

        public async Task EditAbout(About about)
        {
            if (about.Id == 0)
            {
                about.Id = ++autoincrement;
                abouts.Add(about); 
            }
            else
            {
                About oldAbout = await GetAbout(about.Id);
                oldAbout = about;
            }
           

        }

        public Task DeleteAbout(About about)
        {
            abouts.Remove(about);
            return Task.CompletedTask;
        }
    }
}
