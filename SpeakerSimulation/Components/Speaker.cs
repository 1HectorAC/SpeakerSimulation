using System;
using System.Collections.Generic;
using System.Text;

namespace SpeakerSimulation.Components
{
    internal class Speaker
    {
        public bool IsOn { get; set; } = false;

        private Source? _source;

        public string Name { get; set; }

        public int Volume { get; set; } = 50;

        public Speaker(string name)
        {
            this.Name = name;
        }

        public void TooglePower()
        {
            IsOn = !IsOn;
            // On: check if source is playing, play sound is so
            if (IsOn && _source != null && _source.IsAudioPlaying)
            {
                Console.WriteLine("Playing Audio: " + _source.Data);
            }
            
        }

        public void ConnectSource(Source source)
        {
            _source = source;
            _source.AudioState += OnAudioReceived;
        }

        public void OnAudioReceived(bool state, string? data)
        {
            if(IsOn && state)
                Console.WriteLine("Playing Audio: " + data);
        }


        public void PrintStatus()
        {
            Console.WriteLine($"Name: {Name}, IsOn: {IsOn}, Volume: {Volume}");
        }

    }
}
