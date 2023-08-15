﻿using BattleBitAPI;
using BattleBitAPI.Common;
using BattleBitAPI.Server;
using System.Threading.Channels;
using System.Xml;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Battle Bit Server API Framework";
        var listener = new ServerListener<MyPlayer, MyGameServer>();
        listener.Start(29294);
        Thread.Sleep(-1);
    }


}
class MyPlayer : Player<MyPlayer>
{
    public override async Task OnConnected()
    {
    }
}
class MyGameServer : GameServer<MyPlayer>
{
    public override async Task OnConnected()
    {
        ForceStartGame();
        ServerSettings.PointLogEnabled = false;
    }


    public override async Task OnPlayerConnected(MyPlayer player)
    {
        await Console.Out.WriteLineAsync("Connected: " + player);
        foreach (var serverPlayer in AllPlayers)
        {
            if (serverPlayer != player)
            {
                serverPlayer.WarnPlayer($"<size=23>{player} is <color=green><b>connected</b></color> to server!</size>");
            }
            else
            {
                serverPlayer.WarnPlayer($"<size=23><color=green><b>Welcome to our server {player} </b></color></size>");
            }
        }
    }
    public override async Task OnPlayerSpawned(MyPlayer player)
    {
        await Console.Out.WriteLineAsync("Spawned: " + player);
    }
    public override async Task OnAPlayerDownedAnotherPlayer(OnPlayerKillArguments<MyPlayer> args)
    {
        await Console.Out.WriteLineAsync("Downed: " + args.Victim);
    }
    public override async Task OnPlayerGivenUp(MyPlayer player)
    {
        await Console.Out.WriteLineAsync("Giveup: " + player);
    }
    public override async Task OnPlayerDied(MyPlayer player)
    {
        await Console.Out.WriteLineAsync("Died: " + player);
    }
    public override async Task OnAPlayerRevivedAnotherPlayer(MyPlayer from, MyPlayer to)
    {
        await Console.Out.WriteLineAsync(from + " revived " + to);
    }
    public override async Task OnPlayerDisconnected(MyPlayer player)
    {
        await Console.Out.WriteLineAsync("Disconnected: " + player);
        foreach (var serverPlayer in AllPlayers)
        {
            serverPlayer.WarnPlayer($"<size=23>{player} <color=red><b>disconnected</b></color> from server!</size>");
        }
    }
}
