public class Program
{
    public static void Main()
    {
        Planet earth = new Planet("Earth");

        
        earth.AddTarget(new Target(TargetType.Animal));
        earth.AddTarget(new Target(TargetType.Human));
        earth.AddTarget(new Target(TargetType.Superhero));

        
        GiantKillerRobot robot = new GiantKillerRobot();

        
        robot.EyeLaserIntensity = Intensity.Kill;
        robot.SetTargets(earth.Targets);

        
        robot.ExecuteMission(earth);
    }
}
