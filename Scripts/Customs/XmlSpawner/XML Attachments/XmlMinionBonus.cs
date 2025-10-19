using System;
using Server;
using Server.Mobiles;

namespace Server.Engines.XmlSpawner2
{
    /// <summary>
    /// Attaching this to ANY wearable item will raise the wearer’s FollowersMax.
    /// • Default ctor   : +1 follower
    /// • Param ctor int : +N followers
    /// </summary>
    public class XmlMinionBonus : XmlAttachment
    {
        private int m_Bonus = 1;

        #region Constructors & serialization
        public XmlMinionBonus(ASerial serial) : base(serial) { }

        // ❶ default +1
        [Attachable] public XmlMinionBonus() { }

        // ❷ script‑defined amount
        [Attachable] public XmlMinionBonus(int bonusFollowers)
        {
            m_Bonus = bonusFollowers;
        }
        #endregion

        #region Equip / Unequip hooks
        // Fired when the item this attachment sits on is equipped
        public override void OnEquip(Mobile from)
        {
            base.OnEquip(from);
            if (from is PlayerMobile pm)
                pm.FollowersMax += m_Bonus;
        }

        // Fired when the item is unequipped (but the attachment still exists)
/*         public override void OnUnequip(Mobile from)
        {
            base.OnUnequip(from);
            if (from is PlayerMobile pm)
                pm.FollowersMax -= m_Bonus;
        } */

        // Fired if the attachment itself is deleted/removed
        public override void OnRemoved(object parent)
        {
            base.OnRemoved(parent);
            if (parent is PlayerMobile pm)
                pm.FollowersMax -= m_Bonus;
        }
        #endregion

        #region Tooltip & identify text
        // Shows up when someone single‑clicks the item
        public override string OnIdentify(Mobile from)
            => $"+{m_Bonus} max follower{(m_Bonus == 1 ? "" : "s")}";
        #endregion

        #region Persistence
        public override void Serialize(GenericWriter w)
        {
            base.Serialize(w);
            w.Write((int)0);      // version
            w.Write(m_Bonus);
        }

        public override void Deserialize(GenericReader r)
        {
            base.Deserialize(r);
            r.ReadInt();          // version
            m_Bonus = r.ReadInt();
        }
        #endregion
    }
}
