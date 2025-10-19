using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Engines.XmlSpawner2;
using Server.CustomPoisons; // <-- Be sure this matches your namespace structure

namespace Server.Engines.XmlSpawner2
{
    public class CustomPoisonAttachment : XmlAttachment
    {
        // --- Store list of effect IDs (persisted) ---
        private readonly List<string> _effectIds = new List<string>();

        // --- Public getter for effects, optional for debugging ---
        public IEnumerable<string> EffectIds => _effectIds;

        // --- Allow adding effects (never duplicates) ---
        public void AddEffect(string id)
        {
            if (!string.IsNullOrEmpty(id) && !_effectIds.Contains(id))
                _effectIds.Add(id);
        }

        // --- (Optional) Remove all effects
        public void ClearEffects() => _effectIds.Clear();

        // --- Set number of poison hits before this attachment is deleted
        [CommandProperty(AccessLevel.GameMaster)]
        public int Hits { get; set; } = 3;

        public CustomPoisonAttachment() { }
        public CustomPoisonAttachment(ASerial serial) : base(serial) { }

        // --- Show tooltip immediately after attachment
        public override void OnAttach()
        {
            base.OnAttach();
            InvalidateParentProperties();
        }

        // --- Display poison effects and hit counter in tooltip
        public override void AddProperties(ObjectPropertyList list)
        {
            if (Hits > 0 && _effectIds.Count > 0)
            {
                list.Add("Poisoned:");
                string desc = string.Join(", ",
                    _effectIds.Select(id =>
                        PoisonEffectRegistry.Get(id)?.Label ?? id)
                );
                list.Add(desc);
                list.Add($"Hits left: {Hits}");
            }
        }

        // --- Run every effect on successful weapon hit, play SFX/FX
        public override void OnWeaponHit(Mobile attacker, Mobile defender, BaseWeapon weapon, int damageGiven)
        {
            if (Hits <= 0 || _effectIds.Count == 0)
                return;

            foreach (string id in _effectIds)
            {
                var effect = PoisonEffectRegistry.Get(id);
                if (effect == null)
                    continue;

                effect.Apply(attacker, defender);
                if (effect.SoundId >= 0)
                    defender.PlaySound(effect.SoundId);

                effect.Visual(defender);
            }

            // --- Reduce remaining hits, remove attachment if exhausted
            Hits--;
            if (Hits <= 0)
            {
                Delete();
            }
            else
            {
                InvalidateParentProperties();
            }
        }

        // --- Persistence: save effect IDs and hit count
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1); // version

            writer.Write(Hits);

            writer.Write(_effectIds.Count);
            foreach (string id in _effectIds)
                writer.Write(id);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            Hits = reader.ReadInt();

            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
                _effectIds.Add(reader.ReadString());
        }
    }
}
