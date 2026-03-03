using UnityEngine;

public class DoorFunctions : MonoBehaviour, IIenteractable
{
    public string InteractMessage => objectInteractMessage;

    [SerializeField] string objectInteractMessage;

    private bool isOpen = false;

    // am big brain
    [Header("Door GameObjects")]
    [SerializeField] private GameObject thisOpenedDoor; // The GameObject representing the opened state of this door
    [SerializeField] private GameObject thisClosedDoor; // The GameObject representing the closed state of this door

    public void UseDoor()
    {
        if (!isOpen && GameManager.Instance.isPowerOn == true)
        {
            thisOpenedDoor.SetActive(true);
            thisClosedDoor.SetActive(false);
            isOpen = true;
        }
        else
        {
            thisOpenedDoor.SetActive(false);
            thisClosedDoor.SetActive(true);
            isOpen = false;
        }
    }
    public void Interact()
    {
        UseDoor();
    }
}
