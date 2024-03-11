using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Transform cam;
    public Transform cam2;

    public Vector3 offset;


    private void Start()
    {
        offset = cam.position - target.position;
    }
    void LateUpdate()
    {
        if (GameManager.Instance.IsState(GameState.Shopping) || GameManager.Instance.IsState(GameState.MainMenu))
        {
            cam.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
        }
        else
        {
            cam.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
        }
        cam.position = Vector3.Lerp(cam.position, target.position + offset, Time.deltaTime * 5f);
    }
}
