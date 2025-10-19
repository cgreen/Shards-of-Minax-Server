using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    // Abstract base for skill scrolls
    public abstract class RidingSkillScroll : Item
    {
        private double _targetSkill;
        private string _displayName;
        private string _levelName;

        public RidingSkillScroll(int itemID, double targetSkill, string displayName, string levelName, int hue = 0x481)
            : base(itemID)
        {
            _targetSkill = targetSkill;
            _displayName = displayName;
            _levelName = levelName;

            Name = _displayName;
            Hue = hue;
            Weight = 0.1;
        }

        public RidingSkillScroll(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack to use it.
                return;
            }

            if (!(from is PlayerMobile))
            {
                from.SendMessage("Only players can use this scroll.");
                return;
            }

            var skills = LokaiSkillUtilities.XMLGetSkills(from);

            if (skills.AnimalRiding.Base >= _targetSkill)
            {
                from.SendMessage($"Your riding skill is already at or above the {_levelName} level.");
                return;
            }

            skills.AnimalRiding.Base = _targetSkill;
            from.SendMessage($"You feel your riding skill surge to the {_levelName} ({_targetSkill:0.0}).");
            this.Delete();
        }
    }

    public class ScrollOfRidingAmateur : RidingSkillScroll
    {
        [Constructable]
        public ScrollOfRidingAmateur() : base(0x1F4D, 30.0, "Scroll of Riding: Amateur", "Amateur") { }
        public ScrollOfRidingAmateur(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class ScrollOfRidingJourneyman : RidingSkillScroll
    {
        [Constructable]
        public ScrollOfRidingJourneyman() : base(0x1F4D, 50.0, "Scroll of Riding: Journeyman", "Journeyman") { }
        public ScrollOfRidingJourneyman(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class ScrollOfRidingExpert : RidingSkillScroll
    {
        [Constructable]
        public ScrollOfRidingExpert() : base(0x1F4D, 80.0, "Scroll of Riding: Expert", "Expert") { }
        public ScrollOfRidingExpert(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class ScrollOfRidingMaster : RidingSkillScroll
    {
        [Constructable]
        public ScrollOfRidingMaster() : base(0x1F4D, 100.0, "Scroll of Riding: Master", "Master") { }
        public ScrollOfRidingMaster(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
}
