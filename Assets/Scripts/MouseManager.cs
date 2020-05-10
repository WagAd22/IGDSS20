using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    Vector3 mousePos;
    float limitX;
    float limitZ;
    float x;
    float z; // z = y
    float zoom = 1f;

    Camera myCamera;
    void Start()
    {
        limitZ = transform.position.z;
        limitX = transform.position.y;

        myCamera = GetComponent<Camera>();
    }
    void Update()
    {
        // to be clear with that the x is y and z is x that's becauase the coordinate is ZX not XZ
        // the Y is constant because it's the height of the Camera which we dont need it to move the camera
        // in the ZX surface
        if (Input.GetMouseButton(1))
        {

            x = Mathf.Clamp(transform.position.x + 5f * Input.GetAxis("Mouse Y"), limitX - limitX / 2, limitX + limitX / 2);
            z = Mathf.Clamp(transform.position.z - 5f * Input.GetAxis("Mouse X"), limitZ - limitZ / 2, limitZ + limitZ / 2);

            this.transform.position = new Vector3(x, 200, z);
        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            myCamera.fieldOfView += zoom;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            myCamera.fieldOfView -= zoom;
        }

        myCamera.fieldOfView = Mathf.Clamp(myCamera.fieldOfView, 20, 50);


        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var select = hit.transform;
                var selectrender = select.GetComponent<Renderer>();

                Debug.DrawRay(select.position, Vector3.up * 250,Color.red);
                Debug.Log(selectrender.name);
            }
        }
    }


}
