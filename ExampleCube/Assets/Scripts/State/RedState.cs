using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RedState : State
{
    public RedState(StateManager stateManager): base (stateManager) {
    }
    public override void StartState() {
        Debug.Log("Turning into Red state");
        //Debug.Log(_apple.GetComponent<MeshRenderer>().material.color);
        //_apple.GetComponent<MeshRenderer>().material.SetColor("Red", Color.red);
        UpdateState();
    }

    public override async void UpdateState() {
        var startScale = _apple.transform.localScale;
        var endScale = new Vector3(10f, 10f, 10f);

        float ratio = 0;
        while (ratio < 1) {
            _apple.transform.localScale = Vector3.Lerp(startScale, endScale, ratio);

            ratio += 0.1f * Time.deltaTime;
            CheckState();
           // Debug.Log(ratio);
            await Task.Yield();
        }
        _stateManager.SetState(new BrownState(_stateManager));
    }

    public override void CheckState(){
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray: ray, hitInfo: out hitInfo)) {
                Debug.Log(hitInfo.transform.name + " is Red");
            }
        }
    }
}
