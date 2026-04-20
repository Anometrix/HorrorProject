using UnityEngine;

public class CloseBeginDoor : MonoBehaviour
{
    private bool beingUsed = false;

    [Header("Lerp Settings")]
    [SerializeField] private float yOffset; // offsets y value to the open position
    [SerializeField] private float lerpSpeed = 1f;
    private float lerpProgress = 0f; // door movement progress
    private Vector3 closedPosition;
    private Vector3 openPosition;

    // am big brain
    [Header("Door GameObjects")]
    [SerializeField] private GameObject thisDoor;
    [SerializeField] private GameObject doorTrigger;

    void Start()
    {
        openPosition = thisDoor.transform.position;
        closedPosition = openPosition + Vector3.down * yOffset;
    }
    void Update()
    {
        if (beingUsed)
        {
            lerpProgress += Time.deltaTime * lerpSpeed;
            thisDoor.transform.position = Vector3.Lerp(openPosition, closedPosition, lerpProgress);
            if (lerpProgress >= 1f)
            {
                beingUsed = false;
                doorTrigger.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            beingUsed = true;
        }
    }
}
