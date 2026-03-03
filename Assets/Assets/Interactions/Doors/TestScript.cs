using UnityEngine;

public class TestScript : MonoBehaviour, IIenteractable
{
    public string InteractMessage => objectInteractMessage;

    [SerializeField] GameObject spawnPrefab;

    [SerializeField] string objectInteractMessage;

    void Spawn()
    {
        var spawnedObject = Instantiate(spawnPrefab, transform.position + Vector3.up, Quaternion.identity);

        var randomSize = Random.Range(1f, 10f);
        spawnedObject.transform.localScale = Vector3.one * randomSize;

        var randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        spawnedObject.GetComponent<MeshRenderer>().material.color = randomColor;
    }
    public void Interact()
    {
        Spawn();
    }
}
