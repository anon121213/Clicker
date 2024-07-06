using System.Collections;
using UnityEngine;

namespace BootStrap
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}