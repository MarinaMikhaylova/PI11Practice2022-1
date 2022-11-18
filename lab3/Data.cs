class Story
{
    public int CurrentLocationId;
    public string Intro;
    public string Final;
    public List<Location> Locations = new List<Location>();    
}

class Location
{
    public int Id;
    public string Description;
    public List<Option> Options = new List<Option>();
}

class Option
{
    public string Title;
    public DoWork Work;
}

delegate void DoWork ();