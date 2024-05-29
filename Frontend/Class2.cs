using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAproject
{
    internal class Player
    {
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerAge { get; set; }
        public string PlayerPosition { get; set; }
        public string PlayerHeight { get; set; }
        public string PlayerWeight { get; set; }

        public override string ToString()
        {
            return $"{PlayerName} - {PlayerPosition} - Age: {PlayerAge} - Height: {PlayerHeight} - Weight: {PlayerWeight}";
        }
    }
}
