using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GreenState : State
{
    public GreenState(StateManager stateManager): base (stateManager) {
    }
    public override void StartState() {
        Debug.Log("Turning into GreenState");
        _apple.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
        //Debug.Log(_apple.GetComponent<MeshRenderer>().material.color);
        //_apple.transform.localScale = new Vector3(1f, 1f, 1f);
        UpdateState();
    }

    public override async void UpdateState() {
        var startScale = new Vector3(1f, 1f, 1f);
        var endScale = new Vector3(5f, 5f, 5f);

        var startColor = Color.green;
        var endColor = Color.red;
        float ratio = 0;
        while (ratio < 1) {
            _apple.transform.localScale = Vector3.Lerp(startScale, endScale, ratio);

            _apple.GetComponent<MeshRenderer>().GetPropertyBlock(_propertyBlock);
            _propertyBlock.SetColor("_Color", Color.Lerp(startColor, endColor, ratio));
            _apple.GetComponent<MeshRenderer>().SetPropertyBlock(_propertyBlock);

            ratio += 0.1f* Time.deltaTime;
            CheckState();

            //Debug.Log(ratio);
            await Task.Yield();
        }
        _stateManager.SetState(new RedState(_stateManager));
    }

    public override void CheckState(){
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray: ray, hitInfo: out hitInfo)) {
                Debug.Log(hitInfo.transform.name + " is Green");
            }
        }
    }
}
