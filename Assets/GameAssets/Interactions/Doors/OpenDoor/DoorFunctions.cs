using UnityEngine;

public class DoorFunctions : MonoBehaviour, IIenteractable
{
    #region Variables
    public string InteractMessage => GameManager.Instance.isPowerOn? objectInteractMessage : powerOff;

    [SerializeField] string objectInteractMessage;
    private string powerOff => "Requires Power";

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
        if (GameManager.Instance.isPowerOn == true && !beingUsed)
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
