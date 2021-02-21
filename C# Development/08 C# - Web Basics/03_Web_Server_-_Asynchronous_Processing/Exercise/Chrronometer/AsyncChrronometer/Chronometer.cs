using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AsyncChrronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch sw;

        public Chronometer(Stopwatch sw)
        {
            this.sw = sw;
            this.Laps = new List<string>();
        }

        public string GetTime => sw.Elapsed.ToString().ToString().Substring(0, 13);

        public List<string> Laps { get; }

        public void Start()
        {
            sw.Start();
        }

        public void Stop()
        {
            sw.Stop();
        }

        public string Lap()
        {
            //"{minutes}:{seconds}:{milliseconds}"
            
            var result = $"{sw.Elapsed.ToString().Substring(0,13)}";

            this.Laps.Add(result);

            return result;
        }

        public void Reset()
        {
            sw.Reset();
            Laps.Clear();
        }
    }
}
