using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float Speed, AmountOfBuildings;
    public GameObject BackGroundPrefab;
    public Shader back;
    Material BuildingMat;
    GameObject BackGrounds;
    public bool Finished = false;
    Rigidbody TB;
    // Start is called before the first frame update
    void Start()
    {
        BackGrounds = new GameObject("BackGrounds");
        for (int i = 0; i < AmountOfBuildings; i++)
        {
            BackGroundGenerator(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Finished != true)
        {
            Speed = Mathf.Clamp(Speed, 0, 5);
            Speed += 0.001f;
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
    }

    void BackGroundGenerator(int i)
    {
        BuildingMat = new Material(back);
        BuildingMat.color = Random.ColorHSV();
        GameObject Prefab = Instantiate(BackGroundPrefab);
        Prefab.transform.position = new Vector3(i*1.1f - 10, Random.Range(-5.0f, -3.0f), 0);
        Prefab.GetComponent<MeshRenderer>().material = BuildingMat;
        Prefab.transform.parent = BackGrounds.transform;
    }
}
