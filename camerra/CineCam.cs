using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class CineCam : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] Transform Maincamera;
    //Quaternion direction;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        Maincamera.rotation = Quaternion.Euler(Maincamera.rotation.x,0f,Maincamera.rotation.z);
        CheckCam();
    }
    void CheckCam()
    {
        try
        {
            cam.Follow = CamPoint.Instance.transform;
            cam.LookAt = CamPoint.Instance.transform;
        }
        catch (Exception ex)
        {
            Debug.Log("null" + ex.Message);
        }
    }


}
