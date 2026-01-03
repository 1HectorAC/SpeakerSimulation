using System;
using System.Collections.Generic;
using System.Text;

namespace SpeakerSimulation.Components
{
    internal class Source
    {
        public string Name { get; set; }

        public string Data { get; set; } = "audio data...";

        public bool IsAudioPlaying { get; set; } = false;

        public event Action<bool, string?>? AudioState;
        

        public Source(string name) 
        {
            Name = name;
        }


        public void ChangeAudioState(bool state)
        {
            IsAudioPlaying = state;
            if(IsAudioPlaying)
                AudioState?.Invoke(IsAudioPlaying, Data);
            AudioState?.Invoke(IsAudioPlaying, null);

        }


        public void StopAudio()
        {
            IsAudioPlaying= false;
        }

    }
}
