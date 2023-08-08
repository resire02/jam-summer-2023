using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SessionTracker
{
    static int attempts = 0;

    public static int IncrementAttempts()
    {
        return ++attempts;
    }
}
