using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.MiniChamps;
using System.Collections.Generic;


namespace Server.Items
{
    /// <summary>
    /// Flickering exit portal inside the dungeon.  Multi-use.
    /// </summary>
    public class ReturnPortal : Item
    {
        public Point3D Destination    { get; set; }
        public Map     DestinationMap { get; set; }

        private int _hue, _sound;
        private int _usesRemaining;

        [Constructable]
        public ReturnPortal(int hue, int sound, int uses)
            : base(0x0DDA)
        {
            _hue            = hue;
            _sound          = sound;
            _usesRemaining  = uses;

            Hue     = _hue;
            Name    = "Flickering Return Portal";
            Movable = false;
            Light   = LightType.Circle300;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (_usesRemaining <= 0)
            {
                from.SendMessage("The return portal flickers and vanishes.");
                Delete();
                return;
            }

            if (!from.InRange(this, 3))
            {
                from.SendLocalizedMessage(500446); // Too far away.
                return;
            }

            _usesRemaining--;
            MoveOut(from);

            if (_usesRemaining <= 0)
                Timer.DelayCall(TimeSpan.FromSeconds(1.1), () => { try { Delete(); } catch { } });
        }

		private void MoveOut(Mobile m)
		{
			// collect pets
			var pets = new List<BaseCreature>();
			var playersMount = m.Mount as BaseCreature;

			foreach (Mobile mob in m.Map.GetMobilesInRange(Location, 200))
			{
				if (mob is BaseCreature bc && bc != playersMount &&
					((bc.Controlled && bc.ControlMaster == m) ||
					 (bc.Summoned  && bc.SummonMaster  == m)))
				{
					pets.Add(bc);
				}
			}

			// VFX / SFX
            Effects.SendLocationParticles(
               EffectItem.Create(Location, Map, EffectItem.DefaultDuration),
               0x3728, 10, 10, 2023
            );

			Timer.DelayCall(TimeSpan.FromSeconds(1.0), () =>
			{
				foreach (var pet in pets)
				{
					// use a fresh local name so the compiler knows it’s always assigned
					if (pet is IMount mount && mount.Rider != null &&
						mount.Rider != pet.ControlMaster)
					{
						mount.Rider = null;
					}

					pet.MoveToWorld(Destination, DestinationMap);
				}

				m.MoveToWorld(Destination, DestinationMap);
				// … rest of teleport logic …
			});
		}


        // ─── serialization ───────────────────────────────────────────
        public ReturnPortal(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(2);               // version
            writer.Write(_hue);
            writer.Write(_sound);
            writer.Write(Destination);
            writer.Write(DestinationMap);
            writer.Write(_usesRemaining);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            _hue   = reader.ReadInt();
            _sound = reader.ReadInt();
            Destination    = reader.ReadPoint3D();
            DestinationMap = reader.ReadMap();

            if (version >= 2)
                _usesRemaining = reader.ReadInt();
            else
                _usesRemaining = 1;

            // emergency cleanup on reboot
            Timer.DelayCall(TimeSpan.Zero, DoEmergencyCleanup);
        }

        private void DoEmergencyCleanup()
        {
            try
            {
                if (Deleted) return;

                // move players to fallback, kill monsters/items
                // …existing code…
            }
            finally
            {
                Delete();
            }
        }
    }

    /// <summary>
    /// One-use “entry” portal at the Map Device.
    /// </summary>
    public class OriginPortal : Item
    {
        public Point3D Destination    { get; set; }
        public Map     DestinationMap { get; set; }

        private int _hue, _sound;
        private int _usesRemaining = 1;

        [Constructable]
        public OriginPortal(int hue, int sound)
            : base(0x0DDA)
        {
            _hue   = hue;
            _sound = sound;

            Hue     = _hue;
            Movable = false;
            Light   = LightType.Circle300;
            Name    = "Entry Portal";
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (_usesRemaining <= 0)
            {
                from.SendMessage("This portal has already been used.");
                Delete();
                return;
            }

            if (!from.InRange(this, 3))
            {
                from.SendLocalizedMessage(500446);
                return;
            }

            _usesRemaining--;
            Effects.SendLocationParticles(
               EffectItem.Create(Location, Map, EffectItem.DefaultDuration),
               0x3728, 10, 10, 2023
            );

            Timer.DelayCall(TimeSpan.FromSeconds(1.0), () =>
            {
                from.MoveToWorld(Destination, DestinationMap);
                Effects.SendLocationParticles(
                   EffectItem.Create(Destination, DestinationMap, EffectItem.DefaultDuration),
                   0x3728, 10, 10, 5023
                );
                Effects.PlaySound(Destination, DestinationMap, _sound);
            });

            if (_usesRemaining <= 0)
                Timer.DelayCall(TimeSpan.FromSeconds(1.1), () => { try { Delete(); } catch { } });
        }

        public OriginPortal(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(2);
            writer.Write(_hue);
            writer.Write(_sound);
            writer.Write(Destination);
            writer.Write(DestinationMap);
            writer.Write(_usesRemaining);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            _hue   = reader.ReadInt();
            _sound = reader.ReadInt();
            Destination    = reader.ReadPoint3D();
            DestinationMap = reader.ReadMap();

            if (version >= 2)
                _usesRemaining = reader.ReadInt();
            else
                _usesRemaining = 1;
        }
    }
}
