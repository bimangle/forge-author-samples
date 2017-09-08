using System;
using System.Windows.Forms;

namespace Bimangle.ForgeAuthor.Merger
{
    class ProgressHelper : IDisposable
    {
        private static ProgressHelper _Instance;

        public static void Close()
        {
            _Instance?.Dispose();
        }

        private FormProgress _Form;

        public ProgressHelper(IWin32Window owner = null, string title = null)
        {
            _Form = new FormProgress(title);
            _Form.StartPosition = owner == null
                ? FormStartPosition.CenterScreen
                : FormStartPosition.CenterParent;
            _Form.Show(owner);
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