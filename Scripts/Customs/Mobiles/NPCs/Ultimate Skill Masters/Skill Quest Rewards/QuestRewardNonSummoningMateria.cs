using Server.Items;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Customs.Mikes_Scripts.Skill_Masters.Ultimate_Skill_Masters.Skill_Quest_Rewards
{
    public class QuestRewardNonSummoningMateria : IRewardGroup
    {
        public int Weight => 10; // Set the weight for this group

        public Type[] GetRewards(PlayerMobile player, SkillName? skill)
        {
            return new[]
            {
                typeof(RandomMagicJewelry),
                typeof(RandomSkillJewelryA),
                typeof(RandomSkillJewelryB),
                typeof(RandomSkillJewelryC),
                typeof(RandomSkillJewelryD),
                typeof(RandomSkillJewelryE),
                typeof(RandomSkillJewelryF),
                typeof(RandomSkillJewelryG),
                typeof(RandomSkillJewelryH),
                typeof(RandomSkillJewelryI),
            };
        }
    }
}
