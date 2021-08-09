using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float Speed, AmountOfBuildings;
    public GameObject BackGroundPrefab;
    public Shader back;
    public bool Finished = false;

    private Animator anim;

    public bool InPlatform = false;
    Material BuildingMat;
    GameObject BackGrounds;
    Rigidbody RB;

    void Start()
    {
        anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        BackGrounds = new GameObject("BackGrounds");
        for (int i = 0; i < AmountOfBuildings; i++)
        {
            BackGroundGenerator(i);
        }
    }

    void Update()
    {
        if (Finished != true)
        {
            if (anim != null)
            {
                anim.enabled = true;
                anim.Play("Base Layer.Bounce", 0, 0.25f);
            }
            Speed = Mathf.Clamp(Speed, 300, 600);
            Speed += 35f;
            RB.AddForce(Vector3.right * Speed * Time.deltaTime);
            var v = RB.velocity;
            if (InPlatform != true)
            {
                v.x = Mathf.Clamp(v.x, 0f, 10f);
            }
            else
            {
                v.x = Mathf.Clamp(v.x, 0f, 3f);
            }
            RB.velocity = v;
            //RB.velocity = new Vector3(0, 0, Speed * Time.deltaTime);
            //transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        else
        {
            RB.velocity = new Vector3(0, 0, 0);
            anim.enabled = false;
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
    private void OnTriggerEnter(Collider other)
    {
        InPlatform = true;
    }
    private void OnTriggerExit(Collider other)
    {
        InPlatform = false;
    }
}
