using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server.Network;

namespace Server.Items
{
    public abstract class BaseUnidentifiedItem : Item
    {
        private int _quality;

        public int Quality => _quality;

        private static readonly Random _rand = new Random();
        private const int MinQuality = 1, MaxQuality = 25;

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( "Quality: {0}", _quality );
		}

        // Constructor for random quality
        [Constructable]
        protected BaseUnidentifiedItem(int itemID) : this(itemID, GetRandomQuality()) { }

        // Constructor for specific quality
        [Constructable]
        protected BaseUnidentifiedItem(int itemID, int quality) : base(itemID)
        {
            _quality = Math.Max(MinQuality, Math.Min(MaxQuality, quality));
            Weight  = 1.0;
            LootType = LootType.Regular;
        }

        public BaseUnidentifiedItem(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);              // version
            writer.Write(_quality);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();             // version
            _quality = reader.ReadInt();
        }

        private static int GetRandomQuality()
        {
            // Skewed towards low values: product of two [0,1) is triangular with mode at 0
            double d = _rand.NextDouble() * _rand.NextDouble();
            return (int)(d * (MaxQuality - MinQuality + 1)) + MinQuality;
        }

        // Must be implemented by subclasses to do the actual "reveal"
        public abstract void Identify(Mobile from);
    }
}
