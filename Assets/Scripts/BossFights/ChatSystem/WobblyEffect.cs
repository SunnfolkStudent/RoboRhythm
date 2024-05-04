using UnityEngine;
using TMPro;
 
public class WobblyEffect : MonoBehaviour
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
 
        for (int w = 0; w < vertices.Length; w++)
        {
            Vector3 offset = Wobble(Time.time + w);
            vertices[w] = vertices[w] + offset;
        }
        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }
 
    Vector2 Wobble(float time) {
        return new Vector2(Mathf.Sin(time*1.3f), Mathf.Cos(time*1.5f));
    }
}