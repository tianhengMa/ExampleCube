using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStrategy
{
    public void Up(GameObject obj);
    public void Down(GameObject obj);
}
