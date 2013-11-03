/*
 * 
 * Coroutine Helper
 * 
 * Written by: Bill Cheng
 * Email: cccheng118@yahoo.com
 * 
 */

using UnityEngine;
using System.Collections;

public static class CoroutineHelper
{
    public delegate void Action();
    public delegate void ActionParam(Action action);
    public delegate bool ActionBoolResult();

    public static void Wait(this MonoBehaviour mb, float timeInSeconds, Action action)
    {
        mb.StartCoroutine(WaitAndPerform(timeInSeconds, action));
    }

    private static IEnumerator WaitAndPerform(float timeInSeconds, Action action)
    {
        yield return new WaitForSeconds(timeInSeconds);

        action();
    }

    public static void Wait(this MonoBehaviour mb, float timeInSeconds, ActionParam action, Action toDo)
    {
        mb.StartCoroutine(WaitAndPerform(timeInSeconds, action, toDo));
    }

    private static IEnumerator WaitAndPerform(float timeInSeconds, ActionParam action, Action toDo)
    {
        yield return new WaitForSeconds(timeInSeconds);

        action(toDo);
    }

    public static void Repeat(this MonoBehaviour mb, float timeInSeconds , ActionBoolResult action)
    {
        mb.StartCoroutine(WaitAndPerform(timeInSeconds, mb, action));
    }

    private static IEnumerator WaitAndPerform(float timeInSeconds, MonoBehaviour mb, ActionBoolResult action)
    {
        yield return new WaitForSeconds(timeInSeconds);

        if (action())
            Repeat(mb, timeInSeconds, action);
    }

}
