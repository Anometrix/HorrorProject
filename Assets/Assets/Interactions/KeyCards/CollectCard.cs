using UnityEngine;

public class CollectCard : MonoBehaviour, IIenteractable
{
    #region Variables
    public string InteractMessage => objectInteractMessage;

    [SerializeField] string objectInteractMessage;

    [SerializeField] private string cardColour;

    [SerializeField] private GameObject keycard; // Reference to the keycard GameObject
    #endregion

    public void CollectACard()
    {
        GameManager.Instance.CollectCard(cardColour);
        Destroy(keycard); // Destroy the card object after collecting it
    }
    public void Interact()
    {
        CollectACard();
    }
}
