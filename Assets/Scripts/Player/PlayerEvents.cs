using UnityEngine;

public static class PlayerEvents 
{
    public delegate void PlayerEvent();
    public static PlayerEvent playerFrozen;
    public static PlayerEvent playerUnfrozen;
    public static PlayerEvent playerUp;
    public static PlayerEvent playerDown;
    public static PlayerEvent playerLeft;
    public static PlayerEvent playerRight;
    public static PlayerEvent playerRunning;
    public static PlayerEvent playerNotRunning;

    public static PlayerEvent playerMoved;

    public static PlayerEvent playerInteract;

    public delegate void ReturnPlayerEvent(GameObject player);
    public static ReturnPlayerEvent returnPlayer;
}
