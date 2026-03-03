using UnityEngine;

public class GeneratorPower : MonoBehaviour, IIenteractable
{
    public string InteractMessage => objectInteractMessage;

    [SerializeField] string objectInteractMessage;

    void TurnPowerOn()
    {
        GameManager.Instance.isPowerOn = true;
    }
    public void Interact()
    {
        TurnPowerOn();
    }
}
