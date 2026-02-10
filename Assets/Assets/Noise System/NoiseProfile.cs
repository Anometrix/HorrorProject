using UnityEngine;

public enum SoundType
{
    Movement,
    Interaction,
    Impact,
    Action,
    Environment
}
[CreateAssetMenu(fileName = "NewSoundEvent", menuName = "Scriptable Objects/Audio/SoundEvent", order = 1)]
public class NoiseProfile : ScriptableObject
{
    [Range(1f, 20f)]
    [Tooltip("Base loudness of sound to multiply by.")]
    public float intensity;

    [Range(1f, 100f)]
    [Tooltip("The distance the sound can be heard from.")]
    public float radius;

    [Range(0f, 8f)]
    [Tooltip("How long the sound should last in seconds, which determines how long it can be heard for.")]
    public float decayTime;

    [Tooltip("The type of sound this is, which determines how important it is compared to other sounds.")]
    public SoundType soundType;
    public float priority // Determines how important this sound is compared to others
    {
        get
        {
            return soundType switch
            {
                SoundType.Action => 3f,
                SoundType.Impact => 2.5f,
                SoundType.Environment => 2f,
                SoundType.Interaction => 1.5f,
                SoundType.Movement => 1f,
                _ => 0f // Unity was being iffy so I added this in
            };
        }
    }
}