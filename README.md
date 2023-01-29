We have developed a tool to assist users in implementing the first method outlined in the forum post located at the following URL: https://forum.ragezone.com/f1034/open-source-blizzless-diablo-iii-1210902/. This tool, which is a simple Windows Form application, allows for the modification of the hosts file to write or erase the battle.net entry. We are currently in the process of developing a second tool to assist with the second method outlined in the same forum post, which involves binary patching. Both tools are meant for easier distribution.

**Features**

- Resolve the IP address from a given hostname
- Write entries to the hosts file when enabled
- Erase entries to the hosts file when disabled

**How-to set up**
Kindly navigate to the file BattleNetHosts.cs, and locate line 8, where you will find the constant "BattleHostname". It is recommended to change it to your preferred hostname or IP address. Hostname is preferred.
Example:

```csharp
private const string BattleHostname = "example.com";
```

Where example.com is where your game is set up at.

Or...

```csharp
private const string BattleHostname = "127.0.0.1";
```

Where 127.0.0.1 is where your game is set up at. Keep it as 127.0.0.1 if you are running the server locally.

**Why Hosts method if you can binary patch?**
There are individuals who prefer to maintain the binary code in its original state, without altering the retail game, and have the ability to quickly switch between a modded and retail game mode.

**How about binary patching?**
I will be creating a binary patch this week, as I have been occupied with other matters. However, the tool provided is still useful in the meantime.

**Why this project name?**
_I have no clue._

It is with utmost importance that we inform you that upon activation, the official Battle.Net application will be unable to establish a connection to the server. To avoid any inconvenience, it is imperative that you ensure that you are logged in prior to making this alteration. Please also be informed that once the tool is deactivated, all connections to Battle.NET will be restored to their previous state prior to activation.
