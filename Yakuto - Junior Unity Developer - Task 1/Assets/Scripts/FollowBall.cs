using UnityEngine;

public class FollowBall : MonoBehaviour
{
    private readonly Vector3 offset = new(0, 4, -11);
  
    public GameObject target;
    public float smoothSpeed = 0.5f;

    void FixedUpdate()
    {
        if(target == null)
            return; 
        
        Vector3 desiredPosition  = target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
