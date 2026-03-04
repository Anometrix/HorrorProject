using UnityEngine;

public class Test2 : MonoBehaviour, IIenteractable
{
    public string InteractMessage => objectInteractMessage;

    [SerializeField] string objectInteractMessage;

    [SerializeField] NoiseProfile noiseprofile;
   
    public void EmitNoise()
    {
        NoiseSystemManager.manInstance.EmitSound(noiseprofile, transform.position);
    }
    public void Interact()
    {
        EmitNoise();
    }
}
