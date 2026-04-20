using UnityEngine;

public struct HeardSound
{
    public float heardIntensity; // The intensity of the sound that was heard
    public Vector3 position; // The position of the sound that was heard
    public bool isValid; // Whether the sound is valid or not, used for safety checks

    public HeardSound(Vector3 position, float heardIntensity)
    {
        this.heardIntensity = heardIntensity;
        this.position = position;
        isValid = heardIntensity > 0f; // A sound is considered valid if its intensity is greater than 0
    }
}