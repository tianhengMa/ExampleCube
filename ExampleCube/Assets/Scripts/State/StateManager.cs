using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] GameObject _apple;
    State _currentState;

    public GameObject Apple { get {return _apple;}}

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Reset();
        }
    }

    public void SetState(State state) {
        _currentState = state;
        _currentState.StartState();
    }

    void Reset() {
        SetState(new GreenState(this));
    }
}
