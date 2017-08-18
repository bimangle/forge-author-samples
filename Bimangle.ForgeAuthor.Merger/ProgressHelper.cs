using System;
using System.Windows.Forms;

namespace Bimangle.ForgeAuthor.Merger
{
    public class ProgressHelper : IDisposable
    {
        private static ProgressHelper _Instance;

        public static void Close()
        {
            _Instance?.Dispose();
        }

        private FormProgress _Form;

        public ProgressHelper(string title = null)
        {
            _Form = new FormProgress(title);
            _Form.StartPosition = FormStartPosition.CenterScreen;
            _Form.Show();
            _Form.Refresh();

            _Instance = this;
        }

        public void Dispose()
        {
            if (_Form != null)
            {
                _Form.Close();
                _Form = null;

                _Instance = null;
            }
        }
    }
}