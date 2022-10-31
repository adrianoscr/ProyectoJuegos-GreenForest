using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{
    Player player;

    //CREAMOS UN PLAYER EN EL AWAKE HEREDADO
    public override void Awake()
    {
        base.Awake();

        if (player == null)
        {
            lock (_synLock)
            {
                if (player == null)
                {
                    player = new Player();
                }
            }
        }
    }
}
