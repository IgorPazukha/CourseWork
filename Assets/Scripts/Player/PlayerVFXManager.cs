using UnityEngine;

public class PlayerVFXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _footStep;

    public void UpdateFootStep(bool state)
    {
        if(state)
            _footStep.Play();
        else
            _footStep.Stop();
    }
}
