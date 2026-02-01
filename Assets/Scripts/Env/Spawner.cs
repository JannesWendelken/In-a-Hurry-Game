using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Diamond")]
    public GameObject diamond;

    [Header("Spawners")]
    public Transform[] spawners;

    [Header("How many Spawn")]
    public int toSpawn = 0;

    [Header("Parent for spawned objects")]
    public Transform parent;

    void Start()
    {
        SpawnEntity();
    }

    public void SpawnEntity()
    {
        if (spawners.Length == 0 || diamond == null)
            return;

        Transform[] spawnersClone = (Transform[])spawners.Clone();

        int spawnCount = Mathf.Min(toSpawn, spawnersClone.Length);

        for (int i = 0; i < spawnCount; i++)
        {
            int randomIndex = Random.Range(0, spawnersClone.Length);

            Instantiate(diamond, spawnersClone[randomIndex].position, spawnersClone[randomIndex].rotation, parent);

            spawnersClone[randomIndex] = spawnersClone[spawnersClone.Length - 1];
            System.Array.Resize(ref spawnersClone, spawnersClone.Length - 1);
        }
    }
}
