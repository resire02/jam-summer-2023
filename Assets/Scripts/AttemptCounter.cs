using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttemptCounter
{
    public static int attempts { get; private set; } = 0;

    public static void IncrementAttempts()
    {
        attempts++;
    }
}
