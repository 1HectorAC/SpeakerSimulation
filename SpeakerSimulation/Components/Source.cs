using System;
using System.Collections.Generic;
using System.Text;

namespace SpeakerSimulation.Components
{
    internal class Source
    {
        public string Name { get; set; }

        public string Data { get; set; } = "audio data...";

        public event Action<string>? AudioGenerated;

        public Source(string name) 
        {
            Name = name;
        }

        public void GenerateAudio(bool state)
        {
            AudioGenerated?.Invoke(Data);

        }

        // Consider adding method to call generate audio at regular intervals



    }
}
