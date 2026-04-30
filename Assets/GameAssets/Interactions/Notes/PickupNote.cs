using UnityEngine;

public class PickupNote : MonoBehaviour, IIenteractable
{
    #region Variables
    public string InteractMessage => objectInteractMessage;

    [SerializeField] string objectInteractMessage;

    [SerializeField] private GameObject note; // Reference to the note GameObject
    #endregion

    public void PickUpNote()
    {
        note.SetActive(!note.activeSelf); // Toggle the note's active state
    }
    public void Interact()
    {
        PickUpNote();
    }
}
