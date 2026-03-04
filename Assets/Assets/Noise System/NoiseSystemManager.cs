using UnityEngine;
using System.Collections.Generic;

public class NoiseSystemManager : MonoBehaviour
{
    #region Variables
    public static NoiseSystemManager manInstance;

    private List<SoundInstance> noiseEvents = new List<SoundInstance>();
    #endregion

    private void Awake()
    {
        if (manInstance != null && manInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            manInstance = this;
        }
    }

    #region Decay Timer
    void Update()
    {
        RemoveOldSounds();
    }
    public void RemoveOldSounds() // Removes old noise events once they are useless
    {
        for (int i = noiseEvents.Count - 1; i >= 0; i--)
        {
            float age = Time.time - noiseEvents[i].timeCreated; // Calculate how long the sound event has been active

            if (age >= noiseEvents[i].profile.decayTime) // If the sound event has decayed, remove it from the list
            {

                noiseEvents.RemoveAt(i);
            }
        }
    }
    #endregion

    #region Sound Calculations
    public float CalculateIntensity(NoiseProfile profile, float distance)
    {
        float distancefalloff = Mathf.Clamp01(1f - (distance / profile.radius)); // Calculates how much the sound should fall off based on distance and radius

        float finalIntensity = profile.intensity * distancefalloff; // Decides intensity base on distance to noise source
        finalIntensity *= profile.priority; // Multiplies intensity by priority

        finalIntensity = Mathf.Clamp(finalIntensity, 0f, 50f); // Clamps resault to prevent it from being too loud and prevent bugs

        return finalIntensity;
    }
    public float CalculateDistance(Vector3 soundPos, Vector3 listenerPos)
    {
        return Vector3.Distance(soundPos, listenerPos);
    }
    public HeardSound GetLoudestSound(Vector3 listenerPos) // Gets the loudest sound relative to the listener's position and returns it as a HeardSound struct
    {
        Vector3 loudestSoundPos = Vector3.zero;
        float maxIntensity = 0f;

        for (int i = 0; noiseEvents.Count > i; i++)
        {
            float distance = CalculateDistance(noiseEvents[i].position, listenerPos);
            float intensity = CalculateIntensity(noiseEvents[i].profile, distance);

            if (intensity > maxIntensity)
            {
                maxIntensity = intensity;
                loudestSoundPos = noiseEvents[i].position;
            }
        }
        Debug.Log("Loudest Sound Intensity: " + maxIntensity);
        return new HeardSound(loudestSoundPos, maxIntensity);
    }
    #endregion

    #region Create Noise Events
    public void EmitSound(NoiseProfile profile, Vector3 soundPos) // Add a noise event to a list
    {
        SoundInstance instance = new SoundInstance(profile, soundPos);
        noiseEvents.Add(instance);
    }
    #endregion
}