using Microsoft.EntityFrameworkCore;
using YogaCenterLibrary.Models;

namespace YogaCenterAPIV2.DAL
{
    public class LevelRepository
    {
        YogaCenterContext db = new YogaCenterContext();
        public LevelRepository() { }
        public async Task<List<dynamic>> GetAllLevel()
        {
            var levels = await (from l in db.Levels select new { levelId = l.Id, levelName = l.LevelName }).ToListAsync();
            return levels.Cast<dynamic>().ToList();
        }
    }
}
