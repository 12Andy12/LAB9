using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using LAB9.Models;
using Avalonia.Media.Imaging;

namespace LAB9.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
		public class Image
		{
			public Bitmap Img { get; set; }
			public string Path { get; set; }
			public Image(string path)
			{
				Img = new Bitmap(path);
				Path = path;
			}
		}
		public ObservableCollection<Image> DirectoryImages { get; set; }
		public ObservableCollection<Node> Items { get; }

		List<string> allDrivesNames;

		public MainWindowViewModel()
		{
			allDrivesNames = new List<string>();
			Items = new ObservableCollection<Node>();
			DirectoryImages = new ObservableCollection<Image>();
			DriveInfo[] allDrives = DriveInfo.GetDrives(); //Возвращает имена всех логических дисков на компьютере.

			foreach (DriveInfo drive in allDrives)
			{
				allDrivesNames.Add(drive.Name);
				Node rootNode = new Node(drive.Name, true);
				Items.Add(rootNode);
			}
		}

		public void RefreshImageList(List<string> imagesPaths)
		{
			DirectoryImages.Clear();
			foreach (string image in imagesPaths)
				DirectoryImages.Add(new Image(image));
		}
	}
}
