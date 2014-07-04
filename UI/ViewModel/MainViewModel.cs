using System;
using System.Diagnostics;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Aim.SpecLogLogoReplacer.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly ISpecLogTransformer specLogTransformer;
        private readonly IDialogServices dialogServices;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
          this.specLogTransformer = new SpecLogTransformer();
          this.dialogServices = new WpfDialogServices();
          this.transformCommand = new RelayCommand(DoTransform);
          this.browseForSpecLogCommand = new RelayCommand(DoBrowseForSpecLogCommand);
          this.browseForLogoCommand = new RelayCommand(DoBrowseForLogoCommand);
          this.navigateToAim = new RelayCommand(() => Process.Start("http://www.aimsoftware.com/"));
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

        private readonly RelayCommand browseForSpecLogCommand;

        public RelayCommand BrowseForSpecLog
        {
          get
          {
            return browseForSpecLogCommand;
          }
        }

        private readonly RelayCommand browseForLogoCommand;

        public RelayCommand BrowseForLogo
        {
          get
          {
            return browseForLogoCommand;
          }
        }

        private readonly RelayCommand navigateToAim;

        public RelayCommand NavigateToAim
        {
          get
          {
            return navigateToAim;
          }
        }

        /// <summary>
        /// The <see cref="Feedback" /> property's name.
        /// </summary>
        public const string FeedbackPropertyName = "Feedback";

        private string feedback = "";

        /// <summary>
        /// Sets and gets the Feedback property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Feedback
        {
          get
          {
            return feedback;
          }

          set
          {
            if (feedback == value)
            {
              return;
            }

            RaisePropertyChanging(FeedbackPropertyName);
            feedback = value;
            RaisePropertyChanged(FeedbackPropertyName);
          }
        }


        public Settings GetSettings()
        {
          return new Settings { PathToLogo = this.PathToLogo, PathToSpecLogHtmlFile = this.PathToSpecLogFile };
        }

        public void SetSettings(Settings settings)
        {
          this.PathToLogo = settings.PathToLogo;
          this.PathToSpecLogFile = settings.PathToSpecLogHtmlFile;
        }

      private void DoTransform()
      {
        try
        {
          this.specLogTransformer.Transform(this.PathToSpecLogFile, this.PathToLogo);

          this.Feedback = "done.";
        }
        catch (ArgumentException exception)
        {
          this.Feedback = exception.Message;
        }
    }

        private void DoBrowseForSpecLogCommand()
        {
            string pathToSpecLog = this.dialogServices.BrowseForFile("*.html");

            if (!string.IsNullOrWhiteSpace(pathToSpecLog))
            {
                this.PathToSpecLogFile = pathToSpecLog;
            }
        }

        private void DoBrowseForLogoCommand()
        {
            string pathToNewLogo = this.dialogServices.BrowseForFile("*.png");

            if (!string.IsNullOrWhiteSpace(pathToNewLogo))
            {
                this.PathToLogo = pathToNewLogo;
            }
        }
    }
}