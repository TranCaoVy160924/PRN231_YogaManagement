using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YogaManagement.Contracts.MemberLevel;

namespace YogaManagement.Business.Repositories;
public class MemberLevelConditonRepository
{
    private readonly IConfiguration _configuration;

    public MemberLevelConditonRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public MemberLevelDiscountDTO Get()
    {
        var getSection = _configuration.GetSection("PrivilegeCondition");
        var level = new MemberLevelDiscountDTO()
        {
            Id = Convert.ToInt32(getSection.GetSection("Id").Value),
            Silver = Convert.ToDouble(getSection.GetSection("Silver").Value),
            Gold = Convert.ToDouble(getSection.GetSection("Gold").Value),
            Platinum = Convert.ToDouble(getSection.GetSection("Platinum").Value)
        };

        return level;
    }

    public MemberLevelDiscountDTO Edit(MemberLevelDiscountDTO level)
    {
        var updateData = new Dictionary<string, object>
        {
            { "Id", "1" },
            { "Silver", level.Silver.ToString() },
            { "Gold", level.Gold.ToString() },
            { "Platinum", level.Platinum.ToString() }
        };
        UpdateAppSetting("PrivilegeCondition", updateData);

        return level;
    }

    #region update helper
    public void UpdateAppSetting(string sectionKey, Dictionary<string, object> updatedSection)
    {
        var configJson = File.ReadAllText("appsettings.json");
        var config = JsonSerializer.Deserialize<Dictionary<string, object>>(configJson);

        // Update the section with the new values
        config[sectionKey] = updatedSection;

        // Serialize the modified config back to JSON
        var updatedConfigJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });

        // Write the updated JSON back to the file
        File.WriteAllText("appsettings.json", updatedConfigJson);
    }
    #endregion
}
