using UnityEngine;

public class MoveSceneToPlayer : MonoBehaviour
{
    private void Start()
    {
        //On start move gameobject to playerCamera
        transform.position = Camera.main.transform.position;
    }
}
