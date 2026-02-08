using UnityEngine;

public class NoiseSystemManager : MonoBehaviour
{
    #region
    [Header("Noise Profile References")]
    [SerializeField] private NoiseProfile playerRun;
    [SerializeField] private NoiseProfile playerStepOnSomething;
    [SerializeField] private NoiseProfile openCloseDoor;
    [SerializeField] private NoiseProfile crashSoft;
    [SerializeField] private NoiseProfile crashHard;

    // Regular Variables

    // A list of positions?
    // Posibly a list that contains intensity and position of noise events? [(intesity, position, decayTime),(intesity, position, decayTime)]

    // 1. Then use intensity of noise to calculate what number to give to enemies,
    // 2. position to let them know where to go,
    // 3. and decay time to get rid of this noise event from the list
    #endregion

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
    public void CreateNoiseEvent(NoiseProfile profile, Vector3 soundPos)
    {
        // Create and give location of noise here mabye?
    }
}