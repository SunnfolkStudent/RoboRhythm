using UnityEngine;
using TMPro;
 
public class CharacterWobble : MonoBehaviour
{
    TMP_Text textMesh;
 
    Mesh mesh;
 
    Vector3[] vertices;
 
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }
 
    // Update is called once per frame
    void Update()  
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;
 
        for (int w = 0; w < textMesh.textInfo.characterCount; w++)
        {
            TMP_CharacterInfo c = textMesh.textInfo.characterInfo[w];

            int index = c.vertexIndex;
            Vector3 offset = Wobble(Time.time + w);
            vertices[index] += offset;
            vertices[index + 1] += offset;
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
        }
        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }
 
    Vector2 Wobble(float time) {
        return new Vector2(Mathf.Sin(time*1.1f), Mathf.Cos(time*1.2f));
    }
}