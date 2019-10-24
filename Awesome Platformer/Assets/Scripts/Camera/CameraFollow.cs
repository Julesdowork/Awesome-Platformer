using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.3f;
    public Bounds cameraBounds;

    private Transform target;
    private float offsetZ;
    private Vector3 lastTargetPos;
    private Vector3 currentVel;
    private bool followsPlayer;

    void Awake()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.size = new Vector2(Camera.main.aspect * 2 * Camera.main.orthographicSize, 15f);
        cameraBounds = bc.bounds;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG).transform;
        lastTargetPos = target.position;
        offsetZ = (transform.position - target.position).z;
        followsPlayer = true;
    }

    void FixedUpdate()
    {
        if (followsPlayer)
        {
            Vector3 aheadTargetPos = target.position + Vector3.forward * offsetZ;

            if (aheadTargetPos.x >= transform.position.x)
            {
                Vector3 newCamPos = Vector3.SmoothDamp(transform.position, aheadTargetPos,
                    ref currentVel, cameraSpeed);
                transform.position = new Vector3(newCamPos.x, transform.position.y, newCamPos.z);
                lastTargetPos = target.position;
            }
        }
    }
}
