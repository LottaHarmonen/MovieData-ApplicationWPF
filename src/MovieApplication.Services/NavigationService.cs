using CommunityToolkit.Mvvm.ComponentModel;

namespace MovieApplication.Services;

public class NavigationService
{
    //private readonly ViewModelLocator _viewModelLocator;

    //private ObservableObject _currentViewModel;

    //public ObservableObject CurrentViewModel
    //{
    //    get
    //    {
    //        return _currentViewModel;
    //    }
    //    set
    //    {
    //        _currentViewModel = value;
    //        OnCurrentViewModelChanged();
    //    }
    //}

    //public NavigationService()
    //{
    //    _viewModelLocator = new ViewModelLocator();
    //    CurrentViewModel = _viewModelLocator.DemoViewModel;
    //}

    //public void ChangeCurrentViewModel(ViewTypes requestedView)
    //{
    //    switch (requestedView)
    //    {
    //        case ViewTypes.Demo:
    //            CurrentViewModel = _viewModelLocator.DemoViewModel;
    //            break;
    //        case ViewTypes.People:
    //            CurrentViewModel = _viewModelLocator.PeopleViewModel;
    //            break;
    //        default:
    //            throw new ArgumentOutOfRangeException(nameof(requestedView), requestedView, null);
    //    }
    //}

    //private void OnCurrentViewModelChanged()
    //{
    //    CurrentViewModelChanged?.Invoke();
    //}


    //public event Action CurrentViewModelChanged;
}
