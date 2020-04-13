using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TickManager : MonoBehaviour
{
    public static TickManager current;
    void Awake(){
        current = this;
    }

    void Update(){
        EnvTick();
        AtmosTick();
    }


    //Environment ticks
    //used for everything except world gen and atmos sim
    [SerializeField]
    public int envTicks;
    float envTickTime;
    private const float envTickTimeMax = .05f;

    public event Action<int> envTickEvent = delegate{};

    void EnvTick(){
        if (envTickTime >= envTickTimeMax){
            envTickTime -= envTickTimeMax;
            envTicks++;
            
            envTickEvent(envTicks);
        }
        envTickTime += Time.deltaTime;
    }

    //Atmospherics ticks
    //used only for atmos sim
    [SerializeField]
    public int atmosTicks;
    float atmosTickTime;
    private const float atmosTickTimeMax = .2f;

    public event Action<int> atmosTickEvent = delegate{};

    void AtmosTick(){
        if (atmosTickTime >= atmosTickTimeMax){
            atmosTickTime -= atmosTickTimeMax;
            atmosTicks++;
            atmosTickEvent(atmosTicks);
        }
        atmosTickTime += Time.deltaTime;
    }

}
