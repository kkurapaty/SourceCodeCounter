using System.ComponentModel;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Process
{
    public class ASyncTaskController
    {
        private ASyncTask _aSyncTask;
        public event AsyncCompletedEventHandler OnCompleted;
        public event TaskProgressChangedEventHandler OnProgressChanged;

        public bool IsRunning { get; private set; }

        public ASyncTaskController()
        {
            Initialize();
        }

        private void Initialize()
        {
            _aSyncTask = new ASyncTask();
            _aSyncTask.OnTaskCompleted += DoOnCompleted;
            _aSyncTask.OnTaskProgressChanged += DoOnProgressChanged;
        }

        public void Start(ITaskArguments taskArguments)
        {
            _aSyncTask.StartAsync(taskArguments);
            IsRunning = _aSyncTask.IsBusy;
        }

        public void Stop()
        {
            _aSyncTask.CancelAsync();
            IsRunning = _aSyncTask.IsBusy;
        }


        void DoOnProgressChanged(object sender, TaskProgressChangedEventArgs progressArgs)
        {
            IsRunning = _aSyncTask.IsBusy;
            if (OnProgressChanged != null)
                OnProgressChanged(this, progressArgs);

        }

        void DoOnCompleted(object sender, AsyncCompletedEventArgs completedArgs)
        {
            IsRunning = _aSyncTask.IsBusy;
            if (OnCompleted != null)
            {
                OnCompleted(this, completedArgs);
            }
        }

    }
}
