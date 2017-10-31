using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {

    public MazeCell mazeCell;
    private MazeCell[,] mazeCells;
    public IntVector2 size;
    public MazeHall mazeHall;
    public MazeWall[] mazeWalls;
    public MazeDoor mazeDoor;
    private List<MazeRoom> rooms = new List<MazeRoom>();

    [Range(0f, 1f)]
    public float doorProbability;

    // Update is called once per frame
    void Update()
    {
        
    }

    public MazeCell GetCell (IntVector2 coordinates)
    {
        return mazeCells[coordinates.x, coordinates.z];
    }

    public void GenerateMaze()
    {
        mazeCells = new MazeCell[size.x, size.z];
        List<MazeCell> activeCells = new List<MazeCell>();
        FirstCellGen(activeCells);
        while(activeCells.Count > 0)
        {
            NextCellGen(activeCells);
        }
    }

    private MazeCell CreateCell(IntVector2 coordinates)
    {
        MazeCell newMazeCell = Instantiate(mazeCell) as MazeCell;
        mazeCells[coordinates.x, coordinates.z] = newMazeCell;
        newMazeCell.coordinates = coordinates;
        newMazeCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
        newMazeCell.transform.parent = transform;
        newMazeCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
        return newMazeCell;
    }

    private void FirstCellGen(List<MazeCell> activeCells)
    {
        MazeCell newCell = CreateCell(RandomCoordinates);
        newCell.Initialize(CreateRoom(-1));
        activeCells.Add(newCell);
    }

    private void NextCellGen(List<MazeCell> activeCells)
    {
        int current = activeCells.Count - 1;
        MazeCell currentCell = activeCells[current];

        if(currentCell.IsFullyInitialized)
        {
            activeCells.RemoveAt(current);
            return;
        }

        MazeDirectionEnum direction = currentCell.RandomUnitializedDirection;
        IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
        if (ContainsCoordinates(coordinates))
        {
            MazeCell neighbour = GetCell(coordinates);

            if (neighbour == null)
            {
                neighbour = CreateCell(coordinates);
                CreateHall(currentCell, neighbour, direction);
                activeCells.Add(neighbour);
            }
            else if (currentCell.room == neighbour.room)
            {
                CreateExpandedRoom(currentCell, neighbour, direction);
            }
            else
            {
                CreateWall(currentCell, neighbour, direction);
            }
        }
        else
        {
            CreateWall(currentCell, null, direction);
        }
    }

    private void CreateHall(MazeCell cell, MazeCell otherCell, MazeDirectionEnum direction)
    {
        MazeHall prefab = Random.value < doorProbability ? mazeDoor : mazeHall;
        MazeHall hall = Instantiate(prefab) as MazeHall;
        hall.Initialize(cell, otherCell, direction);
        hall = Instantiate(prefab) as MazeHall;
        if (hall is MazeDoor)
        {
            otherCell.Initialize(CreateRoom(cell.room.settingsIndex));
        }
        else
        {
            otherCell.Initialize(cell.room);
        }
        hall.Initialize(otherCell, cell, direction.GetReverse());
    }

    private void CreateExpandedRoom(MazeCell cell, MazeCell otherCell, MazeDirectionEnum direction)
    {
        MazeHall hall = Instantiate(mazeHall) as MazeHall;
        hall.Initialize(cell, otherCell, direction);
        hall = Instantiate(mazeHall) as MazeHall;
        hall.Initialize(otherCell, cell, direction.GetReverse());
    }

    private MazeRoom CreateRoom(int indexToExclude)
    {
        MazeRoom newRoom = ScriptableObject.CreateInstance<MazeRoom>();
        rooms.Add(newRoom);
        return newRoom;
    }

    private void CreateWall(MazeCell cell, MazeCell otherCell, MazeDirectionEnum direction)
    {
        int i = 0;
        switch(direction)
        {
            case MazeDirectionEnum.North:
                i = 0;
                break;
            case MazeDirectionEnum.East:
                i = 1;
                break;
            case MazeDirectionEnum.South:
                i = 2;
                break;
            case MazeDirectionEnum.West:
                i = 3;
                break;
        }
        MazeWall wall = Instantiate(mazeWalls[i]) as MazeWall;
        wall.Initialize(cell, otherCell, direction);

        if(otherCell != null)
        {
            switch (direction)
            {
                case MazeDirectionEnum.North:
                    i = 2;
                    break;
                case MazeDirectionEnum.East:
                    i = 3;
                    break;
                case MazeDirectionEnum.South:
                    i = 0;
                    break;
                case MazeDirectionEnum.West:
                    i = 1;
                    break;
            }
            wall = Instantiate(mazeWalls[i]) as MazeWall;
            wall.Initialize(otherCell, cell, direction.GetReverse());
        }    
    }

    public IntVector2 RandomCoordinates
    {
        get
        {
            return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
        }
    }

    public bool ContainsCoordinates(IntVector2 coordinate)
    {
        return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
    }

}
