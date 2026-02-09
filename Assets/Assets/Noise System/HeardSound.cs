using UnityEngine;

public struct HeardSound
{
    public float heardIntensity; // The intensity of the sound that was heard
    public Vector3 position; // The position of the sound that was heard

    public HeardSound(Vector3 position, float heardIntensity)
    {
        this.heardIntensity = heardIntensity;
        this.position = position;
    }
}