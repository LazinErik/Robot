using System;
using System.Collections.Generic;
using System.Linq;

public enum Intensity
{
    Stun,
    Kill
}

public enum TargetType
{
    Animal,
    Human,
    Superhero
}

public class Target
{
    public TargetType TargetType { get; private set; }
    public bool IsAlive { get; private set; }

    public Target(TargetType targetType)
    {
        TargetType = targetType;
        IsAlive = true;
    }

    public void Eliminate()
    {
        IsAlive = false;
    }
}

public class Planet
{
    public string Name { get; private set; }
    public List<Target> Targets { get; private set; }

    public Planet(string name)
    {
        Name = name;
        Targets = new List<Target>();
    }

    public void AddTarget(Target target)
    {
        Targets.Add(target);
    }

    public bool ContainsLife()
    {
        return Targets.Any(target => target.IsAlive);
    }
}

public class GiantKillerRobot
{
    public Intensity EyeLaserIntensity { get; set; }
    public bool Active { get; private set; }
    private List<Target> Targets { get; set; }
    private int CurrentTargetIndex { get; set; }

    public GiantKillerRobot()
    {
        Initialize();
    }

    public void Initialize()
    {
        Active = true;
        CurrentTargetIndex = 0;
    }

    public void SetTargets(List<Target> targets)
    {
        Targets = targets;
    }

    public void AcquireNextTarget()
    {
        CurrentTargetIndex++;
        if (CurrentTargetIndex >= Targets.Count)
        {
            CurrentTargetIndex = 0;
        }
    }

    public Target CurrentTarget()
    {
        return Targets[CurrentTargetIndex];
    }

    public void FireLaserAt(Target target)
    {
        if (EyeLaserIntensity == Intensity.Kill)
        {
            target.Eliminate();
        }
    }

    public void ExecuteMission(Planet planet)
    {
        while (Active && planet.ContainsLife())
        {
            Target target = CurrentTarget();
            if (target.IsAlive)
            {
                FireLaserAt(target);
            }
            else
            {
                AcquireNextTarget();
            }
        }
    }
}
