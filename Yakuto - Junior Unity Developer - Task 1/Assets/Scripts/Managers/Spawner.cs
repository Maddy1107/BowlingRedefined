using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float GroundLength = 50f;

    [Header("Prefabs")]
    [SerializeField] private GameObject pinPrefab;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject pinContainer;

    [SerializeField] private Camera cam;

    private void OnEnable()
    {
        GameEvents.onGameStateChanged += Prepare;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    //Instantiate all the prefabs
    public void Prepare(GameStates state)
    {
        if(state == GameStates.levelStarting)
        {
            GameObject ball = Instantiate(ballPrefab, new Vector3(0, 1, 0), Quaternion.identity);

            cam.GetComponent<CameraFollow>().target = ball;
            ball.gameObject.GetComponent<PlayerControl>().bounds = GroundLength / 2;

            var ground = Instantiate(groundPrefab, transform.position, Quaternion.identity);

            ground.transform.localScale = new Vector3(GroundLength, 1, GroundLength);

            SpawnPins();
        }
    }

    // spawn given number of pins pins
    public void SpawnPins()
    {
        int numberofPins = PinManager.instance.GetPinCount;

        for (int i = 0; i < numberofPins; i++)
        {
            var pin = Instantiate(pinPrefab, transform.position + GetRandomVectorWithinRange(), Quaternion.identity);
            pin.transform.SetParent(pinContainer.transform,true);
        }
    }

    //Get Random Positions for the pins
    private Vector3 GetRandomVectorWithinRange()
    {
        var randomX = Random.Range(-GroundLength / 2, GroundLength / 2);
        var randomZ = Random.Range(-GroundLength / 2, GroundLength / 2);

        return new Vector3(randomX, 1, randomZ);
    }

    private void OnDisable()
    {
        GameEvents.onGameStateChanged -= Prepare;
    }
}
