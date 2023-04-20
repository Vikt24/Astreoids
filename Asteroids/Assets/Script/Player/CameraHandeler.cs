using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandeler : MonoBehaviour
{
    public Camera cam;
    public GameObject player;

    void Update()
    {
        Vector3 pPos = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10);

        cam.transform.position = pPos;
    }
}
