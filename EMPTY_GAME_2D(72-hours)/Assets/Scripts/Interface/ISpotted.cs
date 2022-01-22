using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpotted 
{
    void IsSpottedByPlayer(bool isSpotted);

    void Damage(float amount);

    void LetThereBeLight(bool isLight);

}
