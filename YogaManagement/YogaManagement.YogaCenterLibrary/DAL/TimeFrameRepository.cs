using Microsoft.EntityFrameworkCore;
using YogaCenterLibrary.Models;

namespace YogaCenterAPIV2.DAL
{
    public class TimeFrameRepository
    {
        YogaCenterContext db = new YogaCenterContext();
       
        public async Task<dynamic> GetTimeFrame(int timeFrameId)
        {
            var TimeFrame = await db.TimeFrames.FirstOrDefaultAsync(tf => tf.Id == timeFrameId);            
            return TimeFrame;
        }

        public async Task<List<dynamic>> GetTimeFrameList()
        {
            var TimeFrameList = await db.TimeFrames.ToListAsync();
            return TimeFrameList.Cast<dynamic>().ToList();
        }
    }
}
