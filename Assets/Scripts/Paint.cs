using UnityEngine;
using System.Collections;
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
        Shoes.AddComponent<SkinnedMeshRenderer>();
    }

    void FixedUpdate()
	{
        //if (Input.touchCount > 0)
        if (Input.GetMouseButton(0))
        {
            //Touch touch = Input.GetTouch(0);
            //if (touch.phase == TouchPhase.Moved)
            //{
                //Vector2 pos = touch.position;

                //Brush
                NumOfBrush++;
                GameObject Brush = Instantiate(BrushPrefab);
                Brush.name = "Brush ¹" + NumOfBrush;
                //Brush.transform.position = pos;
                Brush.transform.position = Input.mousePosition;
                Brush.transform.parent = CurrentBrush.transform;

                //Shoe
                GameObject Shoe = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Shoe.transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                //Shoe.transform.position = Camera.main.ScreenToViewportPoint(pos);
                Shoe.transform.parent = Shoes.transform;
                Material ShoeMaterial = new Material(ShoeShader);
                ShoeMaterial.color = Color.black;
                Shoe.GetComponent<MeshRenderer>().material = ShoeMaterial;
                Shoe.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            //}
        }
        else if (Shoes.transform.childCount > 0)
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
        if (GameObject.Find("Shoes ¹" + LastShoes) != null && GameObject.Find("ShoesClone" + LastShoes) != null)
        {
            //GameObject.Find("Shoes ¹" + LastShoes).SetActive(false);
            //GameObject.Find("ShoesClone" + LastShoes).SetActive(false);
            Destroy(GameObject.Find("Shoes ¹" + LastShoes));
            Destroy(GameObject.Find("ShoesClone" + LastShoes));
        }
        Shoes.transform.position = new Vector3(PlayerFeet.transform.position.x, PlayerFeet.transform.position.y, PlayerFeet.transform.position.z);
        Shoes.transform.parent = PlayerFeet.transform;
        Shoes.AddComponent<ShoesScript>().LegID = 1;
        GameObject ShoesClone = Instantiate(Shoes);
        ShoesClone.name = "ShoesClone" + NumOfShoes;
        ShoesClone.transform.position = new Vector3(PlayerFeet.transform.position.x, PlayerFeet.transform.position.y, PlayerFeet.transform.position.z);
        ShoesClone.transform.parent = PlayerFeet.transform;
        ShoesClone.AddComponent<ShoesScript>().LegID = 2;
        NumOfShoes++;
        Shoes = new GameObject("Shoes ¹" + NumOfShoes);
    }
}
