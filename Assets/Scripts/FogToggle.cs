using UnityEngine;
using UnityEngine.UI;

public class FogToggle : MonoBehaviour
{
    NoiseFog noiseFog;
    public Toggle fogToggle;

    private void Start()
    {
        noiseFog = GetComponent<NoiseFog>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButton("FogToggle"))
        {
            if (fogToggle.isOn)
            {
                fogToggle.isOn = false;
                noiseFog.enabled = false;
            }
            else
            {
                fogToggle.isOn = true;
                noiseFog.enabled = true;
            }
        }
    }
}
