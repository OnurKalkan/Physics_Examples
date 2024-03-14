using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    float yOffset, zOffset;

    private void Start()
    {
        yOffset = transform.position.y - player.position.y;
        zOffset = transform.position.z - player.position.z;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + zOffset);
    }
}
