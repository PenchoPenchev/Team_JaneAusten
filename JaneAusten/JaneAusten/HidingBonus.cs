using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class HidingBonus : Bonus
    {
        public bool IsHidden { get; set; }
        
        public HidingBonus(int x, int y, BonusType type) :
            base(x, y, type)
        {
            this.IsHidden = true;
        }

    }
}
