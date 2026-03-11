using UnityEngine;

public class GeneratorPower : MonoBehaviour, IIenteractable
{
    #region Variables
    public string InteractMessage => objectInteractMessage;

    [SerializeField] string objectInteractMessage;
    #endregion

    void TurnPowerOn()
    {
        GameManager.Instance.PowerEnabler();
    }
    public void Interact()
    {
        TurnPowerOn();
    }
}