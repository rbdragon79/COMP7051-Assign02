using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEyes : MonoBehaviour
{

    public Transform PlayerBody;
    public float mousemove_Speed = 10.0f;
    float xAxisClamp = 0.0f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousemove_Speed;
        float mouseY = Input.GetAxis("Mouse Y") * mousemove_Speed;
        xAxisClamp -= mouseY;
        Vector3 target = transform.rotation.eulerAngles;
        Vector3 targetBady = PlayerBody.rotation.eulerAngles;
        target.x -= mouseY;
        targetBady.y += mouseX;
        target.z = 0;
        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            target.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            target.x = 270;
        }
        print(mouseY);
        transform.rotation = Quaternion.Euler(target);
        PlayerBody.rotation = Quaternion.Euler(targetBady);
        /*  if (Input.GetMouseButton(0))
          {
              float mouseBonX = Input.GetAxis("Mouse X") * mousemove_Speed;
              float mouseBonY = Input.GetAxis("Mouse Y") * mousemove_Speed;
              xAxisClamp -= mouseBonY;


              Vector3 bonTarget = transform.rotation.eulerAngles;
              Vector3 bonTargetBady = PlayerBody.rotation.eulerAngles;
              bonTarget.x -= mouseBonY;
              bonTargetBady.y += mouseBonX;
              bonTarget.z = 0;
              if (xAxisClamp > 90)
              {
                  xAxisClamp = 90;
                  bonTarget.x = 90;
              }
              else if (xAxisClamp < -90)
              {
                  xAxisClamp = -90;
                  bonTarget.x = 270;
              }
              print(mouseBonY);
              transform.rotation = Quaternion.Euler(bonTarget);
              PlayerBody.rotation = Quaternion.Euler(bonTargetBady);
          }*/

    }
}
