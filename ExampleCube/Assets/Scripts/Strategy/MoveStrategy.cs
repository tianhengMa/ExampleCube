using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStrategy : IStrategy
{

    public void Down(GameObject obj)
    {
        obj.transform.localPosition += Vector3.down;
    }

    public void Up(GameObject obj)
    {
        obj.transform.localPosition += Vector3.up;
    }
}
