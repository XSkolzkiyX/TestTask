using UnityEngine;
using System.Collections;
using Unity.UI;
using System.Collections.Generic;

public class Paint : MonoBehaviour
{
    public GameObject PlayerFeet;
    public GameObject BrushPrefab;
    public Shader ShoeShader;
    GameObject CurrentBrush, Shoes;
    int NumOfBrush = 0, NumOfShoes = 0;
    private void Start()
    {
        CurrentBrush = new GameObject("CurrentBrush");
        CurrentBrush.transform.parent = transform;

        Shoes = new GameObject("Shoes ¹" + NumOfShoes);
    }

    void FixedUpdate()
	{
        if(Input.GetMouseButton(0))
        {
            //Brush
            NumOfBrush++;
            GameObject Brush = Instantiate(BrushPrefab);
            Brush.name = "Brush ¹" + NumOfBrush;
            Brush.transform.position = Input.mousePosition;
            Brush.transform.parent = CurrentBrush.transform;
            //Shoe
            GameObject Shoe = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Shoe.transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Shoe.transform.parent = Shoes.transform;
            Material ShoeMaterial = new Material(ShoeShader);
            ShoeMaterial.color = Color.black;
            Shoe.GetComponent<MeshRenderer>().material = ShoeMaterial;
            Shoe.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            /*if(NumOfBrush>1)
            {
                LineRenderer Line =  Brush.AddComponent<LineRenderer>();
                List<Vector3> pos = new List<Vector3>();
                float LastBrush = NumOfBrush - 1;
                pos.Add(Camera.main.ScreenToViewportPoint(GameObject.Find("Brush ¹" + LastBrush).transform.position));
                pos.Add(Camera.main.ScreenToViewportPoint(GameObject.Find("Brush ¹" + NumOfBrush).transform.position));
                //LineRenderer Connection = new GameObject("Connect btw" + CurrentPointInRoute + " & " + LastPointInRoute + " in " + CurrentRoute + " route").AddComponent<LineRenderer>();
                Line.material = new Material(Shader.Find("Sprites/Default"));
                Line.SetColors(Color.black, Color.black);
                Line.SetWidth(1f, 1f);
                Line.SetPositions(pos.ToArray());
            }*/
        }
        else if(Input.GetMouseButtonUp(0))
        {
            NumOfBrush = 0;
            for (int i = 0; i < CurrentBrush.transform.childCount; i++)
            {
                Destroy(CurrentBrush.transform.GetChild(i).gameObject);
            }
            SetShoes();
        }
	}

    void SetShoes()
    {
        int LastShoes = NumOfShoes - 1;
        if(GameObject.Find("Shoes ¹" + LastShoes) !=null)        
        {
            GameObject.Find("Shoes ¹" + LastShoes).SetActive(false);
        }
        Shoes.transform.position = PlayerFeet.transform.position;
        Shoes.transform.parent = PlayerFeet.transform;
        NumOfShoes++;
        Shoes = new GameObject("Shoes ¹" + NumOfShoes);
    }
}
