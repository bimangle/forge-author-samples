using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bimangle.ForgeAuthor.Merger.Utility
{
    static class FormHelper
    {
        /// <summary>
        /// 允许文本框接收拖入的文件夹路径
        /// </summary>
        /// <param name="text"></param>
        public static void EnableFolderPathDrop(this TextBox text)
        {
            if (text == null || text.AllowDrop) return;

            text.AllowDrop = true;
            text.DragDrop += (sender, e) =>
            {
                if (e.Data.TryParsePath(out var path) && Directory.Exists(path))
                {
                    text.Text = path;
                }
            };

            text.DragEnter += (sender, e) =>
            {
                if (e.Data.TryParsePath(out var path) && Directory.Exists(path))
                {
                    e.Effect = DragDropEffects.Link;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            };
        }

        /// <summary>
        /// 允许控件接收拖入的文件路径
        /// </summary>
        /// <param name="text"></param>
        /// <param name="callback"></param>
        public static void EnableFilePathDrop(this Control text, Action<string> callback)
        {
            if (text == null || text.AllowDrop) return;

            text.AllowDrop = true;
            text.DragDrop += (sender, e) =>
            {
                if (e.Data.TryParsePaths(out var paths))
                {
                    foreach (var path in paths)
                    {
                        callback?.Invoke(path);
                    }
                }
            };

            text.DragEnter += (sender, e) =>
            {
                if (e.Data.TryParsePaths(out var paths) && paths.All(File.Exists))
                {
                    e.Effect = DragDropEffects.Link;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            };
        }

        private static bool TryParsePath(this IDataObject data, out string path)
        {
            path = null;

            try
            {
                if (data == null || data.GetDataPresent(DataFormats.FileDrop) == false)
                {
                    return false;
                }

                path = ((System.Array)data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return false;
            }
        }

        private static bool TryParsePaths(this IDataObject data, out string[] paths)
        {
            paths = null;

            try
            {
                if (data == null || data.GetDataPresent(DataFormats.FileDrop) == false)
                {
                    return false;
                }

                var array = (System.Array)data.GetData(DataFormats.FileDrop);

                var list = new List<string>();
                for (var i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
                {
                    list.Add(array.GetValue(i).ToString());
                }

                paths = list.ToArray();
                return paths.Length > 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
