using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // GUS COPY
    #region Variables
    // Refernce to what we want our camera to follow
    public Transform target;

    // How quickly the camera moves towards the target
    public float smoothing;

    // Values to hold the max and min postion that bound the camera how much it can move.
    public Vector2 maxPosition;
    public Vector2 minPosition;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called last
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            // make a target position
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Use clamp to bound the camera from going outside of max and min position
            targetPosition.x = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y);

            // finds the distance between current position and target and moves a percentage
            // of that each frame.
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);


        }
    }
}
