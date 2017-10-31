using UnityEngine;
using System.Collections;

public class MazeCell : MonoBehaviour
{
    public IntVector2 coordinates;
    private int initializedEdgeCount;
    public MazeRoom room;

    public void Initialize(MazeRoom room)
    {
        room.Add(this);
    }

    private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];

    public MazeCellEdge GetEdge(MazeDirectionEnum direction)
    {
        return edges[(int)direction];
    }

    public void SetEdge(MazeDirectionEnum direction, MazeCellEdge edge)
    {
        edges[(int)direction] = edge;
        initializedEdgeCount += 1;
    }

    public bool IsFullyInitialized
    {
        get
        {
            return initializedEdgeCount == MazeDirections.Count;
        }
    }

    public MazeDirectionEnum RandomUnitializedDirection
    {
        get
        {
            int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
            for(int i = 0; i < MazeDirections.Count; i++)
            {
                if(edges[i] == null)
                {
                    if(skips == 0)
                    {
                        return (MazeDirectionEnum)i;
                    }
                    skips -= 1;
                }
            }
            throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
        }
    }
}
