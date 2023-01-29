using System.Diagnostics;
using System.Net;

namespace Diabloco;

public class BattleNetHosts
{
    private const string BattleHostname = "YOUR-HOSTNAME-OR-IP-HERE";
    private const string HostsFile = @"C:\WINDOWS\system32\drivers\etc\hosts";
    private readonly ILanguage _language;

    public BattleNetHosts(ILanguage language) => _language = language;

    public bool AddBattleNetHosts()
    {
        try
        {
            if (HasBattleNet())
                if (!RemoveBattleNetHosts())
                    return false;

            var hosts = File.ReadAllLines(HostsFile);
            var hostsList = hosts.ToList();
            var ip = GetIpAddress();
            if (ip == null)
            {
                MessageBox.Show(_language.UnableToResolveHost);
                return false;
            }
            hostsList.Add("# Battle.NET Hosts");
            hostsList.Add($"{ip} eu.actual.battle.net");
            hostsList.Add($"{ip} us.actual.battle.net");
            hostsList.Add($"{ip} cn.actual.battle.net");
            hostsList.Add($"{ip} kr.actual.battle.net");
            hostsList.Add($"{ip} account.battle.net");
            hostsList.Add($"{ip} battle.net");
            hostsList.Add($"{ip} www.battle.net");
            hostsList.Add($"{ip} eu.battle.net");
            hostsList.Add($"{ip} us.battle.net");
            hostsList.Add($"{ip} cn.battle.net");
            hostsList.Add($"{ip} kr.battle.net");
            hostsList.Add("# End Battle.NET Hosts");

            File.WriteAllLines(HostsFile, hostsList.ToArray());
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{nameof(AddBattleNetHosts)}(): Error to add Battle.NET Hosts: {ex.Message}");
            return false;
        }
    }

    public bool HasBattleNet()
    {
        var ip = GetIpAddress();
        return File.ReadAllLines(HostsFile).Any(s => !s.StartsWith("#") && s.Contains("battle.net") && s.Contains(ip));
    }

    public bool RemoveBattleNetHosts()
    {
        try
        {
            var hosts = File.ReadAllLines(HostsFile);
            List<string> newFile = new();
            foreach (var entry in hosts)
            {
                var line = entry.Trim();
                if (line.Contains("battle.net") || line.Contains("Battle.NET Hosts"))
                    if (!line.StartsWith("#") && !line.StartsWith(";"))
                        continue;
                
                newFile.Add(line);
            }
            File.WriteAllLines(HostsFile, newFile.ToArray());
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{nameof(RemoveBattleNetHosts)}(): Error to remove Battle.NET Hosts: {ex.Message}");
            MessageBox.Show(_language.UnableToRewriteHost);
            return false;
        }
    }

    private string GetIpAddress()
    {
        try
        {
            if (IPAddress.TryParse(BattleHostname, out var address))
                return address.ToString();
            
            IPHostEntry host = Dns.GetHostEntry(BattleHostname);
            IPAddress[] ip = host.AddressList;
            return ip[0].ToString();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{nameof(GetIpAddress)}(): Error to fetch D3 Server IP: {ex.Message}");
            return null;
        }
    }
}