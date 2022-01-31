using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleStrategy : IStrategy
{
    public void Down(GameObject obj)
    {
        obj.transform.localScale *= 0.9f;
    }

    public void Up(GameObject obj)
    {
        obj.transform.localScale *= 1.1f;
    }
}
