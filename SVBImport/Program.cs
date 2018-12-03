using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVBImport {
	class Program {
		static void Main(string[] args) {
			string filePath = @"C:\Users\chobbs\Desktop\Social Value Bank\ExampleSFTPFolder";

			using (FileSystemWatcher watcher = new FileSystemWatcher()) {
				watcher.Path = filePath;
				watcher.EnableRaisingEvents = true;
				watcher.NotifyFilter = NotifyFilters.FileName;
				watcher.Filter = "*.*";
				watcher.Created += new FileSystemEventHandler(OnChanged);
				watcher.Deleted += new FileSystemEventHandler(OnChanged);
				watcher.Changed += new FileSystemEventHandler(OnChanged);
				watcher.Renamed += new RenamedEventHandler(OnChanged);

				// wait - not to end
				new System.Threading.AutoResetEvent(false).WaitOne();
			}
		}

		private static void OnChanged(object sender, FileSystemEventArgs e) {
			Console.WriteLine(e.Name);
			Console.WriteLine(e.ChangeType);
		}
	}
}
