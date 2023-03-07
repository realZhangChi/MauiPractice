using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CustomButton.ViewModels;

public class MainViewModel : INotifyPropertyChanged {

    private int _clickedCount;
    public int ClickedCount {
        set => SetField(ref _clickedCount, value, nameof(ClickedCount));
        get => _clickedCount;
    }

    public ICommand Command { get; set; }

    public MainViewModel() {
        Command = new Command(() => {
            ClickedCount++;
        });
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}