using Afstuderen2020.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afstuderen2020.Data
{
    public class Afstuderen2020Seeder
    {
        private readonly Afstuderen2020Context _ctx;
        private readonly IHostingEnvironment _hosting;
        public Afstuderen2020Seeder(Afstuderen2020Context ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            // Als er geen users zijn moeten deze worden aangemaakt.
            if (!_ctx.Users.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/Seeders/user.json");
                var json = File.ReadAllText(filepath);
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
                _ctx.Users.AddRange(users);

                _ctx.SaveChanges();
            }

            // Als er geen comments zijn moeten deze worden aangemaakt.
            if (!_ctx.Comments.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/Seeders/comment.json");
                var json = File.ReadAllText(filepath);
                var comments = JsonConvert.DeserializeObject<IEnumerable<Comment>>(json);
                _ctx.Comments.AddRange(comments);

                _ctx.SaveChanges();
            }
        }
    }
}
