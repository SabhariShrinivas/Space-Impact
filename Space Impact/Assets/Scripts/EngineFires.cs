using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineFires : MonoBehaviour
{
    [SerializeField] ParticleSystem[] engineFires;
    [SerializeField] int enginePower = 3;
    private void Update()
    {
        HandleFireEngineEmit();
    }
    void HandleFireEngineEmit()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            EmitEngineFireParticles(2, enginePower);
            EmitEngineFireParticles(3, enginePower);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            EmitEngineFireParticles(4, enginePower);
            EmitEngineFireParticles(5, enginePower);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            EmitEngineFireParticles(0, enginePower);  
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            EmitEngineFireParticles(1, enginePower);
    }
    void EmitEngineFireParticles(int engineIndex, int enginePower)
    {
        engineFires[engineIndex].Emit(enginePower);
    }
}
