using UnityEngine;

public class TestNoise : MonoBehaviour
{
    float timer;
    [SerializeField] float maxtimerlength;
    [SerializeField] NoiseProfile noiseprofile;

    private void Awake()
    {
        timer = maxtimerlength;

    }

    void Update()
    {
        if (timer <= 0f)
        {
            Debug.Log("Emitted Noise");
            NoiseSystemManager.manInstance.EmitSound(noiseprofile, transform.position);
            timer = maxtimerlength;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
