using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    private const float Y_ANGLE_MIN = -35.0f;
    private const float Y_ANGLE_MAX = 35.0f;

    public Transform Target;
    public Transform Player;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
      private void LateUpdate()
    {
     CamControl();
    }

    // Update is called once per frame
    void CamControl()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        

        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(currentY, currentX, 0);
        }
        else
        {
            transform.LookAt(Target);
            Target.rotation = Quaternion.Euler(currentY, currentX, 0);
            Player.rotation = Quaternion.Euler(0, currentX, 0);
        }
    }
}
   