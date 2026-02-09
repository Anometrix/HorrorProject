using UnityEngine;

public class SoundInstance
{
    public NoiseProfile profile;
    public Vector3 position;
    public float timeCreated;

    public SoundInstance(NoiseProfile profile, Vector3 position)
    {
        this.profile = profile;
        this.position = position;
        timeCreated = Time.time; // Set the time the sound event was created to the current time
    }
}
