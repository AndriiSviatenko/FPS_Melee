using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericFactory<T>
{
    public abstract T Create(T prefab);
}