using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml;

namespace BandaidLauncher
{
    public class Game
    {
        public string name;
        public string path;
        public Bitmap bitmapIcon;
        public HashSet<string> dependencyPaths;

        private readonly string xmlConfigPath;
        private readonly XmlDocument xmlConfig;
        private bool configTainted = false;

        public enum BinaryType : uint
        {
            WIN_32_BIN = 0,
            WIN_64_BIN = 6,
        }

        public Game(string configPath, int iconSizePx)
        {

            xmlConfigPath = configPath;

            xmlConfig = new XmlDocument();
            xmlConfig.Load(configPath);

            if (xmlConfig.DocumentElement == null) throw new Exception("Null and its bad in " + xmlConfigPath);

            string? basePath = Path.GetDirectoryName(configPath) ?? throw new Exception("No basepath with " + configPath);
            string? exePath = (xmlConfig.DocumentElement.SelectSingleNode("path")?.InnerText) ?? throw new Exception("No exepath with " + configPath);
            name = xmlConfig.DocumentElement.SelectSingleNode("name")?.InnerText ?? throw new Exception("No namenode in " + xmlConfigPath);

            path = Path.Combine(basePath, exePath);
            bitmapIcon = GetBitmapIcon(basePath, exePath, xmlConfig.DocumentElement.SelectSingleNode("icon")?.InnerText, iconSizePx);


            XmlNode? deps = xmlConfig.DocumentElement.SelectSingleNode("deps");
            // Make if doesnt exist
            if (deps == null)
            {
                deps = xmlConfig.CreateNode(XmlNodeType.Element, "deps", xmlConfig.DocumentElement.NamespaceURI);
                xmlConfig.DocumentElement.AppendChild(deps);
            }

            dependencyPaths = new HashSet<string>(
                deps.ChildNodes.Cast<XmlNode>().Select(x => x.InnerText)
            );
        }

        public void TaintConfig()
        {
            configTainted = true;
            Debug.WriteLine("Tainted " + xmlConfigPath);
        }

        public bool ShouldCommit()
        {
            return configTainted;
        }

        public bool maybeCommitToConfig()
        {
            if (!configTainted) return false;
            configTainted = false;

            if (xmlConfig.DocumentElement == null) throw new Exception("Null and its bad in " + xmlConfigPath);

            XmlNode? deps = xmlConfig.DocumentElement.SelectSingleNode("deps");

            // Make if doesnt exist
            if (deps == null)
            {
                deps = xmlConfig.CreateNode(XmlNodeType.Element, "deps", xmlConfig.DocumentElement.NamespaceURI);
                xmlConfig.DocumentElement.AppendChild(deps);
            }

            // Clear old
            deps.InnerXml = "";

            // Add new
            foreach (string dep in dependencyPaths)
            {
                XmlNode depNode = xmlConfig.CreateNode(XmlNodeType.Element, "dep", xmlConfig.DocumentElement.NamespaceURI);
                depNode.InnerText = dep;
                deps.AppendChild(depNode);
            }

            xmlConfig.Save(xmlConfigPath);
            Debug.WriteLine("Saved to " + xmlConfigPath);
            return true;
        }

        public void Launch()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = path,
                WorkingDirectory = Path.GetDirectoryName(path)
            };

            foreach (string dep in dependencyPaths)
            {
                startInfo.EnvironmentVariables["PATH"] += ";" + Path.Combine(FileSystem.GetDLLDir(), dep);
            }
            Process? proc = Process.Start(startInfo);
        }

        private static Bitmap GetBitmapIcon(string basePath, string exePath, string? iconPath, int iconSizePx)
        {

            if (iconPath != null)
            {
                // Read icon from location specified in config, if possible
                return ResizeBitmap(new Bitmap(Path.Combine(basePath, iconPath)), iconSizePx);

            }

            Icon? exeIcon = Icon.ExtractAssociatedIcon(Path.Combine(basePath, exePath));
            if (exeIcon != null) return ResizeBitmap(Bitmap.FromHicon(exeIcon.Handle), iconSizePx);

            throw new Exception("NO ICON!");
        }

        private static Bitmap ResizeBitmap(Bitmap bitmap, int size)
        {
            Bitmap ret = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(ret);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(bitmap, 0, 0, size, size);
            return ret;
        }

        public override string ToString()
        {
            return name;
        }


        public BinaryType? GetBinaryType()
        {
            using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            stream.Seek(0x3C, SeekOrigin.Begin);
            using var reader = new BinaryReader(stream);
            if (stream.Position + sizeof(int) > stream.Length)
                return null;
            var peOffset = reader.ReadInt32();
            stream.Seek(peOffset, SeekOrigin.Begin);
            if (stream.Position + sizeof(uint) > stream.Length)
                return null;
            var peHead = reader.ReadUInt32();
            if (peHead != 0x00004550) // "PE\0\0"
                return null;
            if (stream.Position + sizeof(ushort) > stream.Length)
                return null;
            return reader.ReadUInt16() switch
            {
                0x14c => (BinaryType?)BinaryType.WIN_32_BIN,
                0x8664 => (BinaryType?)BinaryType.WIN_64_BIN,
                _ => null,
            };
        }
    }
}