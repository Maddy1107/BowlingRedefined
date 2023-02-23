using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private readonly Vector3 offset = new(0, 4, -11);

    public GameObject target;
    public float smoothSpeed = 0.5f;

    public bool isGameRunning;

    private void OnEnable()
    {
        GameEvents.onGameStateChanged += Initialize;
    }

    //This check is to ensure that when the game is over due to ball falling of the
    //platform, the camera does not follow.
    private void Initialize(GameStates state)
    {
        isGameRunning = state == GameStates.inProgress;
    }

    void FixedUpdate()
    {
        if (isGameRunning)
        {
            if (target == null)
                return;

            Vector3 desiredPosition = target.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    private void OnDisable()
    {
        GameEvents.onGameStateChanged -= Initialize;
    }
}
