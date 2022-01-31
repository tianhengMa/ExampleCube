using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCube : MonoBehaviour
{
    private static SingleCube _instance;

    public static SingleCube Instance {
        get {
            if (_instance == null) {
                var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.AddComponent<SingleCube>();
            }
            return _instance;
        }
    }

    void Awake() {
        if (_instance != null && _instance != this) {
            Debug.Log("Destroy Duplicate");
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
