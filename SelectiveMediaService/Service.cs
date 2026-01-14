using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static iNovation.Code.General;

namespace SelectiveMediaService {
    public class Service {
        private static string StatusFile { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\iNovation Digital Works\Media\Status.txt";

        /*public static Service Instance { get; private set; } = new Service();

        private Service() { }*/

        public static bool MediaIsPinned()
        {
            if (File.Exists(StatusFile))
                return bool.Parse(ReadText(StatusFile));

            UpdatePinnedMediaStatus(false);
            return false;
        }

        public static void UpdatePinnedMediaStatus(bool value)
        {
            WriteText(StatusFile, value.ToString());
        }
    }
}
