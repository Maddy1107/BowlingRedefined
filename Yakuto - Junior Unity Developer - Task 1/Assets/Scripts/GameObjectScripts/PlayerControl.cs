using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;
    public bool canMove = false;

    public float bounds;
    public float speed = 800.0f;

    private void OnEnable()
    {
        GameEvents.onGameStateChanged += Initialize;
    }

    private void Initialize(GameStates state)
    {
        rb.isKinematic = false;
        canMove = state == GameStates.inProgress;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // we need to end the game when the ball falls off the map

        if (transform.position.x < -bounds || transform.position.x > bounds || transform.position.z < -bounds || transform.position.z > bounds)
        {
            canMove = false;
            rb.constraints = RigidbodyConstraints.None;
            GameStateManager.instance.ChangeGameState(GameStates.gameOver);
        }
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement   = Input.GetAxis("Vertical");

        Vector3 MoveBall = new Vector3(HorizontalMovement, 0, VerticalMovement);

        gameObject.transform.GetComponent<Rigidbody>().AddForce(MoveBall * speed);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        // We check if the object we collided with has a name called "PIN".
        if (collisionInfo.collider.CompareTag("Pin"))
        {
            var pin = collisionInfo.gameObject.GetComponent<PinScript>();
            if (pin.IsStanding())
            {
                LevelDataTracker.instance.ChangeScore(10);
                pin.ChangeState();
            }
        }
    }

    private void OnDisable()
    {
        GameEvents.onGameStateChanged -= Initialize;
    }
}
