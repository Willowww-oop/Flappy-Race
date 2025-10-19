using System;

namespace HelperScripts
{
    public class ScoreEventArgs : EventArgs
    {
        //score to add to the global score, can be negative or positive. Would have called it ScoreToAdd, but that sucks
        public readonly int s;

        public ScoreEventArgs(int s)
        {
            this.s = s;
        }
    }
}
