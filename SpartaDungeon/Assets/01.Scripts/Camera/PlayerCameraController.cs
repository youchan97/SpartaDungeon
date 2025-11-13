using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float sensivityX;
    [SerializeField] float sensivityY;
    [SerializeField] float clampY;

    public CinemachineVirtualCamera fpsCam;
    public CinemachineVirtualCamera tpsCam;
    public bool isFps = true;

    float xRot;

    public void CameraRotate()
    {
        /*float mouseX = lookVec.x * sensivityX * Time.deltaTime;
        float mouseY = lookVec.y * sensivityY * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -clampY, clampY);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);*/
        float camY = isFps ? fpsCam.transform.eulerAngles.y : tpsCam.transform.eulerAngles.y;
        playerTransform.rotation = Quaternion.Euler(0, camY, 0);
    }
    public void CameraSetting(Player player)
    {
        playerTransform = player.transform;
        fpsCam.Follow = player.PlayerRoot;
        fpsCam.LookAt = player.PlayerRoot;

        tpsCam.Follow = player.PlayerRoot;
        tpsCam.LookAt = player.PlayerRoot;
    }

    public void ChangeView()
    {
        isFps = fpsCam.Priority > tpsCam.Priority;
        if(isFps)
        {
            float rotY = fpsCam.transform.eulerAngles.y;
            tpsCam.transform.rotation = Quaternion.Euler(0, rotY, 0);
        }
        else
        {
            float rotY = tpsCam.transform.eulerAngles.y;

            var pov = fpsCam.GetCinemachineComponent<CinemachinePOV>();
            pov.m_HorizontalAxis.Value = rotY;
        }
        isFps = !isFps;
        int temp = fpsCam.Priority;
        fpsCam.Priority = tpsCam.Priority;
        tpsCam.Priority = temp;
    }
}
