using static System.Console;

const int Door = 1;
const int Head = 2;
const int Fireplace = 3;
const int Chest = 4;

Story story = new StoryBuilder()
    .SetupStory("Вы открываете глаза и видете ранее не знакомое вам место, поднимаясь, вы ощущаете резкую боль в голове, кажется, вас оглушили каким-то тяжелым предметом.", "Вы сбежали", Door)
    .AddLocation(Door, "Вы стоите около двери")
    .AddLocation(Head, "Вы стоите около трофея оленьей головы")
    .AddLocation(Fireplace, "Вы стоите около камина")
    .AddLocation(Chest, "Вы стоите около сундука")
    .AddOption(Door, Head, "Подойти к трофею оленьей головы")
    .AddOption(Door, Fireplace, "Подойти к камину")
    .AddOption(Door, Chest, "Подойти к сундуку")
    .AddOption(Head, Door, "Подойти к двери")
    .AddOption(Head, Fireplace, "Подойти к камину")
    .AddOption(Head, Chest, "Подойти к сундуку")
    .AddOption(Fireplace, Head, "Подойти к трофею оленьей головы")
    .AddOption(Fireplace, Chest, "Подойти к сундуку")
    .AddOption(Fireplace, Door, "Подойти к двери")
    .AddOption(Chest, Head, "Подойти к трофею оленьей головы")
    .AddOption(Chest, Fireplace, "Подойти к камину")
    .AddOption(Chest, Door, "Подойти к двери")
    .Build();

////////////
// engine //
////////////
Clear();
WriteLine(story.Intro);
while(true)
{
    Location loc = story.Locations.First(item => item.Id == story.CurrentLocationId);
    WriteLine();
    WriteLine(loc.Description);

    for (int i=0; i<loc.Options.Count; i++)
        WriteLine($"{i+1}) {loc.Options[i].Title}");

    int n = GetInt("Ваш выбор: ", 1, loc.Options.Count) - 1;

    loc.Options[n].Work();
}
WriteLine(story.Final);

int GetInt(string msg, int min, int max)
{
    int result = min;
    bool valid = false;
    do
    {
        Write(msg);
        valid = int.TryParse(ReadLine(), out result);
    } while(!valid || result < min || result > max);
    return result;
}