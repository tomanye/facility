using System;
using System.Windows.Forms;

namespace PharmInventory.CustomControl
{
    public delegate void ScanComplete(object sender, EventArgs e);

    public partial class ScannerInput : UserControl
    {
        private int _dataSize;

        public event ScanComplete OnScanCompleted;
        
        public ScannerInput()
        {
            InitializeComponent();
            ScanProgress.Maximum = 0;
            ScanProgress.Minimum = 0;
            scanTextInput.TextChanged += scanTextInput_TextChanged;
        }

        void scanTextInput_TextChanged(object sender, EventArgs e)
        {
            if (scanTextInput.Text.Length < 4) return;

            if (scanTextInput.Text.Length <= ScanProgress.Maximum)
                ScanProgress.Value = scanTextInput.TextLength;

            if (ScanProgress.Maximum != 0 && ScanProgress.Value == ScanProgress.Maximum)
                OnScanCompleted(this, e);

            var dataLen = scanTextInput.Text.Substring(0, 4);
            int len;
            if (int.TryParse(dataLen, out len))
              _dataSize = ScanProgress.Maximum = len + 4;
        }

        public new void SetFocus()
        {
            scanTextInput.Focus();
        }

        public string InputData
        {
            get { return scanTextInput.Text; }
        }

        public int DataSize
        {
            get { return _dataSize; }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            scanTextInput.Focus();
        }
    }
}
