using SpeakerSimulation.Components;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Speaker Simulation \n Enter command:");
var speaker = new Speaker("bk-12");
var pc = new Source("Mac3454");

while (true)
{
    var command = Console.ReadLine();
    if(command == "status")
    {
        speaker.PrintStatus();
    }
    else if (command == "toggle_power")
    {
        speaker.TooglePower();
        Console.WriteLine("Power is Toggled to: " + speaker.IsOn);
    }
    else if(command =="connect")
    {
        ConnectSourceToSpeaker(pc, speaker);
        Console.WriteLine($"{pc.Name} connected to {speaker.Name}");
    }
    else if (command == "exit")
    {
        break;
    }

}

 void ConnectSourceToSpeaker(Source source, Speaker speaker)
{
    speaker.ConnectSource(source);

}


