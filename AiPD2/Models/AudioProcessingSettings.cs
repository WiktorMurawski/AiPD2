using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AiPD2.Models
{
    internal class AudioProcessingSettings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _frameSize = 256;
        private int _hopSize = 128;
        private WindowType _windowType = WindowType.Hamming;

        public int FrameSize
        {
            get => _frameSize;
            set { if (_frameSize != value) { _frameSize = value; OnChanged(); } }
        }

        public int HopSize
        {
            get => _hopSize;
            set { if (_hopSize != value) { _hopSize = value; OnChanged(); } }
        }

        public WindowType WindowType
        {
            get => _windowType;
            set { if (_windowType != value) { _windowType = value; OnChanged(); } }
        }

        private void OnChanged([CallerMemberName] string? prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    internal enum WindowType
    {
        Rectangular,
        Triangular,
        Hamming,
        Hanning,
        Blackman,
    }
}
