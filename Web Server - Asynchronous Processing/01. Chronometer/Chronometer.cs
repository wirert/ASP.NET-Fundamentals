using _01._Chronometer.Contracts;
using System.Diagnostics;

namespace _01._Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        private List<string> laps;

        public Chronometer()
        {
            stopwatch = new Stopwatch();
            laps = new List<string>();
        }

        public string GetTime => stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

        public List<string> Laps => laps;

        public void Start() => stopwatch.Start();

        public void Stop() => stopwatch.Stop();

        public void Reset()
        {
            stopwatch.Reset();
            laps.Clear();
        }

        public string Lap()
        {
            var result = GetTime;
            laps.Add(result);

            return result;
        }
    }
}
