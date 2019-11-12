using System;

public class CutsceneData
{
    private int timeToFinish;
    private int timeToFinishWhenSkipped;

    private bool skippable;

    public bool Skippable
    {
        set { skippable = value; }
        get { return skippable; } 
    }

    public CutsceneData()
    {
        timeToFinish = -1;
        timeToFinishWhenSkipped = -1;
        skippable = false;
    }

    public CutsceneData(int time, int timeSkipped)
    {
        timeToFinish = time;
        timeToFinishWhenSkipped = timeSkipped;
        skippable = false;
    }

    public int GetTime()
    {
        return (skippable) ? timeToFinishWhenSkipped : timeToFinish;
    }
}
