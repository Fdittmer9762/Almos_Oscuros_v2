using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float smoothValue, lookSensitivity;
    public Transform camTarget, camera;
    private Vector3 currentRot, tempRot;

    private Transform locTarget;
    public LayerMask elm,glm;
    public float maxRad = 8f;

	void Update () {
        this.transform.position = Vector3.Lerp(this.transform.position, camTarget.position, smoothValue);
        RotateCamera();
        if (Input.GetButtonDown("Fire1")) {
            StartCoroutine(FindTarget());
        }
    }

    void RotateCamera() {
        currentRot = transform.rotation.eulerAngles;
        currentRot.z = 0;
        transform.rotation = Quaternion.Euler(currentRot);

        if (Mathf.Abs(Input.GetAxis("Mouse X")) > .02f) {
            tempRot.y = -Input.GetAxis("Mouse X");
        } else {
            tempRot.y = 0;
        }
        if (Mathf.Abs(Input.GetAxis("Mouse Y")) > .02f) {
            tempRot.x = Input.GetAxis("Mouse Y");
        } else {
            tempRot.x = 0;
        }
        tempRot.z = 0;

        transform.Rotate(tempRot * Time.deltaTime * lookSensitivity);
    }

    IEnumerator FindTarget()
    {//Issues with raycasting
        RaycastHit hit;
        //if (Physics.Raycast(camera.position, camera.forward, out hit, 100.0f))
        bool found = false;
        float rad = .5f;
        while (rad < maxRad) {
            if (Physics.SphereCast(camera.position, rad, camera.forward, out hit, 100.0f, elm)) {
                print("enemy found");
                RaycastHit grndHit;
                if (Physics.Linecast(camera.position, hit.transform.position, out grndHit, glm)) {
                    print("but there's somenthing in the way!");
                } else {
                    print(hit.collider + " enemy is visible");
                    break;
                }
            }
            rad = rad + 1f;
            yield return null;
        }

        yield return null;
    }
}
