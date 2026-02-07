using UnityEngine;

public class NoiseSystemManager : MonoBehaviour
{
    #region
    // Noise Event Assets
    [SerializeField] private NoiseProfile playerRun;
    [SerializeField] private NoiseProfile playerStepOnSomething;
    [SerializeField] private NoiseProfile openCloseDoor;
    [SerializeField] private NoiseProfile crashSoft;
    [SerializeField] private NoiseProfile crashHard;

    // Regular Variables

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
}