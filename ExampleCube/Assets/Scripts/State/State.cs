using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public abstract class State
{
    protected StateManager _stateManager;
    protected GameObject _apple;
    protected MaterialPropertyBlock _propertyBlock;
    protected int _layerMask = 1 << 6;
    public State(StateManager stateManager) {
        this._stateManager = stateManager;
        _apple = stateManager.Apple;
        _propertyBlock = new MaterialPropertyBlock();
    }
    public virtual void StartState() {
    }

    public virtual async void UpdateState() {
        await Task.Yield();
    }

    public virtual void CheckState(){
    }
}
