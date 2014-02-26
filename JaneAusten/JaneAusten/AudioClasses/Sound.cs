using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace JaneAusten
{
    public static class Sound
    {
        private static string shotgun = @"../../Content/shot.wav";
        private static string collect = @"../../Content/collect.wav";
        private static string die = @"../../Content/die.wav";

        public static SoundPlayer dyingSound = new SoundPlayer(die);

        public static SoundPlayer collectBonus = new SoundPlayer(collect);

        public static SoundPlayer shotSound = new SoundPlayer(shotgun);
    }
}
