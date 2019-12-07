using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReadOnly<T> {
    [SerializeField] private T value;
    public T Value { get { return value; } }

    public static implicit operator T(ReadOnly<T> instance) {
        return (instance.value);
    }
}
