using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    //room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.one;

    //follow camera player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraFolSpeed;
    private float lookAhead;


    void Update()
    {
        //room camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),
        //    ref velocity, speed);

        //follow player
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        //camera will follow only the x axis, change to player.position will follow the axis on that position
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x),  0 * cameraFolSpeed);

    }

    public void moveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
