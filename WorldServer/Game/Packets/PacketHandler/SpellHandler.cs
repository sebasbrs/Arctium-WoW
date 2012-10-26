using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldServer.Network;
using WorldServer.Game.WorldEntities;
using Framework.Network.Packets;
using Framework.Constants;
using WorldServer.Game.Managers;
using Framework.DBC;

namespace WorldServer.Game.PacketHandler
{
    public class SpellHandler : Globals
    {
        public static void HandleSendKnownSpells(ref WorldClass session)
        {
            Character pChar = session.Character;

            PacketWriter writer = new PacketWriter(LegacyMessage.SendKnownSpells);
            BitPack BitPack = new BitPack(writer);

            BitPack.Write(1);
            BitPack.Write<uint>((uint)pChar.SpellList.Count, 24);
            BitPack.Flush();

            pChar.SpellList.ForEach(spell =>
                writer.WriteUInt32(spell.SpellId));

            session.Send(writer);
        }
    }
}
