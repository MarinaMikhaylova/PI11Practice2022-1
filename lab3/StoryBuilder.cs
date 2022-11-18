class StoryBuilder
{
    Story story = new Story();

    public StoryBuilder SetupStory(string intro, string final, int id)
    {
        story.Intro = intro;
        story.Final = final;
        story.CurrentLocationId = id;
        return this;
    }

    public StoryBuilder AddLocation(int id, string desc)
    {
        Location loc = new Location()
        {
            Id = id,
            Description = desc
        };
        story.Locations.Add(loc);
        return this;
    }

    public StoryBuilder AddOption(int id, string title, DoWork work)
    {
        Location loc = story.Locations.First(item => item.Id == id);
        Option o = new Option()
        {
            Title = title,
            Work = work
        };
        loc.Options.Add(o);
        return this;
    }

    public StoryBuilder AddOption(int id, int toid, string title)
    {
        Location loc = story.Locations.First(item => item.Id == id);
        Option o = new Option()
        {
            Title = title,
            Work = () => story.CurrentLocationId = toid
        };
        loc.Options.Add(o);
        return this;
    }

    public Story Build () { return story; } 
}