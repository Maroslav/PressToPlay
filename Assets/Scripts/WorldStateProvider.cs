using Assets.Code.GameState;
using UnityEngine;
using UnityEngine.Assertions;

public class WorldStateProvider : MonoBehaviour
{
    public static WorldState State { get; private set; }


    void Start()
    {
        Assert.IsNull(State);
        State = new WorldState();
        // TODO: Different creation/deserialization
    }
}
