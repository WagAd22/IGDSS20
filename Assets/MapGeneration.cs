using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public Texture2D hightmap;

    public Transform waterPrefab;
    public Transform sandPrefab;
    public Transform grassPrefab;
    public Transform forcePrefab;
    public Transform mountainPrefab;
    public Transform stonePrefab;

    // Start is called before the first frame update
    void Start()
    {
        var width = hightmap.width;
        var height = hightmap.height;

        float[,] x_pixels = new float[width, height];

        float x = 0;
        float z = -5;

        // read the pixel in hightmap and to note that the surface will be create in ZX surface
        // the poisition of tiles will create as following 
        // it start with (0 -5) and then create all the tiles with x = 0 and increamnt the index of Z with 10
        // when the Z is eqaul the heigh the value of x will increamnt with 8.5
        // it check also if the index is odd or even that will help to arrange the tiles as they are in the Assignment
        // (0 -5)  (0 5)    (0 15)   (0 25)
        // (8.5 0) (8,5 10) (8.5 20) (8.5 30)
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                x_pixels[j, i] = hightmap.GetPixel(j, i).r;
                Generat_Tile(x_pixels[j, i], -x, z);// Generate the Map according to the value of the pixel in the Hightmap
                z += 10;
            }
            x -= 8.5f;

            if (i % 2 != 0)
                z = -5;
            else
                z = 0;
        }
    }

    private void Generat_Tile(float pixel, float i, float j)
    {
        if (pixel == 0.0f)
        {
            //0.0 - Water
            Instantiate(waterPrefab, new Vector3(i, 50f * pixel, j), Quaternion.identity);
        }
        else if (pixel > 0.0f && pixel < 0.2f)
        {
            //0.0 to 0.2 - Sand
            Instantiate(sandPrefab, new Vector3(i, 50f * pixel, j), Quaternion.identity);
        }
        else if (pixel >= 0.2f && pixel < 0.4f)
        {
            //0.2 to 0.4 - Grass
            Instantiate(grassPrefab, new Vector3(i, 50f * pixel, j), Quaternion.identity);
        }
        else if (pixel >= 0.4f && pixel < 0.6f)
        {
            //0.4 to 0.6 - Forest
            Instantiate(forcePrefab, new Vector3(i, 50f * pixel, j), Quaternion.identity);
        }
        else if (pixel >= 0.6f && pixel < 0.8f)
        {
            //0.6 to 0.8 - Stone
            Instantiate(stonePrefab, new Vector3(i, 50f * pixel, j), Quaternion.identity);
        }
        else if (pixel >= 0.8f && pixel < 1.0f)
        {
            //0.8 to 1.0 - Mountain
            Instantiate(mountainPrefab, new Vector3(i, 50f * pixel, j), Quaternion.identity);
        }
    }
}
