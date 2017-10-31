using UnityEngine;

public class MazeDoor : MazeHall {

	//public Transform hinge;

	private MazeDoor OtherSideOfDoor {
		get {
			return otherCell.GetEdge(direction.GetReverse()) as MazeDoor;
		}
	}
	
	/*public override void Initialize (MazeCell primary, MazeCell other, MazeDirectionEnum direction) {
		base.Initialize(primary, other, direction);
		if (OtherSideOfDoor != null) {
			hinge.localScale = new Vector3(-1f, 1f, 1f);
			Vector3 p = hinge.localPosition;
			p.x = -p.x;
			hinge.localPosition = p;
		}
	}*/
}