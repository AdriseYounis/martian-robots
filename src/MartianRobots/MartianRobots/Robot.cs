namespace MartianRobots;

public class Robot
{
    public static string ExecuteCommand(string commands)
    {
        var direction = "N";

        var commandArr = commands.ToCharArray();

        foreach (var c in commandArr)
        {
            if (c.Equals('L'))
            {
                direction = direction switch
                {
                    "N" => "W",
                    "W" => "S",
                    "S" => "E",
                    "E" => "N",
                    _ => direction
                };
            }

            if (c.Equals('R'))
            {
                direction = direction switch
                {
                    "N" => "E",
                    "E" => "S",
                    "S" => "W",
                    "W" => "N",
                    _ => direction
                };
            }
        }

        return direction;
    }
}