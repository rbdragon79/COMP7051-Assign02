using UnityEngine;
using System.Collections;

public static class MazeDirections
{
    public const int Count = 4;

    public static MazeDirectionEnum RandomValue
    {
        get
        {
            return (MazeDirectionEnum)Random.Range(0, Count);
        }
    }

    private static IntVector2[] vectors = {
        new IntVector2(0, 1),
        new IntVector2(1, 0),
        new IntVector2(0, -1),
        new IntVector2(-1, 0)
    };

    public static IntVector2 ToIntVector2(this MazeDirectionEnum direction)
    {
        return vectors[(int)direction];
    }

    private static MazeDirectionEnum[] reverse =
    {
        MazeDirectionEnum.South,
        MazeDirectionEnum.West,
        MazeDirectionEnum.North,
        MazeDirectionEnum.East
    };

    public static MazeDirectionEnum GetReverse (this MazeDirectionEnum direction)
    {
        return reverse[(int)direction];
    }

    private static Quaternion[] rotations = {
        Quaternion.identity,
        Quaternion.Euler(0f, 90f, 0f),
        Quaternion.Euler(0f, 180f, 0f),
        Quaternion.Euler(0f, 270f, 0f)
    };

    public static Quaternion ToRotation(this MazeDirectionEnum direction)
    {
        return rotations[(int)direction];
    }
}