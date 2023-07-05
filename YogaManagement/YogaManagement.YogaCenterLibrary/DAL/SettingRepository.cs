using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Utils;

namespace YogaCenterAPIV2.DAL
{
    public class SettingRepository
    {
        YogaCenterContext db = new YogaCenterContext();
        public SettingRepository() { 
        
        }

        public async Task<List<dynamic>> getSettings()
        {
            var settingList = await db.Settings.ToListAsync();
            return settingList.Cast<dynamic>().ToList();
        }

        public async Task updateSetting(List<Setting> settings)
        {
            
            foreach(var setting in settings) {
                
                    var oldSetting = await getsettingById(setting.Id);
                            oldSetting.ActiveValue = setting.ActiveValue;
                            oldSetting.ActiveDate = setting.ActiveDate;
            }
            await db.SaveChangesAsync();
        }

        public async Task<Setting> getsettingById(int id)
        {
            var setting = await db.Settings.FirstOrDefaultAsync(se => se.Id == id);
            return setting;
        }

        public async Task<double?> getSettingValue(int id)
        {
            var setting = await getsettingById(id);
            if(setting != null)
            {
                return setting.PreactiveValue;
            }
            return -1;
        }
    }
}
