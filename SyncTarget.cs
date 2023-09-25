using System;
using System.Diagnostics;

namespace BandaidLauncher
{
    public class SyncTarget
    {
        private string remoteDir;
        private string localDir;
        private bool enabled;

        public SyncTarget(string remoteDir, string localDir, bool enabled = true)
        {
            this.remoteDir = FileSystem.ExpandZanyPath(remoteDir);
            this.localDir = FileSystem.ExpandZanyPath(localDir);
            this.enabled = enabled;
        }

        public static List<SyncTarget> LoadManyFromConfig()
        {
            return new List<SyncTarget>();
        }

        public bool IsEnabled()
        {
            return enabled;
        }

        private void SyncError(string message)
        {
            MessageBox.Show($"Sync error for {this.ToString}: {message}", "Sync Error :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Sync()
        {
            // Boring checks for bad conditions
            if (File.Exists(remoteDir))
            {
                SyncError("RemoteDir is file, should be directory.");
                return;
            }

            if (File.Exists(localDir))
            {
                SyncError("LocalDir is file, should be directory.");
                return;
            }

            if (!Directory.Exists(remoteDir))
            {
                if (!Directory.Exists(localDir))
                {
                    SyncError("RemoteDir doesn't exist. Can't copy from LocalDir because it also doesn't exist...");
                    return;
                }
                // Remote dir doesnt exist, copy from local

                // FIXME: ???
                new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(localDir, remoteDir);
                return;
            }

            // Now the real deal
            if (!Directory.Exists(localDir)) {
                // If local dir doesn't exist, just copy remote dir
                // FIXME: ???
                new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(remoteDir, localDir);
                return;
            }

            // Both exist. Oh boy.

            Debug.WriteLine($"Syncing {this.ToString()}");
        }

        public override string ToString()
        {
            return $"{remoteDir} -> {localDir}";
        }
    }
}