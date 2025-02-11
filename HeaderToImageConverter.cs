using System;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeView
{

    
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            // Get the full path
            var path = value as string;

            // If the path is null, ignore
            if (path ==  null)
                return null;

            // Get the name of the file/folder
            var name = MainWindow.GetFileFolderName(path);

            

            // By default we presume an image
            var image = "file.png";

            // If the name is blank, we presume it's a drive as we cannot have a blank file or folder name
            if (string.IsNullOrEmpty(name))
                image = "drive.png";

            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "folder.png";

                return new BitmapImage(new Uri($"pack://application:,,,/images/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
