using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] Transform izquierda;
    [SerializeField] Transform derecha;
    [SerializeField] Transform superior;
    [SerializeField] Transform inferior;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] bool isInfinite;
    [SerializeField] float generatorOffset = 0.45f;
    float lastHeightPos;
    // Start is called before the first frame update
    void Start()
    {
        lastHeightPos = 0;
        float horizontalPos = Random.Range(izquierda.position.x, derecha.position.x);
        float verticalPos= Random.Range(inferior.position.y + 0.2f, superior.position.y);
        GameObject plataforma = GeneratePlatform(new Vector3(horizontalPos, verticalPos));
        lastHeightPos = plataforma.transform.position.y + generatorOffset;
        print(superior.position.y - inferior.position.y);
        StartCoroutine(GeneratePlatforms());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject GeneratePlatform(Vector3 posicion)
    {
        GameObject plataforma = Instantiate(platformPrefab);
        plataforma.transform.position = posicion;
        return plataforma;
    }

    IEnumerator GeneratePlatforms()
    {
        int contador = 0;
        while (true)
        {
            float horizontalPos = Random.Range(izquierda.position.x, derecha.position.x);
            float verticalPos = Random.Range(lastHeightPos+0.2f, superior.position.y+lastHeightPos);
            GameObject plataforma = GeneratePlatform(new Vector3(horizontalPos, verticalPos));
            lastHeightPos = plataforma.transform.position.y + generatorOffset;
            if(contador>30) yield return new WaitForSeconds(0.2f);
            contador++;
        }
    }
}
