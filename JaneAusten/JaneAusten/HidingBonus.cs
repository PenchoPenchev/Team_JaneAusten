using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class HidingBonus:Bonus
    {
        private int waitBeforeHide;
        protected bool IsHided { get; set; }

        System.Timers.Timer aTimer = new System.Timers.Timer();
        
        public HidingBonus(int x, int y, BonusType type, int waitBeforeHide) :
            base(x, y, type)
        {
            this.waitBeforeHide = waitBeforeHide;
            this.IsHided = true;
            startTimer();
        }

        public void startTimer()
        {
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = waitBeforeHide;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.SetCursorPosition(this.PosX, this.PosY);
            if(!this.IsHided)
            {
                Console.Write(" ");
                this.IsHided = true;
                base.IsCollected = true;
            }
            else
            {
                this.DrawObject();
                base.IsCollected = false;
                this.IsHided = false;
            }
        }
    }
}
