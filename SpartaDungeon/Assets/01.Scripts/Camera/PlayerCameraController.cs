using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float sensivityX;
    [SerializeField] float sensivityY;
    [SerializeField] float clampY;

    float xRot;

    public void CameraRotate(Vector2 lookVec)
    {
        float mouseX = lookVec.x * sensivityX * Time.deltaTime;
        float mouseY = lookVec.y * sensivityY * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -clampY, clampY);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
