using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BrownState : State
{
    public BrownState(StateManager stateManager): base (stateManager) {
    }
    public override void StartState() {
        //_apple.GetComponent<MeshRenderer>().material.SetColor("Brown", new Color32(106, 36,0,255));
        Debug.Log("Turning into Brown state");
        //Debug.Log(_apple.GetComponent<MeshRenderer>().material.color);
        UpdateState();
    }

    public override async void UpdateState() {
        var startScale = _apple.transform.localScale;
        var endScale = new Vector3(1f, 1f, 1f);

        var startColor = Color.red;
        var endColor = new Color32(106, 36, 0, 255); // brown color
        float ratio = 0;
        while (ratio < 1) {
            _apple.transform.localScale = Vector3.Lerp(startScale, endScale, ratio);

            _apple.GetComponent<MeshRenderer>().GetPropertyBlock(_propertyBlock);
            _propertyBlock.SetColor("_Color", Color.Lerp(startColor, endColor, ratio));
            _apple.GetComponent<MeshRenderer>().SetPropertyBlock(_propertyBlock);

            ratio += 0.1f * Time.deltaTime;
            CheckState();

            //Debug.Log(ratio);
            await Task.Yield();
        }
    }

    public override void CheckState(){
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray: ray, hitInfo: out hitInfo)) {
                Debug.Log(hitInfo.transform.name + " is Brown");
            }
        }
    }
}
