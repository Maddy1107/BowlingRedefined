using System.Collections.Generic;
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

    private List<GameObject> pins = new List<GameObject>();

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

            cam.gameObject.GetComponent<FollowBall>().target = ball.gameObject;

            var ground = Instantiate(groundPrefab, transform.position, Quaternion.identity);

            ground.transform.localScale = new Vector3(GroundLength, 1, GroundLength);

            SpawnPins();
        }
    }

    // spawn 20 pins
    public void SpawnPins()
    {
        for (int i = 0; i < 20; i++)
        {
            var pin = Instantiate(pinPrefab, transform.position + GetRandomVectorWithinRange(), Quaternion.identity);
            pins.Add(pin);
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
