using System;
using GalaSoft.MvvmLight;
using SimpleTimer.Helpers;
using Xamarin.Forms;

namespace SimpleTimer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Timer _timer;

        private TimeSpan _totalSeconds = new TimeSpan(0,0,0,10);
        public TimeSpan TotalSeconds
        {
            get { return _totalSeconds; }
            set { Set(ref _totalSeconds, value); }
        }

        public Command StartCommand { get; set; }
        public Command PauseCommand { get; set; }
        public Command StopCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            StartCommand = new Command(StartTimerCommand);
            PauseCommand = new Command(PauseTimerCommand);
            StopCommand = new Command(StopTimerCommand);
            //make sure you put this in the constructor
            _timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
            TotalSeconds = _totalSeconds;
        }

        private void StartTimerCommand()
        {
            _timer.Start();
        }

        /// <summary>
        /// Counts down the timer
        /// </summary>
        private void CountDown()
        {
            if (_totalSeconds.TotalSeconds == 0)
            {
                //do something after hitting 0, in this example it just stops/resets the timer
                StopTimerCommand();               
            }
            else
            {
                TotalSeconds = _totalSeconds.Subtract(new TimeSpan(0,0,0,1));
            }           
        }

        /// <summary>
        /// Pauses the timer
        /// </summary>
        private void PauseTimerCommand()
        {
            _timer.Stop();
        }

        /// <summary>
        /// Stops and resets the timer
        /// </summary>
        private void StopTimerCommand()
        {
            TotalSeconds = new TimeSpan(0,0,0,10);
            _timer.Stop();
        }
    }
}