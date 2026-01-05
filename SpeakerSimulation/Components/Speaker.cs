using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            // Add/Remove audio receive event
            if (IsOn && _source != null)
            {
                _source.AudioGenerated += OnAudioReceived;
            }
            else if(!IsOn && _source != null)
            {
                _source.AudioGenerated -= OnAudioReceived;
            }
            
        }

        public void ConnectSource(Source source)
        {
            if(_source != null) return;

            _source = source;
            _source.AudioGenerated += OnAudioReceived;
        }
        public void DisconnectSource()
        {
            if(_source ==  null) return;
    
            _source.AudioGenerated -= OnAudioReceived;
            _source = null;

        }

        public void OnAudioReceived(string data)
        {
            if (IsOn)
                Console.WriteLine("Playing: " + data);
            
        }

        public void PrintStatus() => Console.WriteLine($"Name: {Name}, IsOn: {IsOn}, Volume: {Volume}");

    }
}
