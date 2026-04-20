using UnityEngine;

public class UseKeycardDoor : MonoBehaviour, IIenteractable
{
    #region Variables
    [Header("Keycard Settings")]
    [SerializeField] private string requiredCardColour; // The colour of the keycard required to open the door
    public string InteractMessage => GameManager.Instance.CheckCardCollected(requiredCardColour) ? objectInteractMessage : keycardInteractMessage;

    [Header("Interact Messages")]
    [SerializeField] string objectInteractMessage;
    [SerializeField] string keycardInteractMessage;

    private bool isOpen = false;
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
    #endregion

    void Start()
    {
        closedPosition = thisDoor.transform.position;
        openPosition = closedPosition + Vector3.up * yOffset;
    }
    void Update()
    {
        if (beingUsed)
        {
            lerpProgress += Time.deltaTime * lerpSpeed;
            if (!isOpen)
            {
                thisDoor.transform.position = Vector3.Lerp(closedPosition, openPosition, lerpProgress);
                if (lerpProgress >= 1f)
                {
                    isOpen = true;
                    beingUsed = false;
                }
            }
            else
            {
                thisDoor.transform.position = Vector3.Lerp(openPosition, closedPosition, lerpProgress);
                if (lerpProgress >= 1f)
                {
                    isOpen = false;
                    beingUsed = false;
                }
            }
        }
    }
    public void UseDoor()
    {
        if (GameManager.Instance.CheckCardCollected(requiredCardColour) && !beingUsed)
        {
            lerpProgress = 0f;
            beingUsed = true;
        }
    }
    public void Interact()
    {
        UseDoor();
    }
}
