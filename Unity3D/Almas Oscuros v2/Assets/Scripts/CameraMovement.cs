using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float smoothValue, lookSensitivity;
    public Transform camTarget;
    private Vector3 currentRot, tempRot;

	void Update () {
        this.transform.position = Vector3.Lerp(this.transform.position, camTarget.position, smoothValue);
        RotateCamera();
    }

    void RotateCamera() {
        currentRot = transform.rotation.eulerAngles;
        currentRot.z = 0;
        transform.rotation = Quaternion.Euler(currentRot);

        if (Mathf.Abs(Input.GetAxis("Mouse X")) > .01) {
            tempRot.y = -Input.GetAxis("Mouse X");
        } else {
            tempRot.y = 0;
        }
        if (Mathf.Abs(Input.GetAxis("Mouse Y")) > .01) {
            tempRot.x = Input.GetAxis("Mouse Y");
        } else {
            tempRot.x = 0;
        }
        tempRot.z = 0;

        transform.Rotate(tempRot * Time.deltaTime * lookSensitivity);
    }
}
