using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerPosition;
    float maxYPos;
    void Start()
    {
        maxYPos = playerPosition.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition.position.y > maxYPos) maxYPos = playerPosition.position.y;
        Vector3 cameraPos = new Vector3(0,maxYPos,-10);
        transform.position = cameraPos;
    }
}
