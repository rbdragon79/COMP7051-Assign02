using UnityEngine;
using UnityEngine.UI;
public class GhostToggle : MonoBehaviour
{
    public GameObject northWall, eastWall, southWall, westWall;
    BoxCollider north, east, south, west;
    public Toggle ghostToggle;

    // Use this for initialization
    void Start()
    {
        north = northWall.GetComponent<BoxCollider>();
        east = eastWall.GetComponent<BoxCollider>();
        south = southWall.GetComponent<BoxCollider>();
        west = westWall.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetButton("GhostToggle"))
        {
            //if (ghostToggle.isOn)
            //{
                ghostToggle.isOn = !ghostToggle.isOn;
                north.enabled = !north.enabled;
                east.enabled = !east.enabled;
                south.enabled = !south.enabled;
                west.enabled = !west.enabled;
           /* }
            else
            {
                ghostToggle.isOn = true;
                north.isTrigger = !north.isTrigger;
                east.isTrigger = !east.isTrigger;
                south.isTrigger = !south.isTrigger;
                west.isTrigger = !west.isTrigger;
            }*/
        }
    }
}
