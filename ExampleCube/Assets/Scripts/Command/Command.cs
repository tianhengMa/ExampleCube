using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    protected CommandProcessor _commandProcessor;
    public Command(CommandProcessor commandProcessor) {
        _commandProcessor = commandProcessor;
    }
    public virtual IEnumerator Execute() {
        yield break;
    }

    public virtual IEnumerator Undo() {
        yield break;
    }
}
