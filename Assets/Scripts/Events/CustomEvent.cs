using System.Collections.Generic;

//Absract class, represents any type of event that happens in game
public abstract class CustomEvent{

    public List<string> _name;
    public string _description;

    public abstract void consequence();

}
