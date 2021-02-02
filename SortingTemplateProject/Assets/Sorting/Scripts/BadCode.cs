using UnityEngine;

public class BadCode : MonoBehaviour
{
    public GameObject clone;
    public int loopTimes = 100;
    public int spawnNumber = 100;
    public float randomArea = 50;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-randomArea, randomArea), 
                                            Random.Range(-randomArea, randomArea), 
                                            Random.Range(-randomArea, randomArea));

            Instantiate(clone, randomPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < loopTimes; i++)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                print("Hit");
            }
            else
            {
                print("Did not hit");
            }
        }
    }
}
