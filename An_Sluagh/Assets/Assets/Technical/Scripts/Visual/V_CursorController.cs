using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_CursorController : MonoBehaviour
{


    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Transform transformer;

    private void OnEnable()
    {
        Cursor.visible = false;
    }


    private void Update()
    {

        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        screenPoint.z = 20.0f; //distance of the plane from the camera
        transformer.position = cam.ScreenToWorldPoint(screenPoint);

    }
}
