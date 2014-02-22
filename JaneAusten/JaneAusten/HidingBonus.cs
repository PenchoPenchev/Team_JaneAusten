using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class HidingBonus:Bonus
    {
        private System.Timers.Timer aTimer = new System.Timers.Timer();
        private int waitBeforeHideMs;
        public bool IsHided { get; private set; }
        protected bool IsRegeneratable { get; private set; }
        
        public HidingBonus(int x, int y, BonusType type, int waitBeforeHideMs, int waitBeforeStartHidingMs = 0, bool isRegeneratable = false) :
            base(x, y, type)
        {
            this.waitBeforeHideMs = waitBeforeHideMs;
            this.IsRegeneratable = isRegeneratable;
            this.IsHided = true;

            System.Threading.Thread.Sleep(waitBeforeStartHidingMs);
            startTimer();
        }

        private void startTimer()
        {
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = waitBeforeHideMs;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.SetCursorPosition(this.PosX, this.PosY);
            if(!this.IsHided)
            {
                Console.Write(" ");
                this.IsHided = true;
            }
            else
            {
                this.DrawObject();
                this.IsHided = false;
            }

            if (this.IsCollected && !this.IsRegeneratable)
            {
                aTimer.Enabled = false;
            }
        }
    }
}
