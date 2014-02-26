using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class KillEventArgs : EventArgs
    {

        public KillEventArgs(int score)
        {
            this.Score = score;
        }

        public int Score { get; private set; }
    }
}