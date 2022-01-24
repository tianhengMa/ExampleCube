using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCube : MonoBehaviour
{
    private static SingleCube _instance;
    public static SingleCube Instance {
        get {
            if (_instance == null) {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.name = "SingleCube";
                cube.transform.position = new Vector3(0f, 0f, 0f);
                cube.AddComponent<SingleCube>();
            }
            return _instance;
        }
    }
    
    void Awake() {
        if (_instance != null && _instance != this) {
            Debug.Log("Destroy Duplicate Cude");
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void Move() {
        Vector3 pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x, pos.y+0.1f, pos.z);
    }


}
