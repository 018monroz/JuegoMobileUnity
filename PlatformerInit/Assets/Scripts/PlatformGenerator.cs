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
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject trampolinePrefab;
    [SerializeField] bool isInfinite;
    [SerializeField] float generatorOffset = 0.45f;
    [SerializeField] float obstacleGeneratorOffset = 0.45f;

    float lastHeightPos;
    float lastObstaclePos;
    // Start is called before the first frame update
    void Start()
    {
        lastHeightPos = 0;
        lastObstaclePos = 1f; ;
        float horizontalPos = Random.Range(izquierda.position.x, derecha.position.x);
        float verticalPos= Random.Range(inferior.position.y + 0.2f, superior.position.y);
        GameObject plataforma = GeneratePlatform(new Vector3(horizontalPos, verticalPos));

        float ObshorizontalPos = Random.Range(izquierda.position.x, derecha.position.x);
        float ObsverticalPos = Random.Range(inferior.position.y + 0.5f, superior.position.y+ lastObstaclePos);
        GameObject obstaculo = GenerateObstacle(new Vector3(ObshorizontalPos, ObsverticalPos));


        lastHeightPos = plataforma.transform.position.y + generatorOffset;
        lastObstaclePos = obstaculo.transform.position.y + obstacleGeneratorOffset;
        StartCoroutine(GeneratePlatforms());
        StartCoroutine(GenerateObstacles());
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

    GameObject GenerateTrampoline(Vector3 posicion)
    {
        GameObject trampolin = Instantiate(trampolinePrefab);
        trampolin.transform.position = posicion;
        return trampolin;
    }

    GameObject GenerateObstacle(Vector3 posicion)
    {
        GameObject obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.position = posicion;
        return obstacle;
    }
    

    IEnumerator GeneratePlatforms()
    {
        int contador = 0;
        while (true)
        {
            float horizontalPos = Random.Range(izquierda.position.x, derecha.position.x);
            float verticalPos = Random.Range(lastHeightPos+0.2f, superior.position.y+lastHeightPos);

            if (Random.Range(0, 100) < 15) 
            {
                GameObject trampolin = GenerateTrampoline(new Vector3(horizontalPos, verticalPos));
                lastHeightPos = trampolin.transform.position.y + generatorOffset;
            }
            else
            {
                GameObject plataforma = GeneratePlatform(new Vector3(horizontalPos, verticalPos));
                lastHeightPos = plataforma.transform.position.y + generatorOffset;
            }
            
            if(contador>30) yield return new WaitForSeconds(0.2f);
            contador++;
        }
    }

    IEnumerator GenerateObstacles()
    {
        int contador = 0;
        while (true)
        {
            float horizontalPos = Random.Range(izquierda.position.x, derecha.position.x);
            float verticalPos = Random.Range(lastObstaclePos + 0.5f, superior.position.y + lastObstaclePos);
            GameObject obstaculo = GenerateObstacle(new Vector3(horizontalPos, verticalPos));
            lastObstaclePos = obstaculo.transform.position.y + obstacleGeneratorOffset;
            if (contador > 30) yield return new WaitForSeconds(0.2f);
            contador++;
        }
    }
}
