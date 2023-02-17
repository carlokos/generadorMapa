using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int width,height, depth; //x,y,z
    [SerializeField] private int seed;
    [SerializeField] private int detalle;
    

    void Start()
    {
        seed = Random.Range(10000, 30000);
        CreateMap();
    }

    public void CreateMap()
    {
        Vector3 size =  new Vector3(width, height, depth);
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < depth; j++)
            {
                height = (int)(Mathf.PerlinNoise(((float)i / 2 + seed) / detalle, (float)(j / 2 + seed) / detalle) * detalle);
                for(int k = 0; k < height; k++)
                {
                    GameObject cube = Instantiate(prefab, new Vector3(i, k, j), Quaternion.identity);
                    AplicarTextura(cube, height);
                }
            }
        }
    }

    public void AplicarTextura(GameObject cube, int height)
    {
        if(height < 5)
        {
            cube.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
        }
        else
        {
            cube.GetComponent<MeshRenderer>().materials[0].color = Color.green;
        }
    }
}
