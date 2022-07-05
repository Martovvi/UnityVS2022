using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticleAlternative : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    public void StartParticle()
    {
        particles.Play();
    }
}
