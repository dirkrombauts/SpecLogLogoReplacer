using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace SpecLogLogoReplacer.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly ISpecLogTransformer specLogTransformer;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
          ////if (IsInDesignMode)
          ////{
          ////    // Code runs in Blend --> create design time data.
          ////}
          ////else
          ////{
          ////    // Code runs "for real"
          ////}

          this.specLogTransformer = new SpecLogTransformer();
          this.transformCommand = new RelayCommand(DoTransform);
        }

        /// <summary>
        /// The <see cref="PathToSpecLogFile" /> property's name.
        /// </summary>
        public const string PathToSpecLogFilePropertyName = "PathToSpecLogFile";

        private string pathToSpecLogFile = string.Empty;

        /// <summary>
        /// Sets and gets the PathToSpecLogFile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string PathToSpecLogFile
        {
          get
          {
            return pathToSpecLogFile;
          }

          set
          {
            if (pathToSpecLogFile == value)
            {
              return;
            }

            RaisePropertyChanging(PathToSpecLogFilePropertyName);
            pathToSpecLogFile = value;
            RaisePropertyChanged(PathToSpecLogFilePropertyName);
          }
        }

        /// <summary>
        /// The <see cref="PathToLogo" /> property's name.
        /// </summary>
        public const string PathToLogoPropertyName = "PathToLogo";

        private string pathToLogo = string.Empty;

        /// <summary>
        /// Sets and gets the PathToLogo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string PathToLogo
        {
          get
          {
            return pathToLogo;
          }

          set
          {
            if (pathToLogo == value)
            {
              return;
            }

            RaisePropertyChanging(PathToLogoPropertyName);
            pathToLogo = value;
            RaisePropertyChanged(PathToLogoPropertyName);
          }
        }

        private readonly RelayCommand transformCommand;

        /// <summary>
        /// Gets the Transform command.
        /// </summary>
        public RelayCommand Transform
        {
          get
          {
            return transformCommand;
          }
        }

      private void DoTransform()
      {
        this.specLogTransformer.Transform(this.PathToSpecLogFile, this.PathToLogo);
      }
    }
}