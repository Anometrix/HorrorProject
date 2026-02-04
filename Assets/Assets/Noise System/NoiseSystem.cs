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
public class NoiseSystem : ScriptableObject
{
    public float intensity; // How loud the sound is
    public float radius; // The area the sound can be "heard"/is known
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