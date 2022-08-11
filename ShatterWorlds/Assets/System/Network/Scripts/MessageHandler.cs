using System.Network.Scripts;
using RiptideNetworking;


public class MessageHandler
{
    [MessageHandler((ushort)ServerToClientId.seed)]
    private static void Name(ushort fromClientId, Message message)
    {
        
    }
}
