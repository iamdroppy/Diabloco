We have developed a tool to assist users in implementing the first method outlined in the forum post located at the following URL: https://forum.ragezone.com/f1034/open-source-blizzless-diablo-iii-1210902/. This tool, which is a simple Windows Form application, allows for the modification of the hosts file to write or erase the battle.net entry. We are currently in the process of developing a second tool to assist with the second method outlined in the same forum post, which involves binary patching. Both tools are meant for easier distribution.

_It is important to note that the purpose of this tool is to provide a simple and efficient means of modifying the hosts file for those who desire to quickly switch between a modded and retail game mode or for the purpose of redistribution without the need for manual modification of the hosts file. The tool's code is straightforward and intended for basic use._

**Features**

- Resolve the IP address from a given hostname
- Write entries to the hosts file when enabled
- Erase entries to the hosts file when disabled

**How-to set up**

*Note: Run as an Administrator.*

For those interested in experiencing local gameplay, in which both the client and server are residing on the same machine, please proceed to the following link to obtain the latest compiled binaries for the Windows (x86) operating system: https://github.com/iamdroppy/Diabloco/releases/download/local/win-x86.zip

Kindly navigate to the file `BattleNetHosts.cs`, and locate line 8, where you will find the constant `BattleHostname`. It is recommended to change it to your preferred hostname or IP address. *Hostname is preferred.*
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
