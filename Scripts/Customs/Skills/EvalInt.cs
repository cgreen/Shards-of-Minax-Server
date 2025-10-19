using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using TraitSystem;                      // for ITraitHolder
using CustomNPC;                        // for EvaluateTraitsGump
using Server.Engines.XmlSpawner2;   // XmlAttachment, XmlAttach
using System.Linq;


namespace Server.SkillHandlers
{
    public class EvalInt
    {
        public static void Initialize()
        {
            SkillInfo.Table[16].Callback = new SkillUseCallback(OnUse);
        }

        public static TimeSpan OnUse(Mobile m)
        {
            m.Target = new EvalIntTarget();
            m.SendLocalizedMessage(500906); // "What do you wish to evaluate?"
            return TimeSpan.FromSeconds(1.0);
        }

        private class EvalIntTarget : Target
        {
            public EvalIntTarget() : base(8, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                // --- STEP 1: Try to find an ITraitHolder attachment on the target object ---
                List<XmlAttachment> attachments = XmlAttach.FindAttachments(targeted);
                ITraitHolder holder = attachments?
                    .OfType<ITraitHolder>()
                    .FirstOrDefault();

                if (holder != null)
                {
                    // Optional: require EvalInt check to “unlock” the gump
                    if (from.CheckTargetSkill(SkillName.EvalInt, from, 0, 200))
                        from.SendGump(new EvaluateTraitsGump(from, holder));
                    else
                        from.SendMessage("You cannot discern anything.");
                    return;  // we’re done
                }

                // 2) Otherwise, fall back to your original EvalInt logic:

                if (from == targeted)
                {
                    from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 500910);
                }
                else if (targeted is TownCrier tc)
                {
                    tc.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 500907, from.NetState);
                }
                else if (targeted is BaseVendor bv && bv.IsInvulnerable)
                {
                    bv.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 500909, from.NetState);
                }
                else if (targeted is Mobile targ)
                {
                    // … your existing int/mana roll logic here …
                    int marginOfError = Math.Max(0, 20 - (int)(from.Skills[SkillName.EvalInt].Value / 5));

                    int intel = targ.Int + Utility.RandomMinMax(-marginOfError, +marginOfError);
                    int mana = ((targ.Mana * 100) / Math.Max(targ.ManaMax, 1)) + Utility.RandomMinMax(-marginOfError, +marginOfError);

                    int intMod = intel / 10;
                    int mnMod = mana / 10;

                    if (intMod > 10)
                        intMod = 10;
                    else if (intMod < 0)
                        intMod = 0;

                    if (mnMod > 10)
                        mnMod = 10;
                    else if (mnMod < 0)
                        mnMod = 0;

                    int body;

                    if (targ.Body.IsHuman)
                        body = targ.Female ? 11 : 0;
                    else
                        body = 22;

                    if (from.CheckTargetSkill(SkillName.EvalInt, targ, 0.0, 120.0))
                    {
                        targ.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 1038169 + intMod + body, from.NetState); // He/She/It looks [slighly less intelligent than a rock.]  [Of Average intellect] [etc...]

                        if (from.Skills[SkillName.EvalInt].Base >= 76.0)
                            targ.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 1038202 + mnMod, from.NetState); // That being is at [10,20,...] percent mental strength.
                    }
                    else 
                    {
                        targ.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 1038166 + (body / 11), from.NetState); // You cannot judge his/her/its mental abilities.
                    }					
                }
                else if (targeted is Item itm)
                {
                    itm.SendLocalizedMessageTo(from, 500908, "");
                }
            }
        }
    }
}
