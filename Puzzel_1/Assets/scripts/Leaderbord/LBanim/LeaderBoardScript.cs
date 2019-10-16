using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardScript : MonoBehaviour
{
    public Animator LB;

    public void openLB(bool i)
    {
        LB.SetBool("showHighscores", i);
    }
}
