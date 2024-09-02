namespace DeclarationOfConsentForm.Controls
{
    public partial class PlaceholderTextBox : TextBox
    {
        private string _placeholderText = string.Empty;
        private bool _isPlaceholderActive = true;

        // Esemény deklarálása
        public event EventHandler PlaceholderTextChanged;

        public string PlaceholderText
        {
            get { return _placeholderText; }
            set { _placeholderText = value; UpdatePlaceholder(); }
        }

        public PlaceholderTextBox()
        {
            ForeColor = Color.Gray;
            Text = _placeholderText;

            GotFocus += (s, e) =>
            {
                if (_isPlaceholderActive)
                {
                    Text = string.Empty;
                    ForeColor = SystemColors.WindowText;
                    _isPlaceholderActive = false;
                }
            };

            LostFocus += (s, e) =>
            {
                HandleLostFocus();
            };
        }

        // Metódus, amely kezelni fogja a LostFocus eseményt
        private void HandleLostFocus()
        {
            if (string.IsNullOrEmpty(Text))
            {
                _isPlaceholderActive = true;
                Text = _placeholderText;
                ForeColor = Color.Gray;
            }
            else
            {
                ForeColor = SystemColors.WindowText;
            }

            // Esemény kiváltása, ha van feliratkozó
            PlaceholderTextChanged?.Invoke(this, EventArgs.Empty);
        }

        public void UpdatePlaceholder()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                _isPlaceholderActive = true;
                Text = _placeholderText;
                ForeColor = Color.Gray;
            }
            else
            {
                _isPlaceholderActive = false;
                ForeColor = SystemColors.WindowText;
            }
        }
    }
}
