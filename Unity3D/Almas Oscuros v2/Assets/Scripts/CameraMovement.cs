using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float smoothValue, lookSensitivity;
    public Transform camTarget, camera;
    private Vector3 currentRot, tempRot;
    public Vector3 camOffset;

    private Transform locTarget;
    private Vector3 adjTarget;
    private float adjVal = .2f;
    public LayerMask elm,glm;
    public float maxRad = 10f;

    public float camAngle, prevAngle, angDir = 5, anglMult;
    private bool canFlick = false;

    void Start() {
        locTarget = camTarget;
    }

	void Update () {
        adjTarget = Vector3.Lerp(camTarget.position, locTarget.position, adjVal);
        this.transform.position = Vector3.Lerp(this.transform.position, adjTarget, smoothValue);
        RotateCamera();
        if (Input.GetButtonDown("Fire1")) {
            StartCoroutine(FindTarget());
        }
        if (canFlick && Mathf.Abs(Input.GetAxis("Mouse X")) > .02) {
            StartCoroutine(FlickCheck());
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

        if(locTarget != camTarget)
        {
            RotateClamp();
        }

        transform.Rotate(tempRot * Time.deltaTime * lookSensitivity);
    }

    void RotateClamp() {
        prevAngle = camAngle;
        camAngle = Vector3.Angle(locTarget.position - camTarget.position, camera.position - camTarget.position);
        if (camAngle < 155f) {
            if (camAngle < prevAngle) {
                anglMult = .05f;
                angDir *= -1f;
                print("rev : " + angDir);
            }
            anglMult += .05f;
            tempRot.y = Mathf.Lerp(tempRot.y, (tempRot.y += (1 / camAngle) * angDir), anglMult);
        }else {
            anglMult = .05f;
        }
    }

    IEnumerator FindTarget()
    {//Issues with raycasting
        RaycastHit hit;

        float rad = .5f;

        if (locTarget == camTarget) {
            while (rad < maxRad) {
                if (Physics.SphereCast(camera.position, rad, camera.forward, out hit, 100.0f, elm)) {
                    RaycastHit grndHit;
                    if (Physics.Linecast(camera.position, hit.transform.position, out grndHit, glm)) {
                    } else {
                        locTarget = hit.transform;
                        canFlick = true;
                        break;
                    }
                }
                rad = rad + 1f;
                yield return null;
            }
        } else {
            locTarget = camTarget;
            print("Target Lost");
            yield return null;
            canFlick = false;
        }
    }

    IEnumerator FlickCheck() {
        canFlick = false;
        float timer = 0f;
        if (Input.GetAxis("Mouse X") > 0) {
            print("right");
        } else {
            print("left");
        }
        while (Mathf.Abs(Input.GetAxis("Mouse X")) > .02f) {
            yield return null;
            timer += Time.deltaTime;
        }
        if (timer < .2f) {
            print("Flick");
        }
        canFlick = true;
    }
}
