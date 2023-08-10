namespace BootNET.Network;

public class PackageManager
{
    public string Host;

    public PackageManager(string host = "http://ptoservers.tk/")
    {
        Host = host;
    }

    public void DownloadPackage(string name)
    {
        NetworkManager.DownloadFile(Host + name + "/execute.bat/", "0:\\Packages\\" + name + ".bat");
    }
}